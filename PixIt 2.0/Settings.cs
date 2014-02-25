using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_2._0
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        public void Settings_Load(object sender, EventArgs e)
        {
            loadColors();
        }

        internal void loadColors()
        {
            pictureBox_PathColor.BackColor = Main.colorPath;
            pictureBox_DrillColor.BackColor = Main.colorDrill;
            pictureBox_TranslationColor.BackColor = Main.colorTranslation;
            numericPort.Value = Main.numericPort;
        }

        private void button_SetColorPath_Click(object sender, EventArgs e)
        {
            Main.settingColor = "path";
        }

        private void button_SetColorDrill_Click(object sender, EventArgs e)
        {
            Main.settingColor = "drill";
        }

        private void button_SetColorTranslation_Click(object sender, EventArgs e)
        {
            Main.settingColor = "translation";
        }

        private void numericPort_Click(object sender, EventArgs e)
        {
            Main.numericPort = Convert.ToInt32(numericPort.Value);
        }
    }
}
