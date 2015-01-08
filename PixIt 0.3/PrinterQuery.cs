using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_0._3 {

    static class PrinterQuery {
        
        private static List<string> ListCommands = new List<string>();
        public static event EventHandler WaitForCommandComplete = delegate { };

        public static void AddCommand(string _command) {
            ListCommands.Add(_command);
            //Program.Form.listBoxCommands.Items.Add(_command);
        }

        public static void TriggerCommandCompleteEvent() {
            WaitForCommandComplete(null, new EventArgs());
        }

        public static string GetCommand() {
            if(ListCommands.Count > 0){
                string command = "";
                foreach(string s in ListCommands) {
                    command = s;
                    break;
                }

                ListCommands.RemoveAt(0);
                Program.Form.debugAddLine("Příkaz pro tiskárnu: " + command);
                /*
                if(Program.Form.listBoxCommands.InvokeRequired) {
                    Program.Form.listBoxCommands.Invoke((MethodInvoker)delegate {
                        Program.Form.listBoxCommands.SelectedIndex++;
                    });
                } else {
                    Program.Form.listBoxCommands.SelectedIndex++;
                }*/

                if(PrinterControl.PrinterDebugMode) { Thread.Sleep(1000); }
                return command;
            } else {
                return "";
            }
        }

        public static void StartSerial() {
            //Program.Form.tabControl.SelectedIndex = 3;
            //Program.Form.listBoxCommands.SelectedIndex = 0;
            Serial.Send(GetCommand());
        }

        public static void StartTcp() {
            //Program.Form.tabControl.SelectedIndex = 3;
            //Program.Form.listBoxCommands.SelectedIndex = 0;
            Tcp.Send(GetCommand());
        }

    }
}
