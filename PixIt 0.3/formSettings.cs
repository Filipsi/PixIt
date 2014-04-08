using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_0._3
{
    public partial class formSettings : Form
    {
        public void debugAddLine(string text)
        {
            if (System.Windows.Forms.Application.OpenForms["formDebug"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["formDebug"] as formDebug).addLine(text);
            }
        }

        public formSettings()
        {
            InitializeComponent();
            this.TopMost = true;
            this.Focus();
            this.BringToFront();
            debugAddLine("Bylo otevřeno okno nastavení");
        }

        public void Settings_Load(object sender, EventArgs e)
        {
            loadColors();
        }

        internal void loadColors()
        {
            picPathColor.BackColor = formMain.colorPath;
            picDrillColor.BackColor = formMain.colorDrill;
            picTranslationColor.BackColor = formMain.colorTranslation;
            numPort.Value = formMain.numPort;
        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            formMain.settingColor = "path";
        }

        private void btnDrill_Click(object sender, EventArgs e)
        {
            formMain.settingColor = "drill";
        }

        private void btnTransition_Click(object sender, EventArgs e)
        {
            formMain.settingColor = "translation";
        }

        private void numPort_Click(object sender, EventArgs e)
        {
            debugAddLine("Číslo portu změněno na COM" + numPort.Value);
        }     
    }
}
