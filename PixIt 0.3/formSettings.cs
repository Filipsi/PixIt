using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_0._3 {

    public partial class formSettings : Form {

        public formSettings() {
            InitializeComponent();
            this.TopMost = true;
            this.Focus();
            this.BringToFront();
            Program.DebugAddLine("Bylo otevřeno okno nastavení");
        }

        public void Settings_Load(object sender, EventArgs e) {
            loadData();
        }

        internal void loadData() {
            picPathColor.BackColor = PixItCore.colorPath;
            picDrillColor.BackColor = PixItCore.colorDrill;
            picTranslationColor.BackColor = PixItCore.colorTranslation;
            ComboBoxPort.Text = formMain.numPort.ToString();
            numericDpi.Value = (decimal)PrinterControl.Dpi;
            TextBoxIP.Text = formMain.EthernetIP;
            checkBoxDrawSolderingAreas.Checked = PixItCore.drawSolderingAreas;
            CheckBoxShowFileInfo.Checked = formMain.ShowFileInfo;
        }

        private void btnRoute_Click(object sender, EventArgs e) {
            formMain.settingColor = "path";
        }

        private void btnDrill_Click(object sender, EventArgs e) {
            formMain.settingColor = "drill";
        }

        private void btnTransition_Click(object sender, EventArgs e)  {
            formMain.settingColor = "translation";
        }

        private void numericDpi_ValueChanged(object sender, EventArgs e) {
            PrinterControl.Dpi = Convert.ToInt32(numericDpi.Value);
        }

        private void checkBoxDebugModePrint_CheckedChanged(object sender, EventArgs e) {
            PrinterControl.PrinterDebugMode = checkBoxDebugModePrint.Checked;
        }

        private void TextBoxIP_TextChanged(object sender, EventArgs e) {
            formMain.EthernetIP = TextBoxIP.Text;
        }

        private void checkBoxDrawSolderingAreas_CheckedChanged(object sender, EventArgs e) {
            PixItCore.drawSolderingAreas = checkBoxDrawSolderingAreas.Checked;
        }

        private void ComboBoxPort_SelectedIndexChanged(object sender, EventArgs e) {
            formMain.numPort = Convert.ToInt32(ComboBoxPort.Text);
        }

        private void ComboBoxPort_KeyPress(object sender, KeyPressEventArgs e) {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                formMain.numPort = Convert.ToInt32(ComboBoxPort.Text);
                e.Handled = true;
            }
        }

        private void formSettings_FormClosing(object sender, FormClosingEventArgs e) {
            if(ComboBoxPort.Text == "") { ComboBoxPort.Text = "0"; }
            formMain.numPort = Convert.ToInt32(ComboBoxPort.Text);
        }

        private void ComboBoxPort_DropDown(object sender, EventArgs e) {
            ComboBoxPort.Items.Clear();
            foreach(string s in Serial.GetComPorts()) {
                ComboBoxPort.Items.Add(s.Substring(s.IndexOf("COM") + 3));
            }
        }

        private void CheckBoxShowFileInfo_CheckedChanged(object sender, EventArgs e) {
            formMain.ShowFileInfo = CheckBoxShowFileInfo.Checked;
        }
    }
}
