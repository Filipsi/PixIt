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
        const int moveYleft = 128 + 3;
        const int moveYright = 128 + 4;
        const int moveXleft = 128 + 1;
        const int moveXright = 128 + 2;
        const int moveZup = 128 + 5;
        const int moveZdown = 128 + 6;
        const int penUp = 128 + 7;
        const int penDown = 128 + 8;
        const int drillOnRight = 128 + 9;
        const int drillOnLeft = 128 + 10;
        const int drillOff = 128 + 11;


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

        private void serialSend(int valueSend)
        {
            /*
            var encoding = Encoding.Unicode;
            byte[] encodeBytes = encoding.GetBytes(Convert.ToChar(valueSend).ToString());
            formMain.mainSerialPort.Write(encodeBytes, 0, 1);
            */

            formMain.mainSerialPort.Write(Convert.ToChar(valueSend).ToString());
        }

        private void buttonSerialSend_Click(object sender, EventArgs e)
        {
            serialSend(Convert.ToInt32(textBoxSerialSendData.Text));
        }

        private bool getSenstorState(int senstorID)
        {
            bool retVal;

            formMain.mainSerialPort.Write(Convert.ToChar(senstorID).ToString());
            string data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
            if (data == "@") { retVal = true; } else { retVal = false; }
            formMain.mainSerialPort.Write(Convert.ToChar(senstorID-32).ToString());

            formMain.mainSerialPort.DiscardInBuffer();
            debugAddLine(data);

            return retVal;
        }

        private void buttonUP_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                serialSend(moveYleft);
                Thread.Sleep(1);
                serialSend(moveYleft + 16);
                Thread.Sleep(1);
                serialSend(moveYleft);
            }
        }

        private void buttonDOWN_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                serialSend(moveYright);
                Thread.Sleep(1);
                serialSend(moveYright + 16);
                Thread.Sleep(1);
                serialSend(moveYright);
            }
        }

        private void buttonLEFT_Click(object sender, EventArgs e)
        {
            int delay = 3;
            for (int i = 0; i <= 50; i++)
            {
                serialSend(moveXleft);
                Thread.Sleep(delay);
                serialSend(moveXleft+ 16);
                Thread.Sleep(delay);
                serialSend(moveXleft);
            }
        }

        private void buttonRIGHT_Click(object sender, EventArgs e)
        {
            int delay = 3;
            for (int i = 0; i <= 50; i++)
            {
                serialSend(moveXright);
                Thread.Sleep(delay);
                serialSend(moveXright + 16);
                Thread.Sleep(delay);
                serialSend(moveXright);
            }
        }

        private void buttonZup_Click(object sender, EventArgs e)
        {
            bool a = false;

            while (a == false)
            {
                a = getSenstorState(165);
                Thread.Sleep(10);
                buttonZup.Text = a.ToString();
                serialSend(moveZup);
                Thread.Sleep(500);
                serialSend(moveZup + 16);
                Thread.Sleep(500);
                serialSend(moveZup);
            }

        }




        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = getSenstorState(165).ToString();
        }

    }

    
}
