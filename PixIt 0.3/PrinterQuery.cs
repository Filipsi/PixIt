using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_0._3 {

    static class PrinterQuery {
        
        private static List<string> ListCommands = new List<string>();

        public static void AddCommand(string _command) {
            ListCommands.Add(_command);
        }

        public static string GetCommand() {
            if(ListCommands.Count > 0){
                string command = "";
                foreach(string s in ListCommands) {
                    command = s;
                    break;
                }

                ListCommands.RemoveAt(0);
                return command;
            } else {
                return "";
            }
        }

        public static void Start() {
            Serial.Send(GetCommand());
        }

    }
}
