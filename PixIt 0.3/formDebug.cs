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
        public formDebug()
        {
            InitializeComponent();
            formMain.mainSerialPort.DataReceived += DataReceived_Read;
            listBoxDebug.Items.Add("Debug byl úspěšně načten");
            listBoxDebug.Items.Add("Barva cest: " + formMain.colorPath);
            listBoxDebug.Items.Add("Barva vrtání: " + formMain.colorDrill);
            listBoxDebug.Items.Add("Barva Přechodu: " + formMain.colorTranslation);
            listBoxDebug.Items.Add("Číslo portu: " + formMain.numPort);
            this.TopMost = true;
            this.Focus();
            this.BringToFront();
        }
        private void DataReceived_Read(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort mySerial = (SerialPort)sender;

            if (this.InvokeRequired)
            {
                listBoxSerialPort.BeginInvoke(new MethodInvoker(delegate
                {
                    listBoxSerialPort.Items.Add(mySerial.ReadExisting());
                    listBoxSerialPort.SelectedIndex = listBoxSerialPort.Items.Count - 1;
                }));
            }
        }

        private void formDebug_Load(object sender, EventArgs e)
        {

        }
       
    }
}
