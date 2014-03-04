using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PixIt_2._0
{
    public partial class ManualControl : Form
    {
        const int moveXp = 0;
        const int moveXm = 0;
        const int moveYp = 0;
        const int moveYm = 0;

        public ManualControl()
        {
            InitializeComponent();
        }

        private void delay(int delayTime){
            Stopwatch sw;
            sw = Stopwatch.StartNew();
            int i = 0;

            while (sw.ElapsedMilliseconds <= delayTime) { };
            sw.Stop();
        }

        private void buttonYm_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBox_QuickMode.Checked == false){
                Main.mainSerialPort.WriteLine(numericUpDown.Value.ToString());
            }else{
                if (e.Button == MouseButtons.Left){
                    Main.mainSerialPort.Write(moveYp.ToString());
                    delay(50);
                    Main.mainSerialPort.Write("0");
                }
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Main.mainSerialPort.WriteLine(numericUpDown.Value.ToString());
        }

        int hodnota = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hodnota == 0) { hodnota = 20; } else { hodnota = 0; };
            Main.mainSerialPort.WriteLine(hodnota.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
