using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace PixIt_0._3 {

    public partial class formMain : Form {

        // Dll knihovna pro čtení a zapisování do souboru
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        // Načtení ostatních formů
        formSettings settings;
        formManual manualControl;

        //Kopie Vektorů pro bitmapu
        public int[] pointX_duplicate = new int[10000];
        public int[] pointY_duplicate = new int[10000];
        public string[] directionPoint_duplicate = new string[10000];

        //Zobrazovaná Bitmapa
        public static Bitmap ShowBitmap;

        private string PixtureFilename;

        public bool settingsFormOpen = false;
        public bool manualControlFormOpen = false;
        public Form debugFormOpenedID = null;
        public bool isPictureLoaded = false;
        public bool isPictureDrawed = false;

        public static string settingColor = "";
        public static int numPort = 3;
        public static string EthernetIP = "";
        public static bool ShowFileInfo = true;

        public formMain() {
            InitializeComponent();
        }

        // Zapisování do souboru
        public void IniWriteValue(string path, string Section, string Key, string Value) {
            var totalPath = Path.Combine(Application.StartupPath, path);
            WritePrivateProfileString(Section, Key, Value, totalPath);
        }

        // Čtení ze souboru
        public string IniReadValue(string path, string Section, string Key) {
            var totalPath = Path.Combine(Application.StartupPath, path);
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, totalPath);
            return temp.ToString();
        }

        // Obnovení Originálního obrázku
        public void ReloadPictureBox() {
            try {
                picOriginal.Image = (Image)ShowBitmap;
            } catch { }
        }

        // Funkce pro načtení nastavení
        private void Main_Load(object sender, EventArgs e) {
            dialogOpenFile.Filter = "All Files (*.*)|*.*";
            dialogOpenFile.FilterIndex = 1;

            //Načtení nastavení z INI
            if (File.Exists(Path.Combine(Application.StartupPath, "settings.ini")) == true) {
                PixItCore.colorPath = Color.FromArgb(Convert.ToInt32(IniReadValue("settings.ini", "Colors", "path")));
                PixItCore.colorDrill = Color.FromArgb(Convert.ToInt32(IniReadValue("settings.ini", "Colors", "drill")));
                PixItCore.colorTranslation = Color.FromArgb(Convert.ToInt32(IniReadValue("settings.ini", "Colors", "translation")));
                numPort = Convert.ToInt32(IniReadValue("settings.ini", "COM", "port"));
                PrinterControl.Dpi = Convert.ToInt32(IniReadValue("settings.ini", "PrintSettings", "dpi"));
                EthernetIP = IniReadValue("settings.ini", "PrintSettings", "EthernetIP");
                
                string soldering = IniReadValue("settings.ini", "PrintSettings", "SolderingAreas");
                if(soldering != "") { PixItCore.drawSolderingAreas = Convert.ToBoolean(soldering); }

                string fileInfo = IniReadValue("settings.ini", "GlobalSettings", "ShowFileInfo");
                if(fileInfo != "") { ShowFileInfo = Convert.ToBoolean(fileInfo); }
            }
        }

        // Otevře formulář settings
        private void btnSetttings_Click(object sender, EventArgs e) {
            if (settingsFormOpen == false) {
                settingsFormOpen = true;
                settings = new formSettings();
                settings.FormClosed += new FormClosedEventHandler(settings_close);
                settings.Show();
            }
        }

        //Uložení nastavení při zavřeni settings
        private void settings_close(object sender, FormClosedEventArgs e) {
            //Zapsání nastavení do INI
            settingsFormOpen = false;
            IniWriteValue("settings.ini", "Colors", "path", PixItCore.colorPath.ToArgb().ToString());
            IniWriteValue("settings.ini", "Colors", "drill", PixItCore.colorDrill.ToArgb().ToString());
            IniWriteValue("settings.ini", "Colors", "translation", PixItCore.colorTranslation.ToArgb().ToString());
            IniWriteValue("settings.ini", "COM", "port", numPort.ToString());
            IniWriteValue("settings.ini", "PrintSettings", "dpi", PrinterControl.Dpi.ToString());
            IniWriteValue("settings.ini", "PrintSettings", "EthernetIP", EthernetIP);
            IniWriteValue("settings.ini", "PrintSettings", "SolderingAreas", PixItCore.drawSolderingAreas.ToString());
            IniWriteValue("settings.ini", "GlobalSettings", "ShowFileInfo", ShowFileInfo.ToString());
            Program.DebugAddLine("Okno nastavení bylo uzavřeno");
        }

        // Načtení obrázku
        private void btnLoad_Click(object sender, EventArgs e) {
            DialogResult result = dialogOpenFile.ShowDialog();
            if (result == DialogResult.OK) {
                PixItCore.ClearMemeory();
                PixtureFilename = dialogOpenFile.FileName;
                PixItCore.LoadedImage = new Bitmap(dialogOpenFile.FileName);
                ShowBitmap = new Bitmap(PixItCore.LoadedImage);
                isPictureLoaded = true;
                ReloadPictureBox();

                Program.DebugAddLine("Byl načten obrázek - " + "Šířka obrázku: " + PixItCore.LoadedImage.Width.ToString() + "    Výška obrázku: " + PixItCore.LoadedImage.Height.ToString());
                PixItCore.DrawPicture();

                if(ShowFileInfo) {
                    new formImageInfo(PixtureFilename.Substring(PixtureFilename.LastIndexOf(@"\") + 1), PixItCore.LoadedImage.Width, PixItCore.LoadedImage.Height, listBoxPoints.Items.Count, listBoxPointsDrill.Items.Count, listBoxVectors.Items.Count).Show();
                }
                dialogOpenFile.Dispose();
            }
        }

        private void ButtonPixtureInfo_Click(object sender, EventArgs e) {
            if(isPictureLoaded) {
                new formImageInfo(PixtureFilename.Substring(PixtureFilename.LastIndexOf(@"\") + 1), PixItCore.LoadedImage.Width, PixItCore.LoadedImage.Height, listBoxPoints.Items.Count, listBoxPointsDrill.Items.Count, listBoxVectors.Items.Count).Show();
            } else {
                new formMessage("Chyba", "Nelze zobrazit informace o obrázku pokud není žádný načten!").Show();
            }
        }

        // Zobrazení barvy na kterou najede myš
        private void picOriginal_MouseMove(object sender, MouseEventArgs e) {
            if (isPictureLoaded) {
                if(settingsFormOpen == true && e.X < PixItCore.LoadedImage.Width && e.X > 0 && e.Y < PixItCore.LoadedImage.Height && e.Y > 0) {
                    settings.picCursorColor.BackColor = PixItCore.LoadedImage.GetPixel(e.X, e.Y);
                }
            }
        }

        // Nastavení barvy pro určitou věc
        private void picOriginal_MouseClick(object sender, MouseEventArgs e) {
            if (settingsFormOpen == true) {
                switch (settingColor) {
                    case "path":
                        PixItCore.colorPath = PixItCore.LoadedImage.GetPixel(e.X, e.Y);
                        Program.DebugAddLine("Číslo portu změněno na: " + formMain.numPort);
                        break;

                    case "drill":
                        PixItCore.colorDrill = PixItCore.LoadedImage.GetPixel(e.X, e.Y);
                        Program.DebugAddLine("Barva vrtání změněna na: " + PixItCore.colorDrill);
                        break;

                    case "translation":
                        PixItCore.colorTranslation = PixItCore.LoadedImage.GetPixel(e.X, e.Y);
                        Program.DebugAddLine("Barva přechodu změněna na: " + PixItCore.colorTranslation);
                        break;

                }
                settingColor = ""; settings.loadData();
            }
        }

        // Když se klikne na button otevření portu
        private void btnPort_Click(object sender, EventArgs e) {
            // Pokud port ješte není otevřen
            if (!Serial.IsOpen()) {
                // Nastavení otevření portu
                Serial.Init("COM" + numPort.ToString(), 115200);

                // Pokud je port otevřen, změní stav ve statusu a zapíše do debugu
                if (Serial.IsOpen()) {
                    picOpenPort.BackColor = Color.Green;
                    Program.DebugAddLine("Port byl otevřen");
                    ButtonEthernet.Enabled = false;
                }
            }else{
                try {
                    Serial.Close();
                } catch (Exception ex) {
                    // Pokud se port nepodaří zavřít vypíše patřičnou chybovou hlášku
                    Program.DebugAddLine("Chyba při uzavření portu" + ex.Message.ToString());
                    Program.ShowMessageForm("Chyba při uzavření portu", ex.Message.ToString());
                }
                
                if (!Serial.IsOpen()) {
                    // Pokud se port uzavřel změní stav ve statusu a zapíše do debugu
                    picOpenPort.BackColor = Color.Maroon;
                    Program.DebugAddLine("Port byl uzavřen");
                    ButtonEthernet.Enabled = true;
                }
            }
        }

        //Funkce pro tevření Debug okna
        private void openDebug() {
            if (debugFormOpenedID == null) {
                debugFormOpenedID = new formDebug();
                debugFormOpenedID.FormClosed += new FormClosedEventHandler(debug_close);
                debugFormOpenedID.Show();
            }
        }

        //Otevře form manuálního ovládání
        private void btnManual_Click(object sender, EventArgs e) {
            if (!manualControlFormOpen) {
                if(Serial.IsOpen() || Tcp.IsConnected()) {
                    manualControlFormOpen = true;
                    manualControl = new formManual();
                    manualControl.FormClosed += new FormClosedEventHandler(manualControl_close);
                    manualControl.Show();
                } else {
                    new formMessage("Chyba", "Nelze otevřít manuální ovládání pokud není navázána komunikace s tiskárnou!").Show();
                }
            }
        }

        // Když se form manuálního ovládání uzavře tak změní kontrolní proměnnou
        private void manualControl_close(object sender, FormClosedEventArgs e) {
            manualControlFormOpen = false;
            Program.DebugAddLine("Manuální ovládání bylo uzavřeno");

        }

        // Otevře form Debugu
        private void buttonDebug_Click(object sender, EventArgs e) {
            openDebug();
        }

        //Když se form debugu uzavře tak změní kontrolní proměnnou
        private void debug_close(object sender, FormClosedEventArgs e) {
            debugFormOpenedID = null;
        }


        
        private void listBoxVectors_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBoxPoints.SelectedIndex >= 0) {
                ShowBitmap = new Bitmap(PixItCore.LoadedImage);

                BitmapPixelPointer.DisposeAll();
                new BitmapPixelPointer.Pointer(Program.Form, "ShowBitmap", pointX_duplicate[listBoxPoints.SelectedIndex], pointY_duplicate[listBoxPoints.SelectedIndex], Color.Blue);
                
                listBoxPointsDrill.SelectedIndex = -1;
                listBoxVectors.SelectedIndex = -1;
            }
        }

        private void listBoxPointsDrill_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBoxPointsDrill.SelectedIndex >= 0) {
                ShowBitmap = new Bitmap(PixItCore.LoadedImage);

                BitmapPixelPointer.DisposeAll();
                new BitmapPixelPointer.Pointer(Program.Form, "ShowBitmap", PixItCore.drillPointX[listBoxPointsDrill.SelectedIndex], PixItCore.drillPointY[listBoxPointsDrill.SelectedIndex], Color.DarkGreen);

                listBoxPoints.SelectedIndex = -1;
                listBoxVectors.SelectedIndex = -1;
            }
        }

        private void listBoxVectors_SelectedIndexChanged_1(object sender, EventArgs e) {
            if (listBoxVectors.SelectedIndex >= 0) {
                ShowBitmap = new Bitmap(PixItCore.LoadedImage);

                BitmapPixelPointer.DisposeAll();
                new BitmapPixelPointer.Pointer(Program.Form, "ShowBitmap", PixItCore.vectorStartX[listBoxVectors.SelectedIndex], PixItCore.vectorStartY[listBoxVectors.SelectedIndex], Color.Blue);
                new BitmapPixelPointer.Pointer(Program.Form, "ShowBitmap", PixItCore.vectorEndX[listBoxVectors.SelectedIndex], PixItCore.vectorEndY[listBoxVectors.SelectedIndex], Color.DarkBlue);

                listBoxPoints.SelectedIndex = -1;
                listBoxPointsDrill.SelectedIndex = -1;
            } 
        }

        private void buttonDrawVectors_Click(object sender, EventArgs e) {
            if (isPictureLoaded) {
                BitmapPixelPointer.DisposeAll();
                Bitmap BitCopy = new Bitmap(PixItCore.LoadedImage);

                Color color = Color.Red;
                for(int ii = 0; ii < PixItCore.vectorCount; ii++) {
                    int x = PixItCore.vectorEndX[ii] - PixItCore.vectorStartX[ii];
                    int y = PixItCore.vectorEndY[ii] - PixItCore.vectorStartY[ii];

                    if (x != 0) {
                        for (int i = 0; i <= Math.Abs(x); i++) {
                            if (x > 0) {
                                BitCopy.SetPixel(PixItCore.vectorStartX[ii] + i, PixItCore.vectorStartY[ii], color);
                            }

                            if (x < 0) {
                                BitCopy.SetPixel(PixItCore.vectorStartX[ii] - i, PixItCore.vectorStartY[ii], color);
                            }
                        }
                    }

                    if (y != 0) {
                        for (int i = 0; i <= Math.Abs(y); i++) {
                            if (y > 0) {
                                BitCopy.SetPixel(PixItCore.vectorStartX[ii], PixItCore.vectorStartY[ii] + i, color);
                            }

                            if (y < 0) {
                                BitCopy.SetPixel(PixItCore.vectorStartX[ii], PixItCore.vectorStartY[ii] - i, color);
                            }
                        }
                    }

                    ShowBitmap = BitCopy;
                    ReloadPictureBox();
                }
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e) {
            if (isPictureDrawed) {
                if (Serial.IsOpen() || Tcp.IsConnected()) {
                    if(!PrinterQuery.IsInUse()) {
                        //Tisk cest
                        PixItCore.AnalizeRoutes();
                        //Tisk pájecích ploch
                        if(PixItCore.drawSolderingAreas) { PixItCore.PrintSolderingAreas(); }
                        //Návrat na začžtek
                        PrinterControl.SetDefaultPosPen();

                        //Zahájení tisku
                        PrinterControl.StartPrinting();
                    } else {
                        new formMessage("Chyba", "Tiskárna je zaneprázdněna!").Show();
                    }
                } else {
                    new formMessage("Chyba", "Tiskárna není připojena nebo nebyla navázána komunikace!").Show();
                }
            } else {
                new formMessage("Chyba", "Není načten obrázek!").Show();
            }
        }

        private void buttonDrill_Click(object sender, EventArgs e) {
            if(isPictureDrawed == true) {
                if(Serial.IsOpen() || Tcp.IsConnected()) {
                    if(!PrinterQuery.IsInUse()) {
                        //Tisk vrtacích bodů
                        PixItCore.PrintDrillPoints();

                        //Zahájení tisku
                        PrinterControl.StartPrinting();
                    } else {
                        new formMessage("Chyba", "Tiskárna je zaneprázdněna!").Show();
                    }
                } else {
                    new formMessage("Chyba", "Tiskárna není připojena nebo nebyla navázána komunikace!").Show();
                }
            } else {
                new formMessage("Chyba", "Není načten obrázek!").Show();
            }
        }

        private void buttonPrintAndDraw_Click(object sender, EventArgs e) {
            if (isPictureDrawed) {
                if (Serial.IsOpen() || Tcp.IsConnected()) {
                    if(!PrinterQuery.IsInUse()) {
                        //Tisk cest
                        PixItCore.AnalizeRoutes();
                        //Tisk pájecích ploch
                        if(PixItCore.drawSolderingAreas) { PixItCore.PrintSolderingAreas(); }
                        //Návrat na začátek
                        PrinterControl.SetDefaultPosPen();

                        //Tisk vrtacích bodů
                        PixItCore.PrintDrillPoints();
                        //Návrat na začátek
                        PrinterControl.SetDefaultPosDrill();

                        //Zahájení tisku
                        PrinterControl.StartPrinting();
                    } else {
                        new formMessage("Chyba", "Tiskárna je zaneprázdněna!").Show();
                    }
                } else {
                    new formMessage("Chyba", "Tiskárna není připojena nebo nebyla navázána komunikace!").Show();
                }
            } else {
                new formMessage("Chyba", "Není načten obrázek!").Show();
            }
        }

        private void ButtonEthernet_Click(object sender, EventArgs e) { 
            if(!Tcp.IsConnected()) {
                Tcp.Connect(EthernetIP, 25567);
                if(Tcp.IsConnected()) { Tcp.StartListening(); picEthernet.BackColor = Color.Green; btnPort.Enabled = false; }
            } else {
                Tcp.Disconnect();
                if(!Tcp.IsConnected()) { picEthernet.BackColor = Color.Maroon; btnPort.Enabled = true; }
            }

        }

    }

}
