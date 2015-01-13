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
            PrinterQuery.OnCommandExecuted += (obj, args) => {
                if(this.InvokeRequired) {
                    this.Invoke((MethodInvoker)delegate {
                        AddCommandLabel(args.command);
                    });
                }
            };
        }

        public void AddCommandLabel(string _command) {
            LabelCommand.Text = _command;
        }

        private void formPrintProgress_FormClosed(object sender, FormClosedEventArgs e) {
            PrinterQuery.ClearQuery();
        }

        private void TimerUpdate_Tick(object sender, EventArgs e) {
            int procentage = PrinterQuery.GetCompleteProcentage();
            LabelInfo.Text = procentage + "%";
            if(procentage <= 100 && procentage >= 0) { ProgressBarPrint.Value = procentage; }
            if(procentage == 100) { Close(); }
        }

        private void ButtonPause_Click(object sender, EventArgs e) {
            if(ButtonPause.Text == "Pozastavit") {
                PrinterQuery.StopQuery();
                ButtonPause.BackColor = Color.PaleVioletRed;
                ButtonPause.Text = "Pokračovat";
            } else {
                if(Serial.IsOpen()) {
                    Serial.Send(LabelCommand.Text);
                } else if(Tcp.IsConnected()) {
                    Tcp.Send(LabelCommand.Text);
                }
                ButtonPause.BackColor = Color.LightGray;
                ButtonPause.Text = "Pozastavit";
            }
        }

    }

}
