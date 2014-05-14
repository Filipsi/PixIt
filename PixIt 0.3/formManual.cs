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
        const int moveYup = 128 + 3;
        const int moveYdown = 128 + 4;
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

        bool ButtonXLeftIsCLecked = false;
        bool ButtonXRightIsCLecked = false;
        bool ButtonDrillUpIsCLecked = false;
        bool ButtonDrillDownIsCLecked = false;
        bool ButtonYUpIsCLecked = false;
        bool ButtonYDownIsCLecked = false;


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
            if (checkBoxFastMode.Checked == false)
            {
                serialSend(moveYup);
                Thread.Sleep(1);
                serialSend(moveYup + 16);
                Thread.Sleep(1);
                serialSend(moveYup);
            }
        }

        private void buttonDOWN_Click(object sender, EventArgs e)
        {
            if(checkBoxFastMode.Checked == false){
                serialSend(moveYdown);
                Thread.Sleep(1);
                serialSend(moveYdown + 16);
                Thread.Sleep(1);
                serialSend(moveYdown);
            }
        }

        private void buttonZup_Click(object sender, EventArgs e)
        {
            if (checkBoxFastMode.Checked == false){
                serialSend(moveZup);
                Thread.Sleep(3);
                serialSend(moveZup + 16);
                Thread.Sleep(3);
                serialSend(moveZup);
            }
        }

        private void buttonZdown_Click(object sender, EventArgs e)
        {
            if (checkBoxFastMode.Checked == false){
                serialSend(moveZdown);
                Thread.Sleep(3);
                serialSend(moveZdown + 16);
                Thread.Sleep(3);
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
            ButtonXLeftIsCLecked = true;

            if (checkBoxFastMode.Checked == true)
            {
                serialSend(moveXleft);
                Application.DoEvents();
                Thread.Sleep(10);
                serialSend(moveXleft + 32);

                formMain.mainSerialPort.DiscardInBuffer();
                string data = "";
                try{
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                serialSend(moveXleft);

                while (ButtonXLeftIsCLecked == true && retVal == false)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);

                    serialSend(moveXleft + 16 + 32);

                    formMain.mainSerialPort.DiscardInBuffer();
                    data = "";
                    try{
                        data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                    }catch (TimeoutException) { }
                    if (data == "@") { retVal = true; } else { retVal = false; }

                    serialSend(moveXleft);
                    formMain.mainSerialPort.DiscardInBuffer();
                }

                
            }
        }

        private void buttonLEFT_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonXLeftIsCLecked = false;
            serialSend(moveXleft);
        }

        private void buttonRIGHT_MouseDown(object sender, MouseEventArgs e)
        {
            bool retVal;
            ButtonXRightIsCLecked = true;

            if (checkBoxFastMode.Checked == true)
            {
                serialSend(moveXright);
                Application.DoEvents();
                Thread.Sleep(10);
                serialSend(moveXright + 32);

                formMain.mainSerialPort.DiscardInBuffer();
                string data = "";
                try{
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                serialSend(moveXright);

                while (ButtonXRightIsCLecked == true && retVal == false)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);

                    serialSend(moveXright + 16 + 32);

                    formMain.mainSerialPort.DiscardInBuffer();
                    data = "";
                    try{
                        data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                    } catch (TimeoutException) { }
                    if (data == "@") { retVal = true; } else { retVal = false; }

                    serialSend(moveXright);
                    formMain.mainSerialPort.DiscardInBuffer();
                }

                
            }
        }

        private void buttonRIGHT_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonXRightIsCLecked = false;
            serialSend(moveXright);
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
            serialSend(moveYdown);
            Application.DoEvents();
            Thread.Sleep(10);
            formMain.mainSerialPort.Write(Convert.ToChar(moveYdown + 32).ToString());

            formMain.mainSerialPort.DiscardInBuffer();
            data = "";
            try
            {
                data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
            }
            catch (TimeoutException) { }
            if (data == "@") { retVal = true; } else { retVal = false; }

            serialSend(moveYdown);


            while (retVal == false)
            {
                serialSend(moveYdown);
                Application.DoEvents();
                Thread.Sleep(10);

                formMain.mainSerialPort.Write(Convert.ToChar(moveYdown + 16 + 32).ToString());

                formMain.mainSerialPort.DiscardInBuffer();
                data = "";
                try
                {
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }
                catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                formMain.mainSerialPort.Write(Convert.ToChar(moveYdown).ToString());
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
            string data;
            numericUpDown1.Value = 0;

            if (checkBoxFastMode.Checked == false){

                serialSend(moveXleft);

                for (int i = 1; i <= numericUpDownFastModeBurst.Value; i++)
                {
                    Application.DoEvents();
                    Thread.Sleep(10);
                    serialSend(moveXleft + 32);

                    formMain.mainSerialPort.DiscardInBuffer();
                    data = "";
                    try{
                        data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                    }catch (TimeoutException) { }
                    if (data == "@") { serialSend(moveXleft); break; }

                    serialSend(moveXleft);
                    Thread.Sleep(1);
                    serialSend(moveXleft + 16);
                    Thread.Sleep(1);
                    serialSend(moveXleft);

                    numericUpDown1.Value = numericUpDown1.Value + 1;
                }
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

        private void buttonZup_MouseDown(object sender, MouseEventArgs e)
        {
            bool retVal;
            ButtonDrillUpIsCLecked = true;

            if (checkBoxFastMode.Checked == true)
            {
                serialSend(moveZup);
                Application.DoEvents();
                Thread.Sleep(10);
                serialSend(moveZup + 32);

                formMain.mainSerialPort.DiscardInBuffer();
                string data = "";
                try{
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                serialSend(moveZup);

                while (ButtonDrillUpIsCLecked == true && retVal == false)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);

                    serialSend(moveZup + 16 + 32);

                    formMain.mainSerialPort.DiscardInBuffer();
                    data = "";
                    try{
                        data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                    }catch (TimeoutException) { }
                    if (data == "@") { retVal = true; } else { retVal = false; }

                    serialSend(moveZup);

                    formMain.mainSerialPort.DiscardInBuffer();
                }
            }
        }

        private void buttonZup_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonDrillUpIsCLecked = false;
            serialSend(moveZup);
        }

        private void buttonZdown_MouseDown(object sender, MouseEventArgs e)
        {
            bool retVal;
            ButtonDrillDownIsCLecked = true;

            if (checkBoxFastMode.Checked == true)
            {
                serialSend(moveZdown);
                Application.DoEvents();
                Thread.Sleep(10);
                serialSend(moveZdown + 32);

                formMain.mainSerialPort.DiscardInBuffer();
                string data = "";
                try{
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                while (ButtonDrillDownIsCLecked == true && retVal == false)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);

                    serialSend(moveZdown + 16 + 32);

                    formMain.mainSerialPort.DiscardInBuffer();
                    data = "";
                    try{
                        data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                    }catch (TimeoutException) { }
                    if (data == "@") { retVal = true; } else { retVal = false; }

                    serialSend(moveZdown);

                    formMain.mainSerialPort.DiscardInBuffer();
                }
            }
        }

        private void buttonZdown_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonDrillDownIsCLecked = false;
            serialSend(moveZdown);
        }

        private void buttonUP_MouseDown(object sender, MouseEventArgs e)
        {
            bool retVal;
            ButtonYUpIsCLecked = true;

            if (checkBoxFastMode.Checked == true)
            {
                serialSend(moveYup);
                Application.DoEvents();
                Thread.Sleep(10);
                serialSend(moveYup + 32);

                formMain.mainSerialPort.DiscardInBuffer();
                string data = "";
                try
                {
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }
                catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                while (ButtonYUpIsCLecked == true && retVal == false)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);

                    serialSend(moveYup + 16 + 32);

                    formMain.mainSerialPort.DiscardInBuffer();
                    data = "";
                    try
                    {
                        data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                    }
                    catch (TimeoutException) { }
                    if (data == "@") { retVal = true; } else { retVal = false; }

                    serialSend(moveYup);

                    formMain.mainSerialPort.DiscardInBuffer();
                }
            }
        }

        private void buttonUP_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonYUpIsCLecked = false;
            serialSend(moveYup);
        }

        private void buttonDOWN_MouseDown(object sender, MouseEventArgs e)
        {
            bool retVal;
            ButtonYDownIsCLecked = true;

            if (checkBoxFastMode.Checked == true)
            {
                serialSend(moveYdown);
                Application.DoEvents();
                Thread.Sleep(10);
                serialSend(moveYdown + 32);

                formMain.mainSerialPort.DiscardInBuffer();
                string data = "";
                try
                {
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }
                catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                while (ButtonYDownIsCLecked == true && retVal == false)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);

                    serialSend(moveYdown + 16 + 32);

                    formMain.mainSerialPort.DiscardInBuffer();
                    data = "";
                    try
                    {
                        data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                    }
                    catch (TimeoutException) { }
                    if (data == "@") { retVal = true; } else { retVal = false; }

                    serialSend(moveYdown);

                    formMain.mainSerialPort.DiscardInBuffer();
                }
            }
        }

        private void buttonDOWN_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonYDownIsCLecked = false;
            serialSend(moveYdown);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttonDefValXYZ.PerformClick();

            for (int i = 1; i <= 100; i++){
                serialSend(moveXright);
                Thread.Sleep(1);
                serialSend(moveXright + 16);
                Thread.Sleep(1);
                serialSend(moveXright);
                Thread.Sleep(1);
            }
        }





    }

    
}
