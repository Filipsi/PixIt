using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_0._3 {

    static class Serial{
        
        private static SerialPort MainSerialPort = new SerialPort();

        public static string[] GetComPorts() {
            return SerialPort.GetPortNames();
        }

        public static void Init(string _PortName, int _BoundRate) {
            MainSerialPort.PortName = _PortName;
            MainSerialPort.BaudRate = _BoundRate;
            MainSerialPort.DataBits = 8;
            MainSerialPort.Parity = Parity.None;
            MainSerialPort.Handshake = Handshake.None;
            MainSerialPort.StopBits = StopBits.One;
            MainSerialPort.Encoding = Encoding.GetEncoding(28591);
            MainSerialPort.DtrEnable = true;
            MainSerialPort.RtsEnable = true;

            MainSerialPort.DataReceived += (sender, e) => {
                string data = MainSerialPort.ReadLine();
                Program.DebugAddLine("Přijatá data: " + data);

                if(data.Contains("A")) {
                    PrinterQuery.TriggerCommandCompleteEvent();
                    string command = PrinterQuery.GetCommand();
                    if(command != ""){
                        Thread.Sleep(5);
                        Send(command);
                    }
                }
            };

            try {
                MainSerialPort.Open();
            } catch (Exception ex) {
                Program.ShowMessageForm("Chyba při otevření portu", ex.Message.ToString());
                Program.DebugAddLine("Chyba při otevření portu: " + ex.Message.ToString());
            }
        }

        public static void Send(string _data) {
            MainSerialPort.Write(_data);
        }

        public static string Read() {
            return MainSerialPort.ReadLine();
        }

        public static bool IsOpen() {
            return MainSerialPort.IsOpen;
        }

        public static void Close() {
            MainSerialPort.Close();
        }

        public static void Dispose() {
            MainSerialPort.Dispose();
        }
    }
}
