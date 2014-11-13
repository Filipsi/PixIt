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

        public void DebugAddLine(string text)  {
            if (System.Windows.Forms.Application.OpenForms["formDebug"] != null) {
                (System.Windows.Forms.Application.OpenForms["formDebug"] as formDebug).addLineDebug(text);
            }
        }

        public formManual() {
            InitializeComponent();
            DebugAddLine("Manuální ovládání bylo otevřeno");
        }

        private void buttonDrillOnLeft_Click(object sender, EventArgs e) {
            Serial.Send("SDL");
        }

        private void buttonDrillOnRight_Click(object sender, EventArgs e) {
            Serial.Send("SDR");
        }

        private void buttonDrillOff_Click(object sender, EventArgs e) {
            Serial.Send("SD0");
        }

        private void buttonPenUp_Click(object sender, EventArgs e) {
            Serial.Send("SPU");
        }

        private void buttonPenDown_Click(object sender, EventArgs e) {
            Serial.Send("SPD");
        }

        private void buttonDefValXYZ_Click(object sender, EventArgs e) {
            PrinterQuery.AddCommand("SPU");
            PrinterQuery.AddCommand("SDU");
            PrinterControl.SetDefaultPosDrill();
            PrinterQuery.Start();
        }

        private void button1_Click(object sender, EventArgs e) {
            PrinterQuery.AddCommand("SPU");
            PrinterQuery.AddCommand("SDU");
            PrinterControl.SetDefaultPosPen();
            PrinterQuery.Start();
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
            Serial.WaitForCommandComplete += ActionMoveZDown;
            PrinterQuery.AddCommand("MZD(" + 1 + ")");
            PrinterQuery.Start();
        }

        private void buttonZdown_MouseUp(object sender, MouseEventArgs e) {
            Serial.WaitForCommandComplete -= ActionMoveZDown;
        }

        private void buttonZup_MouseDown(object sender, MouseEventArgs e) {
            Serial.WaitForCommandComplete += ActionMoveZUp;
            PrinterQuery.AddCommand("MZU(" + 1 + ")");
            PrinterQuery.Start();
        }

        private void buttonZup_MouseUp(object sender, MouseEventArgs e) {
            Serial.WaitForCommandComplete -= ActionMoveZUp;
        }

        private void buttonLEFT_MouseDown(object sender, MouseEventArgs e) {
            Serial.WaitForCommandComplete += ActionMoveXLeft;
            PrinterQuery.AddCommand("MXL(" + 1 + ")");
            PrinterQuery.Start();
        }

        private void buttonLEFT_MouseUp(object sender, MouseEventArgs e) {
            Serial.WaitForCommandComplete -= ActionMoveXLeft;
        }

        private void buttonRIGHT_MouseDown(object sender, MouseEventArgs e) {
            Serial.WaitForCommandComplete += ActionMoveXRight;
            PrinterQuery.AddCommand("MXR(" + 1 + ")");
            PrinterQuery.Start();
        }

        private void buttonRIGHT_MouseUp(object sender, MouseEventArgs e) {
            Serial.WaitForCommandComplete -= ActionMoveXRight;
        }

        private void buttonUP_MouseDown(object sender, MouseEventArgs e) {
            Serial.WaitForCommandComplete += ActionMoveYUp;
            PrinterQuery.AddCommand("MYU(" + 1 + ")");
            PrinterQuery.Start();
        }

        private void buttonUP_MouseUp(object sender, MouseEventArgs e) {
            Serial.WaitForCommandComplete -= ActionMoveYUp;
        }

        private void buttonDOWN_MouseDown(object sender, MouseEventArgs e) {
            Serial.WaitForCommandComplete += ActionMoveYDown;
            PrinterQuery.AddCommand("MYD(" + 1 + ")");
            PrinterQuery.Start();
        }

        private void buttonDOWN_MouseUp(object sender, MouseEventArgs e) {
            Serial.WaitForCommandComplete -= ActionMoveYDown;
        }

    }

}
