using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace PixIt_0._3
{
    public partial class formMain : Form
    {
        // Dll knihovna pro čtení a zapisování do souboru
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        // Vytvoření bitmap
        Bitmap LoadedImage;
        Bitmap ShowVectors;

        // Načtení ostatních formů
        formSettings settings;
        formManual manualControl;
        formDebug debug;
        
        // Proměnné
        int[,] point = new int[400, 400];

        // Pro kontrolu zda už není otevřeno
        bool settingsFormOpen = false;
        bool manualControlFormOpen = false;
        bool debugFormOpen = false;
        bool isPictureLoaded = false;
        
        // Pro posílání zpráv Debugu
        public static int debugResult = 0;
        public static string errorNumber;

        // Vytvoření handleru pro sériový port
        public static SerialPort mainSerialPort = new SerialPort();

        // Pro práci v settings
        public static string settingColor = "";
        public static Color colorPath = Color.White;
        public static Color colorDrill = Color.White;
        public static Color colorTranslation = Color.White;
        public static int numPort = 3;
        
        public formMain()
        {
            InitializeComponent();
        }

        // Zapisování do souboru
        public void IniWriteValue(string path, string Section, string Key, string Value)
        {
            var totalPath = Path.Combine(Application.StartupPath, path);
            WritePrivateProfileString(Section, Key, Value, totalPath);
        }

        // Čtení ze souboru
        public string IniReadValue(string path, string Section, string Key)
        {
            var totalPath = Path.Combine(Application.StartupPath, path);
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, totalPath);
            return temp.ToString();
        }

        // Obnovení Originálního obrázku
        private void ReloadPictureBoxs()
        {
            picOriginal.Image = (Image)LoadedImage;
        }

        // Funkce pro načtení nastavení
        private void Main_Load(object sender, EventArgs e)
        {
            dialogOpenFile.Filter = "All Files (*.*)|*.*";
            dialogOpenFile.FilterIndex = 1;

            //Načtení nastavení z INI
            if (File.Exists(Path.Combine(Application.StartupPath, "settings.ini")) == true)
            {
                colorPath = Color.FromArgb(Convert.ToInt32(IniReadValue("settings.ini", "Colors", "path")));
                colorDrill = Color.FromArgb(Convert.ToInt32(IniReadValue("settings.ini", "Colors", "drill")));
                colorTranslation = Color.FromArgb(Convert.ToInt32(IniReadValue("settings.ini", "Colors", "translation")));
                numPort = Convert.ToInt32(IniReadValue("settings.ini", "COM", "port"));
            }
        }
        
        // Otevře formulář settings
        private void btnSetttings_Click(object sender, EventArgs e)
        {
            if (settingsFormOpen == false)
            {
                settingsFormOpen = true;
                settings = new formSettings();
                settings.FormClosed += new FormClosedEventHandler(settings_close);
                settings.Show();
            }
        }
        
        //Uložení nastavení při zavřeni settings
        private void settings_close(object sender, FormClosedEventArgs e)
        {
            //Zapsání nastavení do INI
            settingsFormOpen = false;
            IniWriteValue("settings.ini", "Colors", "path", colorPath.ToArgb().ToString());
            IniWriteValue("settings.ini", "Colors", "drill", colorDrill.ToArgb().ToString());
            IniWriteValue("settings.ini", "Colors", "translation", colorTranslation.ToArgb().ToString());
            IniWriteValue("settings.ini", "COM", "port", numPort.ToString());
            debugResult = 10;
        }

        // Načtení obrázku
        private void btnLoad_Click(object sender, EventArgs e)
        {
            DialogResult result = dialogOpenFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadedImage = new Bitmap(dialogOpenFile.FileName);
                btnDraw.Enabled = true;
                toolWidth.Text = "Width: " + LoadedImage.Width.ToString();
                toolHeight.Text = "Height: " + LoadedImage.Height.ToString();
                isPictureLoaded = true;
                ReloadPictureBoxs();
                debugResult = 11;
                errorNumber = "Šířka obrázku: " + LoadedImage.Width.ToString() + "    Výška obrázku: " + LoadedImage.Height.ToString();

            }
        }

        // Zobrazení barvy na kterou najede myš
        private void picOriginal_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPictureLoaded == true) {
                if (settingsFormOpen == true && e.X < LoadedImage.Width && e.X > 0 && e.Y < LoadedImage.Height && e.Y > 0)
                {
                    settings.picCursorColor.BackColor = LoadedImage.GetPixel(e.X, e.Y);
                }
            }
        }

        // Nastavení barvy pro určitou věc
        private void picOriginal_MouseClick(object sender, MouseEventArgs e)
        {
            switch (settingColor)
            {
                case "path":
                    colorPath = LoadedImage.GetPixel(e.X, e.Y);
                    debugResult = 5;
                    break;

                case "drill":
                    colorDrill = LoadedImage.GetPixel(e.X, e.Y);
                    debugResult = 6;
                    break;

                case "translation":
                    colorTranslation = LoadedImage.GetPixel(e.X, e.Y);
                    debugResult = 7;
                    break;

            }
            settingColor = ""; settings.loadColors();
        }

        // Když se klikne na button otevření portu
        private void btnPort_Click(object sender, EventArgs e)
        {
            // Otevře form debug
            if (debugFormOpen == false && mainSerialPort.IsOpen == false)
            {
                debugFormOpen = true;
                debug = new formDebug();
                debug.FormClosed += new FormClosedEventHandler(debug_close);
                debug.Show();
                Thread.Sleep(1500);
            }
            
            // Pokud port ješte není otevřen
            if (mainSerialPort.IsOpen == false)
            {
                // Nastavení otevření portu
                mainSerialPort.PortName = "COM" + numPort.ToString();
                mainSerialPort.BaudRate = 115200;
                mainSerialPort.Parity = Parity.None;
                mainSerialPort.StopBits = StopBits.One;
                mainSerialPort.DataBits = 8;
                mainSerialPort.Handshake = Handshake.None;               
                mainSerialPort.DtrEnable = true;
                mainSerialPort.RtsEnable = true;
                mainSerialPort.Close();

                // Zkusit otevřít port
                try
                {
                    mainSerialPort.Open();
                }
                // Pokud se port neotevře vypíše patřičnou chybovou hlášku
                catch (Exception ex)
                {
                    toolPortStatus.Text = "Stav portu: Port je uzavřen! Chyba při otevření - " + ex.GetType().ToString();
                    errorNumber = ex.GetType().ToString();
                    debugResult = 1;
                }
                // Pokud je port otevřen, změní stav ve statusu a zapíše do debugu
                if (mainSerialPort.IsOpen == true)
                {
                    picOpenPort.BackColor = Color.Green;
                    btnPort.Text = "Zavřít port";
                    toolPortStatus.Text = "Stav portu: Port je otevřen!";
                    debugResult = 2;
                }
            }
            // Pokud port není uzavřen
            else
            {
                // Pokusí se potr zavřít
                try
                {
                    mainSerialPort.Close();
                }
                // Pokud se port nepodaří zavřít vypíše patřičnou chybovou hlášku
                catch (Exception ex)
                {
                    toolPortStatus.Text = "Stav portu: Port je otevřen! Chyba chyba při uzavření - " + ex.GetType().ToString();
                    errorNumber = ex.GetType().ToString();
                    debugResult = 3;
                }
                // Pokud se port uzavřel změní stav ve statusu a zapíše do debugu
                if (mainSerialPort.IsOpen == false)
                {
                    picOpenPort.BackColor = Color.Red;
                    btnPort.Text = "Otevřít port";
                    toolPortStatus.Text = "Stav portu: Port je uzavřen!";
                    debugResult = 4;
                }
            }     
        }                

        //Otevře form manuálního ovládání
        private void btnManual_Click(object sender, EventArgs e)
        {
            if (manualControlFormOpen == false)
            {
                manualControlFormOpen = true;
                manualControl = new formManual();
                manualControl.FormClosed += new FormClosedEventHandler(manualControl_close);
                manualControl.Show();
            }
        }
        
        // Když se form manuálního ovládání uzavře tak změní kontrolní proměnnou
        private void manualControl_close(object sender, FormClosedEventArgs e)
        {
            manualControlFormOpen = false;
            debugResult = 13;

        }

        // Otevře form Debugu
        private void buttonDebug_Click(object sender, EventArgs e)
        {
            if (debugFormOpen == false)
            {
                debugFormOpen = true;
                debug = new formDebug();
                debug.FormClosed += new FormClosedEventHandler(debug_close);
                debug.Show();
            }
        }
        
        //Když se form debugu uzavře tak změní kontrolní proměnnou
        private void debug_close(object sender, FormClosedEventArgs e)
        {
            debugFormOpen = false;
        }
    }
}
