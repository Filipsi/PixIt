using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_0._3
{
    public partial class formSettings : Form
    {
        public formSettings()
        {
            InitializeComponent();
            this.TopMost = true;
            this.Focus();
            this.BringToFront();
            formMain.debugResult = 9;
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
            formMain.numPort = Convert.ToInt32(numPort.Value);
            formMain.debugResult = 8;
        }     
    }
}
