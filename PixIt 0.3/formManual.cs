using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_0._3 {

    public partial class formManual : Form {

        public formManual() {
            InitializeComponent();
            Program.Form.debugAddLine("Manuální ovládání bylo otevřeno");
        }

        private void SendCommand(string _command) {
            if(Serial.IsOpen()) {
                Serial.Send(_command);
            } else if(Tcp.IsConnected()) {
                Tcp.Send(_command);
            }
        }

        private void StartCommand() {
            if(Serial.IsOpen()) {
                PrinterQuery.StartSerial();
            } else if(Tcp.IsConnected()) {
                PrinterQuery.StartTcp();
            }
        }

        private void buttonDrillOnLeft_Click(object sender, EventArgs e) {
            SendCommand("SDL");
        }

        private void buttonDrillOnRight_Click(object sender, EventArgs e) {
            SendCommand("SDR");
        }

        private void buttonDrillOff_Click(object sender, EventArgs e) {
            SendCommand("SD0");
        }

        private void buttonPenUp_Click(object sender, EventArgs e) {
            SendCommand("SPU");
        }

        private void buttonPenDown_Click(object sender, EventArgs e) {
            SendCommand("SPD");
        }

        private void buttonDefValXYZ_Click(object sender, EventArgs e) {
            PrinterQuery.AddCommand("SPU");
            PrinterQuery.AddCommand("SDU");
            PrinterControl.SetDefaultPosDrill();
            StartCommand();
        }

        private void button1_Click(object sender, EventArgs e) {
            PrinterQuery.AddCommand("SPU");
            PrinterQuery.AddCommand("SDU");
            PrinterControl.SetDefaultPosPen();
            StartCommand();
        }

        //Actions
        private void ActionMoveZDown(object sender, EventArgs e) {
            PrinterQuery.AddCommand("MZD(" + 1 + ")");
        }

        private void ActionMoveZUp(object sender, EventArgs e) {
            PrinterQuery.AddCommand("MZU(" + 1 + ")");
        }

        private void ActionMoveXLeft(object sender, EventArgs e) {
            PrinterQuery.AddCommand("MXL(" + 1 + ")");
        }

        private void ActionMoveXRight(object sender, EventArgs e) {
            PrinterQuery.AddCommand("MXR(" + 1 + ")");
        }

        private void ActionMoveYDown(object sender, EventArgs e) {
            PrinterQuery.AddCommand("MYD(" + 1 + ")");
        }

        private void ActionMoveYUp(object sender, EventArgs e) {
            PrinterQuery.AddCommand("MYU(" + 1 + ")");
        }

        //Move
        private void buttonZdown_MouseDown(object sender, MouseEventArgs e) {
            PrinterQuery.WaitForCommandComplete += ActionMoveZDown;
            PrinterQuery.AddCommand("MZD(" + 1 + ")");
            StartCommand();
        }

        private void buttonZdown_MouseUp(object sender, MouseEventArgs e) {
            PrinterQuery.WaitForCommandComplete -= ActionMoveZDown;
        }

        private void buttonZup_MouseDown(object sender, MouseEventArgs e) {
            PrinterQuery.WaitForCommandComplete += ActionMoveZUp;
            PrinterQuery.AddCommand("MZU(" + 1 + ")");
            StartCommand();
        }

        private void buttonZup_MouseUp(object sender, MouseEventArgs e) {
            PrinterQuery.WaitForCommandComplete -= ActionMoveZUp;
        }

        private void buttonLEFT_MouseDown(object sender, MouseEventArgs e) {
            PrinterQuery.WaitForCommandComplete += ActionMoveXLeft;
            PrinterQuery.AddCommand("MXL(" + 1 + ")");
            StartCommand();
        }

        private void buttonLEFT_MouseUp(object sender, MouseEventArgs e) {
            PrinterQuery.WaitForCommandComplete -= ActionMoveXLeft;
        }

        private void buttonRIGHT_MouseDown(object sender, MouseEventArgs e) {
            PrinterQuery.WaitForCommandComplete += ActionMoveXRight;
            PrinterQuery.AddCommand("MXR(" + 1 + ")");
            StartCommand();
        }

        private void buttonRIGHT_MouseUp(object sender, MouseEventArgs e) {
            PrinterQuery.WaitForCommandComplete -= ActionMoveXRight;
        }

        private void buttonUP_MouseDown(object sender, MouseEventArgs e) {
            PrinterQuery.WaitForCommandComplete += ActionMoveYUp;
            PrinterQuery.AddCommand("MYU(" + 1 + ")");
            StartCommand();
        }

        private void buttonUP_MouseUp(object sender, MouseEventArgs e) {
            PrinterQuery.WaitForCommandComplete -= ActionMoveYUp;
        }

        private void buttonDOWN_MouseDown(object sender, MouseEventArgs e) {
            PrinterQuery.WaitForCommandComplete += ActionMoveYDown;
            PrinterQuery.AddCommand("MYD(" + 1 + ")");
            StartCommand();
        }

        private void buttonDOWN_MouseUp(object sender, MouseEventArgs e) {
            PrinterQuery.WaitForCommandComplete -= ActionMoveYDown;
        }

    }

}
