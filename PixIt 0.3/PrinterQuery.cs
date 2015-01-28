using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_0._3 {

    class CommandEventArgs : EventArgs {

        public string command { get; private set; }
        public int commandCount { get; private set; }
        public int commandCountTotal { get; private set; }

        public CommandEventArgs(string _command, int _commandCount, int _commandCountTotal) {
            command = _command;
            commandCount = _commandCount;
            commandCountTotal = _commandCountTotal;
        }

    }

    static class PrinterQuery {
        
        private static List<string> ListCommands = new List<string>();
        public static event EventHandler<CommandEventArgs> OnCommandCompleted = delegate { };
        public static event EventHandler<CommandEventArgs> OnCommandExecuted = delegate { };
        private static int CommandCount = 0;
        private static bool IsInUse = false;
        private static bool StopExecution = false;

        public static void AddCommand(string _command) {
            ListCommands.Add(_command);
        }

        public static void TriggerCommandCompleteEvent() {
            OnCommandCompleted(null, new CommandEventArgs("", ListCommands.Count, CommandCount));
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

                if(PrinterControl.PrinterDebugMode) { Thread.Sleep(1000); }
                if(StopExecution) { StopExecution = false; return ""; }
                OnCommandExecuted(null, new CommandEventArgs(command, ListCommands.Count, CommandCount));

                return command;
            } else {
                IsInUse = false;
                return ""; 
            }
        }

        public static void ClearQuery() {
            ListCommands.Clear();
            CommandCount = ListCommands.Count;
            IsInUse = false;
        }

        public static bool IsRunning() {
            return IsInUse;
        }

        public static void StartSerial() {
            if(!IsInUse) {
                CommandCount = ListCommands.Count;
                IsInUse = true;
                Serial.Send(GetCommand());
            }
        }

        public static void StartTcp() {
            if(!IsInUse) {
                CommandCount = ListCommands.Count;
                IsInUse = true;
                Tcp.Send(GetCommand());
            }
        }

    }
}
