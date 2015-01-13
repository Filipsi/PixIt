using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Microsoft.Win32;

namespace PixIt_0._3 {

    static class Tcp {
        private static TcpClient client;
        private static byte[] byteBuffer = new byte[5120];

        public static void Connect(string _ip, int _port){
            try{
                client = new TcpClient();
                client.Connect(_ip, _port);
            } catch(Exception ex) {
                Program.ShowMessageForm(ex.Source, ex.Message);
                client = null;
            }
        }

        public static void Disconnect() {
            if(client != null) {
                client.GetStream().Close();
                client.Close();
                client = null;
            }
        }

        public static bool IsConnected() {
            if (client == null) {
                return false;
            } else {
                return client.Connected;
            }
        }

        public static void StartListening() {
            if (client != null) {
                client.Client.BeginReceive(byteBuffer, 0, byteBuffer.Length, SocketFlags.None, OnDataReceivedCallback, client);
            }
        }

        private static void OnDataReceivedCallback(IAsyncResult ar) {
            try {
                client.Client.EndReceive(ar);

                string decodedData = Encoding.ASCII.GetString(byteBuffer);
                Program.Form.Invoke((MethodInvoker)delegate {
                    Program.DebugAddLine(decodedData);
                });

                ProcessData(decodedData);

                byteBuffer = new byte[5120];
                client.Client.BeginReceive(byteBuffer, 0, byteBuffer.Length, SocketFlags.None, OnDataReceivedCallback, client);
            } catch(Exception ex) {
                if(client != null) {
                    Program.Form.Invoke((MethodInvoker)delegate {
                        Program.ShowMessageForm(ex.Source, ex.Message);
                    });
                }
            }
         }

        public static void Send(string _data) {
            if (client != null) {
                client.Client.Send(Encoding.ASCII.GetBytes(_data));
            }
        }

        private static void ProcessData(string _data) {
            if(_data.Contains("A")) {
                PrinterQuery.TriggerCommandCompleteEvent();
                string command = PrinterQuery.GetCommand();
                if(command != "") {
                    Thread.Sleep(5);
                    Send(command);
                }
            }

        }

    }

}
