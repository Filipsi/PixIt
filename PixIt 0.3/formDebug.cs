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

namespace PixIt_0._3
{
    public partial class formDebug : Form
    {
        public void addLineDebug(string text){
            if (listBoxDebug.InvokeRequired) {
                listBoxDebug.Invoke((MethodInvoker) delegate {
                    AddLine(text);
                });
            } else {
                AddLine(text);
            }

        }

        private void AddLine(string _text) {
            listBoxDebug.Items.Add(_text);
            listBoxDebug.SelectedIndex = listBoxDebug.Items.Count - 1;
        }

        public formDebug()
        {
            InitializeComponent();
            listBoxDebug.Items.Add("Debug byl úspěšně načten");
            listBoxDebug.Items.Add("Barva cest: " + formMain.colorPath);
            listBoxDebug.Items.Add("Barva vrtání: " + formMain.colorDrill);
            listBoxDebug.Items.Add("Barva Přechodu: " + formMain.colorTranslation);
            listBoxDebug.Items.Add("Číslo portu: " + formMain.numPort);
            this.TopMost = true;
            this.Focus();
            this.BringToFront();
        }
 
    }
}
