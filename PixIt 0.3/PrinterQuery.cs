using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_0._3 {

    class CommandEventArgs : EventArgs {

        public CommandEventArgs(string _command) {
            command = _command;
        }

        public string command { get; private set; }

    }

    static class PrinterQuery {
        
        private static List<string> ListCommands = new List<string>();
        public static event EventHandler OnCommandCompleted = delegate { };
        public static event EventHandler<CommandEventArgs> OnCommandExecuted = delegate { };
        private static int CommandCount = 0;
        private static bool InUse = false;
        private static bool StopExecution = false;

        public static void AddCommand(string _command) {
            ListCommands.Add(_command);
        }

        public static void TriggerCommandCompleteEvent() {
            OnCommandCompleted(null, new EventArgs());
        }

        public static int GetCompleteProcentage() {
            return 100 - (int)Math.Round((double)(CommandCount * ListCommands.Count) / 100);
        }

        public static void StopQuery() {
            StopExecution = true;
        }

        public static string GetCommand() {
            if(ListCommands.Count > 0) {
                string command = "";
                foreach(string s in ListCommands) {
                    command = s;
                    break;
                }

                ListCommands.RemoveAt(0);
                Program.DebugAddLine("Příkaz pro tiskárnu: " + command);
                OnCommandExecuted(null, new CommandEventArgs(command));

                if(PrinterControl.PrinterDebugMode) { Thread.Sleep(1000); }
                if(StopExecution) { StopExecution = false; return ""; }

                return command;
            } else {
                InUse = false;
                return ""; 
            }
        }

        public static void ClearQuery() {
            ListCommands.Clear();
            CommandCount = ListCommands.Count;
        }

        public static bool IsInUse() {
            return InUse;
        }

        public static void StartSerial() {
            if(!InUse) {
                CommandCount = ListCommands.Count;
                InUse = true;
                Serial.Send(GetCommand());
            }
        }

        public static void StartTcp() {
            if(!InUse) {
                CommandCount = ListCommands.Count;
                InUse = true;
                Tcp.Send(GetCommand());
            }
        }

    }
}
