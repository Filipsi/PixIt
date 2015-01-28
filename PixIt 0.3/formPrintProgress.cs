using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_0._3 {

    public partial class formPrintProgress : Form {

        public formPrintProgress() {
            InitializeComponent();
        }

        private void formPrintProgress_Load(object sender, EventArgs e) {
            this.TopMost = true;
            this.Focus();
            this.BringToFront();

            PrinterQuery.OnCommandExecuted += (obj, args) => {
                try {
                    this.Invoke((MethodInvoker) delegate {
                        byte procentage = Convert.ToByte(((float)args.commandCountTotal - args.commandCount) / args.commandCountTotal * 100);
                        SetInfo(procentage, args.command);

                        ProgressBarPrint.Maximum = args.commandCountTotal;
                        ProgressBarPrint.Value = args.commandCountTotal - args.commandCount;

                        if(ProgressBarPrint.Value == ProgressBarPrint.Maximum) {
                            PrinterQuery.ClearQuery();
                            Close(); 
                        }
                    });
                } catch { }
            };

            PrinterQuery.OnCommandCompleted += (obj, args) => {
                if(Serial.IsOpen()) {
                    Serial.Send("DP(" + (args.commandCountTotal - args.commandCount) + "," + args.commandCountTotal + ")");
                } else if(Tcp.IsConnected()) {
                    Tcp.Send("DP(" + (args.commandCountTotal - args.commandCount) + "," + args.commandCountTotal + ")");
                }  
            };
        }

        public void SetInfo(int _procentage, string _command) {
            LabelProgress.Text = _procentage + "%";
            labelCommand.Text = _command;
        }

        private void formPrintProgress_FormClosed(object sender, FormClosedEventArgs e) {
            PrinterQuery.ClearQuery();
        }

        private void ButtonPause_Click(object sender, EventArgs e) {
            if(ButtonPause.Text == "Pozastavit") {
                ButtonPause.Text = "Pokračovat";
                PrinterQuery.StopQuery();
            } else {
                if(Serial.IsOpen()) {
                    Serial.Send(PrinterQuery.GetCommand());
                } else if(Tcp.IsConnected()) {
                    Tcp.Send(PrinterQuery.GetCommand());
                }
                ButtonPause.Text = "Pozastavit";
            }
        }

    }

}
