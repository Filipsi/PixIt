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
        
        /*
        private void delay(int delayTime)
        {
            Stopwatch sw;
            sw = Stopwatch.StartNew();

            while (sw.ElapsedMilliseconds <= delayTime) { };
            sw.Stop();
        }*/

        private void serialSend(int valueSend)
        {
            /*
            var encoding = Encoding.Unicode;
            byte[] encodeBytes = encoding.GetBytes(Convert.ToChar(valueSend).ToString());
            formMain.mainSerialPort.Write(encodeBytes, 0, 1);
            */

            try{
                formMain.mainSerialPort.Write(Convert.ToChar(valueSend).ToString());
            } catch (TimeoutException) { }
            
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
                for (int i = 0; i < numericUpDownFastModeBurst.Value; i++)
                {
                    serialSend(PrinterControl.moveYup);
                    Thread.Sleep(1);
                    serialSend(PrinterControl.moveYup + 16);
                    Thread.Sleep(1);
                    serialSend(PrinterControl.moveYup);
                    numericUpDown2.Value++;
                }
            }
        }

        private void buttonDOWN_Click(object sender, EventArgs e)
        {
            if(checkBoxFastMode.Checked == false){
                for (int i = 0; i < numericUpDownFastModeBurst.Value; i++)
                {
                    serialSend(PrinterControl.moveYdown);
                    Thread.Sleep(1);
                    serialSend(PrinterControl.moveYdown + 16);
                    Thread.Sleep(1);
                    serialSend(PrinterControl.moveYdown);
                }
            }
        }

        private void buttonZup_Click(object sender, EventArgs e)
        {
            if (checkBoxFastMode.Checked == false){
                serialSend(PrinterControl.moveZup);
                Thread.Sleep(3);
                serialSend(PrinterControl.moveZup + 16);
                Thread.Sleep(3);
                serialSend(PrinterControl.moveZup);
            }
        }

        private void buttonZdown_Click(object sender, EventArgs e)
        {
            string data;
            bool retVal;

            if (checkBoxFastMode.Checked == false){
                Thread.Sleep(2);

                serialSend(PrinterControl.moveZdown + 16 + 32);

                formMain.mainSerialPort.DiscardInBuffer();
                data = "";
                try{
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                serialSend(PrinterControl.moveZdown);

                if (retVal == true)
                {
                    for (int i = 0; i <= 40; i++)
                    {
                        serialSend(PrinterControl.moveZup);
                        Thread.Sleep(1);
                        serialSend(PrinterControl.moveZup + 16);
                        serialSend(PrinterControl.moveZup);
                    }
                }
            }
        }

        private void buttonDrillOnLeft_Click(object sender, EventArgs e)
        {
            int delay = 1;
            serialSend(PrinterControl.drillOnLeft);
            Thread.Sleep(delay);
            serialSend(PrinterControl.drillOnLeft + 16);
            Thread.Sleep(delay);
            serialSend(PrinterControl.drillOnLeft);
        }

        private void buttonDrillOnRight_Click(object sender, EventArgs e)
        {
            int delay = 1;
            serialSend(PrinterControl.drillOnRight);
            Thread.Sleep(delay);
            serialSend(PrinterControl.drillOnRight + 16);
            Thread.Sleep(delay);
            serialSend(PrinterControl.drillOnRight);
        }

        private void buttonDrillOff_Click(object sender, EventArgs e)
        {
            int delay = 1;
            serialSend(PrinterControl.drillOff);
            Thread.Sleep(delay);
            serialSend(PrinterControl.drillOff + 16);
            Thread.Sleep(delay);
            serialSend(PrinterControl.drillOff);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            buttTestState.Text = getSenstorState(int.Parse(textBoxTestStateVal.Text)).ToString();
        }

        private void buttonPenUp_Click(object sender, EventArgs e)
        {
            int delay = 1;
            serialSend(PrinterControl.penUp);
            Thread.Sleep(delay);
            serialSend(PrinterControl.penUp + 16);
            Thread.Sleep(delay);
            serialSend(PrinterControl.penUp);
        }

        private void buttonPenDown_Click(object sender, EventArgs e)
        {
            int delay = 1;
            serialSend(PrinterControl.penDown);
            Thread.Sleep(delay);
            serialSend(PrinterControl.penDown + 16);
            Thread.Sleep(delay);
            serialSend(PrinterControl.penDown);
        }

        private void buttonLEFT_MouseDown(object sender, MouseEventArgs e)
        {
            bool retVal;
            ButtonXLeftIsCLecked = true;

            if (checkBoxFastMode.Checked == true)
            {
                serialSend(PrinterControl.moveXleft);
                Application.DoEvents();
                Thread.Sleep(10);
                serialSend(PrinterControl.moveXleft + 32);

                formMain.mainSerialPort.DiscardInBuffer();
                string data = "";
                try{
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                serialSend(PrinterControl.moveXleft);

                while (ButtonXLeftIsCLecked == true && retVal == false)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);

                    serialSend(PrinterControl.moveXleft + 16 + 32);

                    formMain.mainSerialPort.DiscardInBuffer();
                    data = "";
                    try{
                        data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                    }catch (TimeoutException) { }
                    if (data == "@") { retVal = true; } else { retVal = false; }

                    serialSend(PrinterControl.moveXleft);
                    formMain.mainSerialPort.DiscardInBuffer();
                }

                
            }
        }

        private void buttonLEFT_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonXLeftIsCLecked = false;
            serialSend(PrinterControl.moveXleft);
        }

        private void buttonRIGHT_MouseDown(object sender, MouseEventArgs e)
        {
            bool retVal;
            ButtonXRightIsCLecked = true;

            if (checkBoxFastMode.Checked == true)
            {
                serialSend(PrinterControl.moveXright);
                Application.DoEvents();
                Thread.Sleep(10);
                serialSend(PrinterControl.moveXright + 32);

                formMain.mainSerialPort.DiscardInBuffer();
                string data = "";
                try{
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                serialSend(PrinterControl.moveXright);

                while (ButtonXRightIsCLecked == true && retVal == false)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);

                    serialSend(PrinterControl.moveXright + 16 + 32);

                    formMain.mainSerialPort.DiscardInBuffer();
                    data = "";
                    try{
                        data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                    } catch (TimeoutException) { }
                    if (data == "@") { retVal = true; } else { retVal = false; }

                    serialSend(PrinterControl.moveXright);
                    formMain.mainSerialPort.DiscardInBuffer();
                }

                
            }
        }

        private void buttonRIGHT_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonXRightIsCLecked = false;
            serialSend(PrinterControl.moveXright);
        }

        private void buttonDefValXYZ_Click(object sender, EventArgs e)
        {
            PrinterControl.posPenX = 0;
            PrinterControl.posPenY = 0;
            PrinterControl.defaultPosDrill();
        }

        private void buttonLEFT_Click(object sender, EventArgs e)
        {
            if (checkBoxFastMode.Checked == false){
                for (int i = 1; i <= numericUpDownFastModeBurst.Value; i++)
                {
                    int delay = 1;
                    serialSend(PrinterControl.moveXleft);
                    Thread.Sleep(delay);
                    serialSend(PrinterControl.moveXleft + 16);
                    Thread.Sleep(delay);
                    serialSend(PrinterControl.moveXleft);
                }
            }
        }

        private void buttonRIGHT_Click(object sender, EventArgs e)
        {
            if (checkBoxFastMode.Checked == false)
            {
                for (int i = 0; i < numericUpDownFastModeBurst.Value; i++)
                {
                    int delay = 1;
                    serialSend(PrinterControl.moveXright);
                    Thread.Sleep(delay);
                    serialSend(PrinterControl.moveXright + 16);
                    Thread.Sleep(delay);
                    serialSend(PrinterControl.moveXright);
                }
            }
        }

        private void buttonZup_MouseDown(object sender, MouseEventArgs e)
        {
            bool retVal;
            ButtonDrillUpIsCLecked = true;

            if (checkBoxFastMode.Checked == true)
            {
                serialSend(PrinterControl.moveZup);
                Application.DoEvents();
                Thread.Sleep(10);
                serialSend(PrinterControl.moveZup + 32);

                formMain.mainSerialPort.DiscardInBuffer();
                string data = "";
                try{
                    data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                }catch (TimeoutException) { }
                if (data == "@") { retVal = true; } else { retVal = false; }

                serialSend(PrinterControl.moveZup);

                while (ButtonDrillUpIsCLecked == true && retVal == false)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);

                    serialSend(PrinterControl.moveZup + 16 + 32);

                    formMain.mainSerialPort.DiscardInBuffer();
                    data = "";
                    try{
                        data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                    }catch (TimeoutException) { }
                    if (data == "@") { retVal = true; } else { retVal = false; }

                    serialSend(PrinterControl.moveZup);

                    formMain.mainSerialPort.DiscardInBuffer();
                }
            }
        }

        private void buttonZup_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonDrillUpIsCLecked = false;
            serialSend(PrinterControl.moveZup);
        }

        private void buttonZdown_MouseDown(object sender, MouseEventArgs e)
        {
            bool retVal;
            ButtonDrillDownIsCLecked = true;

            if (checkBoxFastMode.Checked == true)
            {
                serialSend(PrinterControl.moveZdown);
                Application.DoEvents();
                Thread.Sleep(10);

                serialSend(PrinterControl.moveZdown + 32);

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

                    serialSend(PrinterControl.moveZdown + 16 + 32);

                    formMain.mainSerialPort.DiscardInBuffer();
                    data = "";
                    try{
                        data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                    }catch (TimeoutException) { }
                    if (data == "@") { retVal = true; }else{ retVal = false; }

                    serialSend(PrinterControl.moveZdown);
                    formMain.mainSerialPort.DiscardInBuffer();

                    if (retVal == true){
                        for (int i = 0; i <= 40; i++){
                            serialSend(PrinterControl.moveZup);
                            Thread.Sleep(1);
                            serialSend(PrinterControl.moveZup + 16);
                            serialSend(PrinterControl.moveZup);
                        }
                    }

                }

            }
        }

        private void buttonZdown_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonDrillDownIsCLecked = false;
            serialSend(PrinterControl.moveZdown);
        }

        private void buttonUP_MouseDown(object sender, MouseEventArgs e)
        {
            bool retVal;
            ButtonYUpIsCLecked = true;

            if (checkBoxFastMode.Checked == true)
            {
                serialSend(PrinterControl.moveYup);
                Application.DoEvents();
                Thread.Sleep(10);
                serialSend(PrinterControl.moveYup + 32);

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

                    serialSend(PrinterControl.moveYup + 16 + 32);

                    formMain.mainSerialPort.DiscardInBuffer();
                    data = "";
                    try
                    {
                        data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                    }
                    catch (TimeoutException) { }
                    if (data == "@") { retVal = true; } else { retVal = false; }

                    serialSend(PrinterControl.moveYup);

                    formMain.mainSerialPort.DiscardInBuffer();
                }
            }
        }

        private void buttonUP_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonYUpIsCLecked = false;
            serialSend(PrinterControl.moveYup);
        }

        private void buttonDOWN_MouseDown(object sender, MouseEventArgs e)
        {
            bool retVal;
            ButtonYDownIsCLecked = true;

            if (checkBoxFastMode.Checked == true)
            {
                serialSend(PrinterControl.moveYdown);
                Application.DoEvents();
                Thread.Sleep(10);
                serialSend(PrinterControl.moveYdown + 32);

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

                    serialSend(PrinterControl.moveYdown + 16 + 32);

                    formMain.mainSerialPort.DiscardInBuffer();
                    data = "";
                    try
                    {
                        data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
                    }
                    catch (TimeoutException) { }
                    if (data == "@") { retVal = true; } else { retVal = false; }

                    serialSend(PrinterControl.moveYdown);

                    formMain.mainSerialPort.DiscardInBuffer();
                }
            }
        }

        private void buttonDOWN_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonYDownIsCLecked = false;
            serialSend(PrinterControl.moveYdown);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PrinterControl.posPenX = 0;
            PrinterControl.posPenY = 0;
            PrinterControl.defaultPosPen();
        }

    }

}
