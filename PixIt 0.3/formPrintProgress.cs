using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
                    if(this.InvokeRequired) {
                        this.Invoke((MethodInvoker)delegate {
                            AddCommandLabel(args.command);

                            ProgressBarPrint.Maximum = args.commandCountTotal;
                            ProgressBarPrint.Value = args.commandCountTotal - args.commandCount;
                            if(ProgressBarPrint.Value == ProgressBarPrint.Maximum) { Close(); }
                        });
                    }
                } catch { }
            };
        }

        public void AddCommandLabel(string _command) {
            LabelCommand.Text = _command;
        }

        private void formPrintProgress_FormClosed(object sender, FormClosedEventArgs e) {
            PrinterQuery.ClearQuery();
        }

        private void ButtonPause_Click(object sender, EventArgs e) {
            if(ButtonPause.Text == "Pozastavit") {
                PrinterQuery.StopQuery();
                ButtonPause.Text = "Pokračovat";
            } else {
                if(Serial.IsOpen()) {
                    Serial.Send(LabelCommand.Text);
                } else if(Tcp.IsConnected()) {
                    Tcp.Send(LabelCommand.Text);
                }
                ButtonPause.Text = "Pozastavit";
            }
        }

    }

}
