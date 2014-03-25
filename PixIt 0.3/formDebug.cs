using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            timerDebugResult.Start();
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
        private void timerDebugResult_Tick(object sender, EventArgs e)
        {
            if (formMain.debugResult != 0)
            {
                switch (formMain.debugResult)
                {
                    case 1: listBoxDebug.Items.Add("Chyba při otevření portu: " + formMain.errorNumber); break;
                    case 2: listBoxDebug.Items.Add("Port byl otevřen"); break;
                    case 3: listBoxDebug.Items.Add("Chyba při uzavření portu" + formMain.errorNumber); break;
                    case 4: listBoxDebug.Items.Add("Port byl uzavřen"); break;
                    case 5: listBoxDebug.Items.Add("Barva cesty změněna na: " + formMain.colorPath); break;
                    case 6: listBoxDebug.Items.Add("Barva vrtání změněna na: " + formMain.colorDrill); break;
                    case 7: listBoxDebug.Items.Add("Barva přechodu změněna na: " + formMain.colorTranslation); break;
                    case 8: listBoxDebug.Items.Add("Číslo portu změněno na: " + formMain.numPort); break;
                    case 9: listBoxDebug.Items.Add("Bylo otevřeno okno nastavení"); break;
                    case 10: listBoxDebug.Items.Add("Okno nastavení bylo uzavřeno"); break;
                    case 11: listBoxDebug.Items.Add("Byl načten obrázek - " + formMain.errorNumber); break;
                    case 12: listBoxDebug.Items.Add("Manuální ovládání bylo otevřeno"); break;
                    case 13: listBoxDebug.Items.Add("Manuální ovládání bylo uzavřeno"); break;
                }
                formMain.debugResult = 0;
            }          
            
        }
        
    }
}
