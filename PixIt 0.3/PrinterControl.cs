using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_0._3
{
    static class PrinterControl
    {
        public const int moveYup = 128 + 3;
        public const int moveYdown = 128 + 4;
        public const int moveXleft = 128 + 1;
        public const int moveXright = 128 + 2;
        public const int moveZup = 128 + 5;
        public const int moveZdown = 128 + 6;

        public const int penUp = 128 + 7;
        public const int penDown = 128 + 8;

        public const int drillOnRight = 128 + 9;
        public const int drillOnLeft = 128 + 10;
        public const int drillOff = 128 + 11;
        public const int drillXDefPos = 45;
        public const int drillYDefPos = 36;

        public const int penXDefPos = 86;
        public const int penYDefPos = 76;

        public const int releUp = 128 + 7;
        public const int releDown = 128 + 8;

        public const float xRadio = 2.12F;

        public static int posPenX = 0;
        public static int posPenY = 0;

        private static void serialSend(int valueSend)
        {
            try{
                formMain.mainSerialPort.Write(Convert.ToChar(valueSend).ToString());
            } catch (TimeoutException) { }
        }

        public static void defaultPosDrill()
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
            try
            {
                data = Convert.ToChar(formMain.mainSerialPort.ReadByte()).ToString();
            }
            catch (TimeoutException) { }
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

            //Posunutí
            for (int i = 1; i <= drillXDefPos; i++)
            {
                serialSend(moveXright);
                Thread.Sleep(1);
                serialSend(moveXright + 16);
                Thread.Sleep(1);
                serialSend(moveXright);
                Thread.Sleep(5);
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

            //Posunutí
            Thread.Sleep(2);
            for (int i = 0; i <= drillYDefPos; i++)
            {
                serialSend(moveYup);
                Thread.Sleep(1);
                serialSend(moveYup + 16);
                Thread.Sleep(1);
                serialSend(moveYup);
                Thread.Sleep(5);
            }
        }

        public static void defaultPosPen()
        {
            defaultPosDrill();

            //X
            for (int i = 0; i <= penXDefPos; i++) {
                serialSend(moveXright);
                Thread.Sleep(1);
                serialSend(moveXright + 16);
                Thread.Sleep(1);
                serialSend(moveXright);
                Thread.Sleep(5);
            }
            
            //Y
            for (int i = 0; i <= penYDefPos; i++) {
                serialSend(moveYup);
                Thread.Sleep(1);
                serialSend(moveYup + 16);
                Thread.Sleep(1);
                serialSend(moveYup);
                Thread.Sleep(5);
            }

            posPenX = 0;
            posPenY = 0;
        }

        public static void goToPoint(int x, int y)
        {
            int moveX = 0;
            int moveY = 0;

            if (posPenX != x || posPenY != y){
                //X+
                if (x > posPenX){
                    moveX = posPenX + x;

                    for (int i = 0; i <= moveX; i++){
                        serialSend(moveXright);
                        Thread.Sleep(1);
                        serialSend(moveXright + 16);
                        Thread.Sleep(1);
                        serialSend(moveXright);
                        Thread.Sleep(3);
                    }
                }

                //X-
                if (x < posPenX){
                    moveX = posPenX - x;

                    for (int i = 0; i <= moveX; i++){
                        serialSend(moveXleft);
                        Thread.Sleep(1);
                        serialSend(moveXleft + 16);
                        Thread.Sleep(1);
                        serialSend(moveXleft);
                        Thread.Sleep(3);
                    }
                }

                //Y+
                if (y > posPenX){
                    moveY = posPenY + y;

                    for (int i = 0; i <= moveY; i++)
                    {
                        serialSend(moveYup);
                        Thread.Sleep(1);
                        serialSend(moveYup + 16);
                        Thread.Sleep(1);
                        serialSend(moveYup);
                        Thread.Sleep(3);
                    }
                }

                //Y-
                if (y < posPenX){
                    moveY = posPenY - y;

                    for (int i = 0; i <= moveY; i++){
                        serialSend(moveYdown);
                        Thread.Sleep(1);
                        serialSend(moveYdown + 16);
                        Thread.Sleep(1);
                        serialSend(moveYdown);
                        Thread.Sleep(3);
                    }
                }

                posPenX = x;
                posPenY = y;
            }

        }
    }
}
