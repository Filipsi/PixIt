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

        const int drillOnRight = 128  + 9;
        const int drillOnLeft = 128  + 10;
        const int drillOff = 128 + 11;
        const int drillXDefPos = 45;

        const int releUp = 128 + 7;
        const int releDown = 128 + 8;

        const float xRadio = 2.12F;

        bool ButtonLeftIsCLecked = false;
        bool ButtonRightIsCLecked = false;


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

            try
            {
                formMain.mainSerialPort.Write(Convert.ToChar(valueSend).ToString());
            }
            catch (TimeoutException) { }
            
        }

        private void buttonSerialSend_Click(object sender, EventArgs e)
        {
            serialSend(Convert.ToInt32(textBoxSerialSendData.Text));
        }

        private bool getSenstorState(int senstorID)
        {
            bool retVal;

            formMain.mainSerialPort.Write(Convert.ToChar(senstorID).ToString());

            formMain.mainSerialPort.DiscardInBuffer();
            string data = "";
            try{
                data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
            }catch (TimeoutException) { }
            if (data == "@") { retVal = true; } else { retVal = false; }

            formMain.mainSerialPort.Write(Convert.ToChar(senstorID - 32).ToString());

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

        private void buttonZup_Click(object sender, EventArgs e)
        {
            int delay = 3;
            for (int i = 0; i <= 0; i++)
            {
                serialSend(moveZup);
                Thread.Sleep(delay);
                serialSend(moveZup + 16);
                Thread.Sleep(delay);
                serialSend(moveZup);
            }
        }

        private void buttonZdown_Click(object sender, EventArgs e)
        {
            int delay = 3;
            for (int i = 0; i <= 2; i++)
            {
                serialSend(moveZdown);
                Thread.Sleep(delay);
                serialSend(moveZdown + 16);
                Thread.Sleep(delay);
                serialSend(moveZdown);
            }
        }

        private void buttonDrillOnLeft_Click(object sender, EventArgs e)
        {
            int delay = 1;
            serialSend(drillOnLeft);
            Thread.Sleep(delay);
            serialSend(drillOnLeft + 16);
            Thread.Sleep(delay);
            serialSend(drillOnLeft);
        }

        private void buttonDrillOnRight_Click(object sender, EventArgs e)
        {
            int delay = 1;
            serialSend(drillOnRight);
            Thread.Sleep(delay);
            serialSend(drillOnRight + 16);
            Thread.Sleep(delay);
            serialSend(drillOnRight);
        }

        private void buttonDrillOff_Click(object sender, EventArgs e)
        {
            int delay = 1;
            serialSend(drillOff);
            Thread.Sleep(delay);
            serialSend(drillOff + 16);
            Thread.Sleep(delay);
            serialSend(drillOff);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            buttTestState.Text = getSenstorState(int.Parse(textBoxTestStateVal.Text)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            int delay = 1;
            do{
                serialSend(moveXleft);
                Thread.Sleep(delay);
                //serialSend(moveXleft + 16 + 32);
                //Thread.Sleep(8);
            } while (getSenstorState(161 + 16) == false);
            
            serialSend(moveXleft);
            */

            bool retVal;

            do{
            serialSend(moveXleft);
            Thread.Sleep(10);

            
            formMain.mainSerialPort.Write(Convert.ToChar(177).ToString());

            formMain.mainSerialPort.DiscardInBuffer();
            string data = "";
            try
            {
                data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
            }
            catch (TimeoutException) { }
            if (data == "@") { retVal = true; } else { retVal = false; }

            formMain.mainSerialPort.Write(Convert.ToChar(129).ToString());

            formMain.mainSerialPort.DiscardInBuffer();
            
            } while (retVal == false);

        }

        private void buttonPenUp_Click(object sender, EventArgs e)
        {
            int delay = 1;
            serialSend(penUp);
            Thread.Sleep(delay);
            serialSend(penUp + 16);
            Thread.Sleep(delay);
            serialSend(penUp);
        }

        private void buttonPenDown_Click(object sender, EventArgs e)
        {
            int delay = 1;
            serialSend(penDown);
            Thread.Sleep(delay);
            serialSend(penDown + 16);
            Thread.Sleep(delay);
            serialSend(penDown);
        }

        private void buttonLEFT_MouseDown(object sender, MouseEventArgs e)
        {
            bool retVal;
            ButtonLeftIsCLecked = true;

            if (checkBoxFastMode.Checked == true)
            {
                serialSend(moveXleft);
                Application.DoEvents();
                Thread.Sleep(1);
                formMain.mainSerialPort.Write(Convert.ToChar(161).ToString());

                formMain.mainSerialPort.DiscardInBuffer();
                string data = "";
                try
                {
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }
                catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                serialSend(moveXleft);

                while (ButtonLeftIsCLecked == true && retVal == false)
                {
                    serialSend(moveXleft);
                    Application.DoEvents();
                    Thread.Sleep(10);

                    formMain.mainSerialPort.Write(Convert.ToChar(177).ToString());

                    formMain.mainSerialPort.DiscardInBuffer();
                    data = "";
                    try
                    {
                        data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                    }
                    catch (TimeoutException) { }
                    if (data == "@") { retVal = true; } else { retVal = false; }

                    formMain.mainSerialPort.Write(Convert.ToChar(129).ToString());

                    formMain.mainSerialPort.DiscardInBuffer();
                }
            }
        }

        private void buttonLEFT_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonLeftIsCLecked = false;
        }

        private void buttonRIGHT_MouseDown(object sender, MouseEventArgs e)
        {
            bool retVal;
            ButtonRightIsCLecked = true;

            if (checkBoxFastMode.Checked == true)
            {
                serialSend(moveXright);
                Application.DoEvents();
                Thread.Sleep(1);
                formMain.mainSerialPort.Write(Convert.ToChar(162).ToString());

                formMain.mainSerialPort.DiscardInBuffer();
                string data = "";
                try
                {
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }
                catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                serialSend(moveXright);

                while (ButtonRightIsCLecked == true && retVal == false)
                {
                    serialSend(moveXright);
                    Application.DoEvents();
                    Thread.Sleep(10);

                    formMain.mainSerialPort.Write(Convert.ToChar(moveXright + 16 + 32).ToString());

                    formMain.mainSerialPort.DiscardInBuffer();
                    data = "";
                    try
                    {
                        data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                    }
                    catch (TimeoutException) { }
                    if (data == "@") { retVal = true; } else { retVal = false; }

                    formMain.mainSerialPort.Write(Convert.ToChar(moveXright).ToString());

                    formMain.mainSerialPort.DiscardInBuffer();
                }
            }
        }

        private void buttonRIGHT_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonRightIsCLecked = false;
        }

        private void buttonDefValXYZ_Click(object sender, EventArgs e)
        {
            serialSend(drillOff);
            Thread.Sleep(1);
            serialSend(drillOff + 16);
            Thread.Sleep(1);
            serialSend(drillOff);
            Thread.Sleep(10);

            serialSend(penUp);
            Thread.Sleep(1);
            serialSend(penUp + 16);
            Thread.Sleep(1);
            serialSend(penUp);
            Thread.Sleep(10);

            bool retVal;

            //Zup
            serialSend(moveZup);
            Application.DoEvents();
            Thread.Sleep(10);
            formMain.mainSerialPort.Write(Convert.ToChar(moveZup + 32).ToString());

            formMain.mainSerialPort.DiscardInBuffer();
            string data = "";
            try{
                data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
            }catch (TimeoutException) { }
            if (data == "@") { retVal = true; } else { retVal = false; }

            serialSend(moveZup);


            while (retVal == false)
            {
                serialSend(moveZup);
                Application.DoEvents();
                Thread.Sleep(10);

                formMain.mainSerialPort.Write(Convert.ToChar(moveZup + 16 + 32).ToString());

                formMain.mainSerialPort.DiscardInBuffer();
                data = "";
                try
                {
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }
                catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                formMain.mainSerialPort.Write(Convert.ToChar(moveZup).ToString());
                formMain.mainSerialPort.DiscardInBuffer();
            }
            //----------------

            //X
            serialSend(moveXleft);
            Application.DoEvents();
            Thread.Sleep(10);
            formMain.mainSerialPort.Write(Convert.ToChar(moveXleft + 32).ToString());

            formMain.mainSerialPort.DiscardInBuffer();
            data = "";
            try
            {
                data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
            }
            catch (TimeoutException) { }
            if (data == "@") { retVal = true; } else { retVal = false; }

            serialSend(moveXleft);


            while (retVal == false)
            {
                serialSend(moveXleft);
                Application.DoEvents();
                Thread.Sleep(10);

                formMain.mainSerialPort.Write(Convert.ToChar(moveXleft + 16 + 32).ToString());

                formMain.mainSerialPort.DiscardInBuffer();
                data = "";
                try
                {
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }
                catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                formMain.mainSerialPort.Write(Convert.ToChar(moveXleft).ToString());
                formMain.mainSerialPort.DiscardInBuffer();
            }
            //---------------------

            //Y
            serialSend(moveYright);
            Application.DoEvents();
            Thread.Sleep(10);
            formMain.mainSerialPort.Write(Convert.ToChar(moveYright + 32).ToString());

            formMain.mainSerialPort.DiscardInBuffer();
            data = "";
            try
            {
                data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
            }
            catch (TimeoutException) { }
            if (data == "@") { retVal = true; } else { retVal = false; }

            serialSend(moveYright);


            while (retVal == false)
            {
                serialSend(moveYright);
                Application.DoEvents();
                Thread.Sleep(10);

                formMain.mainSerialPort.Write(Convert.ToChar(moveYright + 16 + 32).ToString());

                formMain.mainSerialPort.DiscardInBuffer();
                data = "";
                try
                {
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }
                catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                formMain.mainSerialPort.Write(Convert.ToChar(moveYright).ToString());
                formMain.mainSerialPort.DiscardInBuffer();
            }
            //---------------------

            for (int i = 1; i <= drillXDefPos; i++)
            {
                serialSend(moveXright);
                Thread.Sleep(1);
                serialSend(moveXright + 16);
                Thread.Sleep(1);
                serialSend(moveXright);
                Thread.Sleep(10);
            }

        }

        private void buttonLEFT_Click(object sender, EventArgs e)
        {
            if (checkBoxFastMode.Checked == false){
                int delay = 1;
                serialSend(moveXleft);
                Thread.Sleep(delay);
                serialSend(moveXleft + 16);
                Thread.Sleep(delay);
                serialSend(moveXleft);
            }
        }

        private void buttonRIGHT_Click(object sender, EventArgs e)
        {
            if (checkBoxFastMode.Checked == false)
            {
                int delay = 1;
                serialSend(moveXright);
                Thread.Sleep(delay);
                serialSend(moveXright + 16);
                Thread.Sleep(delay);
                serialSend(moveXright);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int moveMm = 100;

            for(int i = 1; i <= moveMm * xRadio; i++){
                int delay = 5;
                serialSend(moveXright);
                Thread.Sleep(delay);
                serialSend(moveXright + 16);
                Thread.Sleep(delay);
                serialSend(moveXright);
            }
        }





    }

    
}
