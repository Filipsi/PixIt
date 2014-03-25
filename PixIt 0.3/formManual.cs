using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PixIt_0._3
{
    public partial class formManual : Form
    {
        const int moveXp = 0;
        const int moveXm = 0;
        const int moveYp = 0;
        const int moveYm = 0;              

        public formManual()
        {
            InitializeComponent();
            formMain.debugResult = 12;
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

    }
}
