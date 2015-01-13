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
            numPort.Value = formMain.numPort;
            numericDpi.Value = (decimal)PrinterControl.Dpi;
            TextBoxIP.Text = formMain.EthernetIP;
            checkBoxDrawSolderingAreas.Checked = PixItCore.drawSolderingAreas;
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

        private void numPort_Click(object sender, EventArgs e) {
            Program.DebugAddLine("Číslo portu změněno na COM" + numPort.Value);
        }

        private void numPort_ValueChanged(object sender, EventArgs e) {
            formMain.numPort = Convert.ToInt32(numPort.Value);
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
    }
}
