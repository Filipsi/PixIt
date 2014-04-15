using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_0._3
{
    public partial class formManual : Form
    {
        const int moveXp = 0;
        const int moveXm = 0;
        const int moveYp = 0;
        const int moveYm = 0;

        int valSaved = 0;

        public void debugAddLine(string text)
        {
            if (System.Windows.Forms.Application.OpenForms["formDebug"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["formDebug"] as formDebug).addLineDebug(text);
            }
        }

        public formManual()
        {
            InitializeComponent();
            debugAddLine("Manuální ovládání bylo otevřeno");
        }
        
        private void delay(int delayTime)
        {
            Stopwatch sw;
            sw = Stopwatch.StartNew();

            while (sw.ElapsedMilliseconds <= delayTime) { };
            sw.Stop();
        }

        private void buttonUP_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            formMain.mainSerialPort.Write(Convert.ToChar(Convert.ToInt32(numericUpDown1.Value)).ToString());
            debugAddLine(Convert.ToChar(Convert.ToInt32(numericUpDown1.Value)).ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == true) { timer2.Enabled = false; } else { timer2.Enabled = true; }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != numericUpDown3.Value) { valSaved = Convert.ToInt32(numericUpDown1.Value); ; numericUpDown1.Value = numericUpDown3.Value; } else { numericUpDown1.Value = valSaved; }
            
        }

        private void formManual_Load(object sender, EventArgs e)
        {

        }

    }
}
