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
            try {
                if(listBoxDebug.InvokeRequired) {
                    listBoxDebug.Invoke((MethodInvoker)delegate {
                        listBoxDebug.Items.Add(_text);
                        listBoxDebug.SelectedIndex = listBoxDebug.Items.Count - 1;
                    });
                } else {
                    listBoxDebug.Items.Add(_text);
                    listBoxDebug.SelectedIndex = listBoxDebug.Items.Count - 1;
                }
            } catch { }
        }

        public formDebug() {
            InitializeComponent();
            AddLine("Debug byl úspěšně načten");
            AddLine("Pro nápovědu napište ? do příkazové řádky");
            this.TopMost = true;
            this.Focus();
            this.BringToFront();
        }

        private void TextBoxCommandLine_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if(e.KeyCode == Keys.Return && TextBoxCommandLine.Text != "") {
                if(TextBoxCommandLine.Text == "?") {
                    PrintHelp();
                } else {
                    if(Serial.IsOpen()) {
                        Serial.Send(TextBoxCommandLine.Text);
                        AddLine("Příkaz '" + TextBoxCommandLine.Text + "' byl odeslán po sériové lince!");
                    } else if(Tcp.IsConnected()) {
                        Tcp.Send(TextBoxCommandLine.Text);
                        AddLine("Příkaz '" + TextBoxCommandLine.Text + "' byl odeslán Tcp socketem!");
                    } else {
                        AddLine("Příkaz '" + TextBoxCommandLine.Text + "' nebylo možné odeslat, Sériová linka ani Tcp socket není aktivní!");
                    }
                }

                TextBoxCommandLine.Text = "";
            }
        }

        private void PrintHelp() {
            AddLine("");
            AddLine("Move:");
            AddLine("MXL(kroky) - Posun doleva na ose X");
            AddLine("MXR(kroky) - Posun doprava na ose X");
            AddLine("MYU(kroky) - Posun nahoru na ose Y");
            AddLine("MYS(kroky) - Posun dolu na ose Y");
            AddLine("MZU(kroky) - Posun nahoru na ose Z");
            AddLine("MZS(kroky) - Posun dolu na ose Z");
            AddLine("");
            AddLine("Set:");
            AddLine("SPU - Nastavi tuzku do pozice nahore");
            AddLine("SPD - Nastavi tuzku do pozice dole");
            AddLine("SDL - Aktivuje vrtacku, vrtani vlevo");
            AddLine("SDR - Aktivuje vrtacku, vrtani vpravo");
            AddLine("SD0 - Vypne vrtacku");
            AddLine("SDU - Posune vrtacku do do vychozi pozice (nahoru)");
            AddLine("SDD - Vrtání, dokud vrtacka neprovrta desku, pote zdvih vrtacky");
            AddLine("SSX - Najdede na X ose na zacatek");
            AddLine("SSY - Najdede na Y ose na zacatek");
            AddLine("SEX - Najdede na X ose na konec");
            AddLine("SEY - Najdede na Y ose na konec");
            AddLine("");
            AddLine("Get:");
            AddLine("GS(senzor) - Ziska hodnotu senzoru");
            AddLine("GP(pin) - Ziska hodnotu na pinu");
            AddLine("GL - Ziska piny na kterych ma arduino vystup");
            AddLine("GV - Ziska logicke hodnoty ze všech pinu");
            AddLine("");
            AddLine("Write:");
            AddLine("WN(cislo) - Prevede cislo na binarni hodnotu, zapise na vytupy");
            AddLine("");
            AddLine("Display:");
            AddLine("DT(text) - Vypise text na displeji");
            AddLine("DS(x,y) - Nastavi pozici kurzoru na displeji");
            AddLine("DP(num1, num2) - Vypocita procenta, zobrazi progressbar na displeji");
            AddLine("DC - Vymaze displej");
        }

        private void listBoxDebug_DrawItem(object sender, DrawItemEventArgs e) {
            if((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, e.ForeColor, listBoxDebug.BackColor);
            }

            e.DrawBackground();
            e.Graphics.DrawString(listBoxDebug.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void timerPinControl_Tick(object sender, EventArgs e) {
            if(Serial.IsOpen() && labelStatus.ForeColor != Color.DarkGreen && labelStatus.ForeColor != Color.DarkOrange) {
                labelStatus.ForeColor = Color.DarkGreen;
                labelStatus.Text = "Arduino připojeno pomocí Sériové linky!";
            } else if(Tcp.IsConnected() && labelStatus.ForeColor != Color.DarkGreen && labelStatus.ForeColor != Color.DarkOrange) {
                labelStatus.ForeColor = Color.DarkGreen;
                labelStatus.Text = "Arduino připojeno pomocí Tcp socketu!";
            } else if(!Serial.IsOpen() && !Tcp.IsConnected()) {
                labelStatus.ForeColor = Color.DarkRed;
                labelStatus.Text = "Arduino není připojeno!";
            }

            if(labelPin1.Text == "?") {
                 GetArduinoPins();
            }

            if((Serial.IsOpen() || Tcp.IsConnected())) {
                if(!PrinterQuery.IsRunning()) {
                    GetArduinoPinsStates();
                    if(labelStatus.ForeColor == Color.DarkOrange || labelStatus.ForeColor == Color.DarkRed) {
                        labelStatus.ForeColor = Color.Orange;
                    }
                } else {
                    labelStatus.ForeColor = Color.DarkOrange;
                    labelStatus.Text = "Arduino připojeno, fronta příkazů plná!";
                }
            }
        }

        private void GetArduinoPins() {
            if(Serial.IsOpen()) {
                Serial.OnSerialReceived += OnDataReceived;
                Serial.Send("GL");
            } else if(Tcp.IsConnected()) {
                Tcp.OnTcpReceived += OnDataReceived;
                Tcp.Send("GL");
            }
        }

        private void GetArduinoPinsStates() {
            if(Serial.IsOpen()) {
                Serial.OnSerialReceived += OnDataReceived;
                Serial.Send("GV");
            } else if(Tcp.IsConnected()) {
                Tcp.OnTcpReceived += OnDataReceived;
                Tcp.Send("GV");
            }
        }

        private void OnDataReceived(object sender, MessageReceived e) {
            if(e.data.Contains("PinList:")) {
                Serial.OnSerialReceived -= OnDataReceived;
                Serial.OnSerialReceived -= OnDataReceived;
                string[] pinList = e.data.Substring(e.data.IndexOf("PinList:") + ("PinList:").Length).Split(',');
                SetPinLabels(pinList);
            } else if(e.data.Contains("StateList:")) {
                Serial.OnSerialReceived -= OnDataReceived;
                Tcp.OnTcpReceived -= OnDataReceived;
                string[] stateList = e.data.Substring(e.data.IndexOf("StateList:") + ("StateList:").Length).Split(',');
                SetPinStates(stateList);
            }
        }

        private void SetPinLabels(string[] pinList) {
            foreach(Control o in groupPinStatus.Controls) {
                if(o is Label) {
                    string name = ((Label)o).Name;
                    if(name.Substring(0, name.Length - 1) == "labelPin") {
                        groupPinStatus.Invoke((MethodInvoker) delegate {
                            ((Label)o).Text = pinList[Convert.ToInt32(name.Substring(name.Length - 1)) - 1];
                        });
                    } 
                }
            }
        }

        private void SetPinStates(string[] pinStates) {
            foreach(Control o in groupPinStatus.Controls) {
                if(o is PictureBox) {
                    string name = ((PictureBox)o).Name;
                    if(name.Substring(0, name.Length - 1) == "pbPin") {
                        groupPinStatus.Invoke((MethodInvoker)delegate {
                            bool state = Convert.ToBoolean(Convert.ToInt32(pinStates[Convert.ToInt32(name.Substring(name.Length - 1)) - 1]));
                            if(state) {
                                ((PictureBox)o).BackColor = Color.DarkGreen;
                            } else {
                                ((PictureBox)o).BackColor = Color.White;
                            }
                        });
                    }
                }
            }
        }

        private void formDebug_Load(object sender, EventArgs e) {
            foreach(Control o in groupPinStatus.Controls) {
                if(o is PictureBox) {
                    o.Click += (obj, args) => { 
                        string num = o.Name.Substring(o.Name.Length - 1);

                        if(!PrinterQuery.IsRunning() && num != "7") {
                            string pinNum = (groupPinStatus.Controls.Find("labelPin" + num, false)[0] as Label).Text;

                            bool state;
                            if(((PictureBox)o).BackColor == Color.DarkGreen) {
                                state = true;
                            }else {
                                state = false;
                            }

                            if(Serial.IsOpen()) {
                                Serial.Send("WP(" + pinNum + "," + Convert.ToInt32(!state) + ")");
                                o.BackColor = Color.Yellow;
                            } else if(Tcp.IsConnected()) {
                                Tcp.Send("WP(" + pinNum + "," + Convert.ToInt32(!state) + ")");
                                o.BackColor = Color.Yellow;
                            }
                        }
                    };
                }
            }
        }
 
    }
}
