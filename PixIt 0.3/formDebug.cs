using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace PixIt_0._3 {

    public partial class formDebug : Form {

        public void AddLine(string _text) {
            if (listBoxDebug.InvokeRequired) {
                listBoxDebug.Invoke((MethodInvoker) delegate {
                    listBoxDebug.Items.Add(_text);
                    listBoxDebug.SelectedIndex = listBoxDebug.Items.Count - 1;
                });
            } else {
                listBoxDebug.Items.Add(_text);
                listBoxDebug.SelectedIndex = listBoxDebug.Items.Count - 1;
            }
        }

        public formDebug() {
            InitializeComponent();
            AddLine("Debug byl úspěšně načten");
            this.TopMost = true;
            this.Focus();
            this.BringToFront();
        }

        private void TextBoxCommandLine_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if(e.KeyCode == Keys.Return && TextBoxCommandLine.Text != "") {
                if(Serial.IsOpen()) {
                    Serial.Send(TextBoxCommandLine.Text);
                    AddLine("Příkaz '" + TextBoxCommandLine.Text + "' byl odeslán po sériové lince!");
                } else if(Tcp.IsConnected()) {
                    Tcp.Send(TextBoxCommandLine.Text);
                    AddLine("Příkaz '" + TextBoxCommandLine.Text + "' byl odeslán Tcp socketem!");
                } else {
                    AddLine("Příkaz '" + TextBoxCommandLine.Text + "' nebylo možné odeslat, Sériová linka ani Tcp socket není aktivní!");
                }

                TextBoxCommandLine.Text = "";
            }
        }
 
    }
}
