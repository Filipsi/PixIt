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
        Bitmap showBitmap;

        // Načtení ostatních formů
        formSettings settings;
        formManual manualControl;

        // Proměnné
        string[, ,] point = new string[1000, 1000, 20];

        int[] pointX = new int[10000];
        int[] pointY = new int[10000];
        string[] directionPoint = new string[10000];
        int pointCount = 0;

        int[] pointX_duplicate = new int[10000];
        int[] pointY_duplicate = new int[10000];
        string[] directionPoint_duplicate = new string[10000];

        int[] drillPointX = new int[10000];
        int[] drillPointY = new int[10000];
        int drillPointCount = 0;

        int[] vectorStartX = new int[10000];
        int[] vectorStartY = new int[10000];
        int[] vectorEndX = new int[10000];
        int[] vectorEndY = new int[10000];
        string[] vectorDirection = new string[10000];
        int[] vectorRouteI = new int[10000];
        int[] vectorLength = new int[10000];
        int vectorCount = 0;
        int vectorRoutesCount = 1;

        public static string serialLastReadedValue = "";

        bool settingsFormOpen = false;
        bool manualControlFormOpen = false;
        Form debugFormOpenedID = null;
        bool isPictureLoaded = false;
        bool isPictureDrawed = false;

        int testTimerTicks = 3;

        int x = 0;
        int y = 0;

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
            picDraw.Image = (Image)showBitmap;
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
                PrinterControl.Dpi = Convert.ToInt32(IniReadValue("settings.ini", "PrintSettings", "dpi"));
                PrinterControl.drillTouchNum = Convert.ToInt32(IniReadValue("settings.ini", "PrintSettings", "drillTouch"));
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
            IniWriteValue("settings.ini", "PrintSettings", "dpi", PrinterControl.Dpi.ToString());
            IniWriteValue("settings.ini", "PrintSettings", "drillTouch", PrinterControl.drillTouchNum.ToString());
            debugAddLine("Okno nastavení bylo uzavřeno");
        }

        // Načtení obrázku
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (isPictureLoaded == false)
            {
                DialogResult result = dialogOpenFile.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadedImage = new Bitmap(dialogOpenFile.FileName);
                    showBitmap = new Bitmap(LoadedImage.Width, LoadedImage.Height);
                    toolWidth.Text = "Width: " + LoadedImage.Width.ToString();
                    toolHeight.Text = "Height: " + LoadedImage.Height.ToString();
                    isPictureLoaded = true;
                    ReloadPictureBoxs();
                    debugAddLine("Byl načten obrázek - " + "Šířka obrázku: " + LoadedImage.Width.ToString() + "    Výška obrázku: " + LoadedImage.Height.ToString());

                    drawPicture();
                }
            }
        }

        // Zobrazení barvy na kterou najede myš
        private void picOriginal_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPictureLoaded == true)
            {
                if (settingsFormOpen == true && e.X < LoadedImage.Width && e.X > 0 && e.Y < LoadedImage.Height && e.Y > 0)
                {
                    settings.picCursorColor.BackColor = LoadedImage.GetPixel(e.X, e.Y);
                }
            }
        }

        // Nastavení barvy pro určitou věc
        private void picOriginal_MouseClick(object sender, MouseEventArgs e)
        {
            if (settingsFormOpen == true)
            {
                switch (settingColor)
                {
                    case "path":
                        colorPath = LoadedImage.GetPixel(e.X, e.Y);
                        debugAddLine("Číslo portu změněno na: " + formMain.numPort);
                        break;

                    case "drill":
                        colorDrill = LoadedImage.GetPixel(e.X, e.Y);
                        debugAddLine("Barva vrtání změněna na: " + formMain.colorDrill);
                        break;

                    case "translation":
                        colorTranslation = LoadedImage.GetPixel(e.X, e.Y);
                        debugAddLine("Barva přechodu změněna na: " + formMain.colorTranslation);
                        break;

                }
                settingColor = ""; settings.loadColors();
            }
        }

        // Když se klikne na button otevření portu
        private void btnPort_Click(object sender, EventArgs e)
        {
            // Pokud port ješte není otevřen
            if (Serial.IsOpen() == false)
            {
                // Nastavení otevření portu
                Serial.Init("COM" + numPort.ToString(), 115200);

                // Pokud je port otevřen, změní stav ve statusu a zapíše do debugu
                if (Serial.IsOpen() == true) {
                    picOpenPort.BackColor = Color.Green;
                    btnPort.Text = "Zavřít port";
                    toolPortStatus.Text = "Stav portu: Port je otevřen!";
                    debugAddLine("Port byl otevřen");

                    testTimerTicks = 3;
                    timerPrinterCheck.Enabled = true;
                }
            }else{
                try {
                    Serial.Close();
                } catch (Exception ex) {
                    // Pokud se port nepodaří zavřít vypíše patřičnou chybovou hlášku
                    toolPortStatus.Text = "Stav portu: Port je otevřen! Chyba chyba při uzavření - " + ex.GetType().ToString(); 
                    debugAddLine("Chyba při uzavření portu" + ex.GetType().ToString());
                }
                
                if (Serial.IsOpen() == false) {
                    // Pokud se port uzavřel změní stav ve statusu a zapíše do debugu
                    picOpenPort.BackColor = Color.Maroon;
                    btnPort.Text = "Otevřít port";
                    toolPortStatus.Text = "Stav portu: Port je uzavřen!";
                    debugAddLine("Port byl uzavřen");

                    timerPrinterCheck.Enabled = false;
                }
            }
        }

        //Funkce pro tevření Debug okna
        private void openDebug()
        {
            if (debugFormOpenedID == null)
            {
                debugFormOpenedID = new formDebug();
                debugFormOpenedID.FormClosed += new FormClosedEventHandler(debug_close);
                debugFormOpenedID.Show();
            }
        }

        //Otevře form manuálního ovládání
        private void btnManual_Click(object sender, EventArgs e)
        {
            if (manualControlFormOpen == false && Serial.IsOpen() == true){
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
            debugAddLine("Manuální ovládání bylo uzavřeno");

        }

        // Otevře form Debugu
        private void buttonDebug_Click(object sender, EventArgs e)
        {
            openDebug();
        }

        //Když se form debugu uzavře tak změní kontrolní proměnnou
        private void debug_close(object sender, FormClosedEventArgs e)
        {
            debugFormOpenedID = null;
        }

        private void drawPicture()
        {
            if (isPictureLoaded == true)
            {
                tabControl.SelectedIndex = 2;

                getRoutes();
                getPoints();
                getDrills();


                for (int i = 0; i < pointCount; i++)
                {
                    listBoxPoints.Items.Add("[" + pointX[i] + "," + pointY[i] + "] " + directionPoint[i]);
                }

                for (int i = 0; i < pointCount; i++)
                {
                    pointX_duplicate[i] = pointX[i];
                    pointY_duplicate[i] = pointY[i];
                    directionPoint_duplicate[i] = directionPoint[i];
                }

                debugAddLine(drillPointCount.ToString());
                for (int i = 0; i < drillPointCount; i++)
                {
                    listBoxPointsDrill.Items.Add("[" + drillPointX[i] + "," + drillPointY[i] + "] ");
                }


                //Smaže křižovatky typu + z pole, nesou potřeba
                for (int i = 0; i < pointCount; i++){
                    string XDir = directionPoint[i].Substring(directionPoint[i].IndexOf("X") + 1, 1);
                    string YDir = directionPoint[i].Substring(directionPoint[i].IndexOf("Y") + 1, 1);
                    if (XDir == "1" && YDir == "1"){
                        pointX[i] = 0;
                        pointY[i] = 0;
                    }
                }

                //Vypočítá cesty
                int startPointIndex = 0;
                while (startPointIndex != -1)
                {
                    startPointIndex = getStartPoint();
                    debugAddLine("----------------------------");
                    if (startPointIndex != -1){
                        convertToVectorAndRoute(startPointIndex);
                    }
                }

                buttonDrawVectors.PerformClick();
                isPictureDrawed = true;
            } else { debugAddLine("Nelze vykreslit! Nebyl načten obrázek!"); }
        }

        //Vrátí index bodu, který je nejbližší začátku pole a má pouze jeden platný směr
        private int getStartPoint(){
            int retVal = -1;

            for (int i = 0; i < pointCount; i++){
                if (pointX[i] != 0 && pointY[i] != 0)
                {
                    string XDir = directionPoint[i].Substring(directionPoint[i].IndexOf("X") + 1, 1);
                    string YDir = directionPoint[i].Substring(directionPoint[i].IndexOf("Y") + 1, 1);

                    if (XDir == "0" && (YDir == "p" || YDir == "n"))
                    {
                        retVal = i;
                        break;
                    }
                    else if (YDir == "0" && (XDir == "p" || XDir == "n"))
                    {
                        retVal = i;
                        break;
                    }
                }
            }

            return retVal;
        }

        //Zjistí trasy v obrázku
        private void getRoutes()
        {
            int citac = 0;
            int citac2 = 0;
            Color thisPixel = LoadedImage.GetPixel(x, y);

            while (x < LoadedImage.Width - 1 || y < LoadedImage.Height - 1)
            {
                thisPixel = LoadedImage.GetPixel(x, y);
                if (thisPixel == colorPath || thisPixel == colorTranslation)
                {
                    point[x, y, 0] = "ROUTE";
                    citac++;
                }
                else
                {
                    point[x, y, 0] = "NULL";
                }
                if (thisPixel == colorDrill || thisPixel == colorTranslation)
                {
                    point[x, y, 10] = "DRILL";
                    citac2++;
                }
                else
                {
                    point[x, y, 10] = "NULL";
                }
                if (x < LoadedImage.Width - 1)
                {
                    x++;
                }
                else
                {
                    x = 0; y++;
                }
            }
            debugAddLine("V obrázku je " + citac + " pixelů trasy");
            debugAddLine("V obrázku je " + citac2 + " pixelů vrtani");

        }

        //Zjistí body
        private void getPoints()
        {
            for (int i = 2; i < 398; i++)
            {
                for (int u = 2; u < 398; u++)
                {
                    if (point[i, u, 0] == "ROUTE")
                    {
                        if (point[i + 3, u, 0] == "ROUTE" && point[i - 2, u, 0] == "NULL" && point[i, u + 2, 0] == "ROUTE" && point[i, u - 2, 0] == "NULL" && point[i, u + 3, 0] == "NULL" && point[i, u - 1, 0] == "ROUTE" && point[i + 2, u + 1, 0] == "ROUTE")
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XpY0";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XpY0";

                            pointCount++;
                        }
                        else if (point[i + 2, u, 0] == "ROUTE" && point[i - 1, u, 0] == "NULL" && point[i, u + 1, 0] == "NULL" && point[i, u - 2, 0] == "ROUTE" && point[i + 3, u, 0] == "NULL" && point[i, u - 3, 0] == "NULL")
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XpYn";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XpYn";

                            pointCount++;
                        }
                        else if (point[i + 2, u, 0] == "ROUTE" && point[i - 1, u, 0] == "NULL" && point[i, u + 2, 0] == "NULL" && point[i, u - 2, 0] == "NULL")
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XpY0";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XpY0";

                            pointCount++;
                        }
                        else if (point[i + 1, u, 0] == "NULL" && point[i - 2, u, 0] == "ROUTE" && point[i, u + 2, 0] == "NULL" && point[i, u - 2, 0] == "NULL")
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XnY0";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XnY0";

                            pointCount++;
                        }
                        else if (point[i + 2, u, 0] == "NULL" && point[i - 2, u, 0] == "NULL" && point[i, u + 2, 0] == "ROUTE" && point[i, u - 1, 0] == "NULL")
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "X0Yp";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "X0Yp";

                            pointCount++;
                        }
                        else if (point[i + 2, u, 0] == "NULL" && point[i - 2, u, 0] == "NULL" && point[i, u + 1, 0] == "NULL" && point[i, u - 2, 0] == "ROUTE")
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "X0Yn";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "X0Yn";

                            pointCount++;
                        }
                        else if (point[i + 3, u, 0] == "ROUTE" && point[i - 2, u, 0] == "NULL" && point[i, u + 3, 0] == "ROUTE" && point[i, u - 3, 0] == "ROUTE" && point[i + 2, u - 2, 0] == "NULL" && point[i + 2, u + 2, 0] == "NULL")
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XpY1";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XpY1";

                            pointCount++;
                        }
                        else if (point[i + 2, u, 0] == "NULL" && point[i - 3, u, 0] == "ROUTE" && point[i, u + 3, 0] == "ROUTE" && point[i, u - 3, 0] == "ROUTE" && point[i - 2, u - 2, 0] == "NULL" && point[i - 2, u + 2, 0] == "NULL")
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XnY1";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XnY1";

                            pointCount++;
                        }
                        else if (point[i + 3, u, 0] == "ROUTE" && point[i - 3, u, 0] == "ROUTE" && point[i, u + 3, 0] == "ROUTE" && point[i, u - 2, 0] == "NULL" && point[i + 2, u + 2, 0] == "NULL" && point[i - 2, u + 2, 0] == "NULL")
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "X1Yp";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "X1Yp";

                            pointCount++;
                        }
                        else if (point[i + 3, u, 0] == "ROUTE" && point[i - 3, u, 0] == "ROUTE" && point[i, u + 2, 0] == "NULL" && point[i, u - 3, 0] == "ROUTE" && point[i + 2, u - 2, 0] == "NULL" && point[i - 2, u - 2, 0] == "NULL")
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "X1Yn";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "X1Yn";

                            pointCount++;
                        }
                        else if (point[i + 3, u, 0] == "ROUTE" && point[i - 2, u, 0] == "NULL" && point[i, u + 3, 0] == "ROUTE" && point[i, u - 2, 0] == "NULL" && point[i + 2, u + 2, 0] == "NULL")
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XpYp";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XpYp";

                            pointCount++;
                        }
                        else if (point[i + 2, u, 0] == "NULL" && point[i - 3, u, 0] == "ROUTE" && point[i, u + 3, 0] == "ROUTE" && point[i, u - 2, 0] == "NULL" && point[i - 2, u + 2, 0] == "NULL")
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XnYp";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XnYp";

                            pointCount++;
                        }
                        else if (point[i + 3, u, 0] == "ROUTE" && point[i - 2, u, 0] == "NULL" && point[i, u + 2, 0] == "NULL" && point[i, u - 3, 0] == "ROUTE" && point[i + 2, u - 2, 0] == "NULL")
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XpYn";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XpYn";

                            pointCount++;
                        }
                        else if (point[i + 2, u, 0] == "NULL" && point[i - 3, u, 0] == "ROUTE" && point[i, u + 2, 0] == "NULL" && point[i, u - 3, 0] == "ROUTE" && point[i - 2, u - 2, 0] == "NULL")
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XnYn";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XnYn";

                            pointCount++;
                        }
                        else if (point[i + 3, u, 0] == "ROUTE" && point[i - 3, u, 0] == "ROUTE" && point[i, u + 3, 0] == "ROUTE" && point[i, u - 3, 0] == "ROUTE")
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "X1Y1";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "X1Y1";

                            pointCount++;
                        }
                    }
                }
            } 
            
            ReloadPictureBoxs();
        }

       private void getDrills()
        {
            int citac = 0;
            for (int i = 2; i < 398; i++)
            {
                for (int u = 2; u < 398; u++)
                {
                    int v = 1;
                    if (point[i, u, 10] == "NULL")
                    {
                        while (v <= 2)
                        {
                            if (point[i - v, u - v, 10] == "DRILL")
                            {
                                if (point[i + v, u + v, 10] != "DRILL" || point[i + v, u - v, 10] != "DRILL" || point[i - v, u + v, 10] != "DRILL" || point[i + 1, u, 10] == "DRILL" || point[i - 1, u, 10] == "DRILL" || point[i, u + 1, 10] == "DRILL" || point[i, u - 1, 10] == "DRILL")
                                {
                                    v = 2;
                                }
                                else
                                {
                                    point[i, u, 10] = "VRT";
                                    LoadedImage.SetPixel(i, u, Color.White);
                                    v = 2;
                                    citac++;

                                    drillPointX[drillPointCount] = i;
                                    drillPointY[drillPointCount] = u;
                                    drillPointCount++;
                                }
                            }
                            v++;
                        }
                    }
                }
            }
            debugAddLine("V obrázku je " + citac + " pixelů vrtů");
        }

        //Zpracuje vektor
        private void processVector(int checkIndex, int i, string deleteDirection, bool deletePoint) {
            debugAddLine("  Nalezen bod: " + pointX[i] + "," + pointY[i]);

            //Uloží dvojci bodů jako vektor
            //Zapíše StartX/Y
            vectorStartX[vectorCount] = pointX[checkIndex];
            vectorStartY[vectorCount] = pointY[checkIndex];
            //Zapíše EndX/Y
            vectorEndX[vectorCount] = pointX[i];
            vectorEndY[vectorCount] = pointY[i];
            //Zapíše direction
            string direction = "";
            if      (pointX[checkIndex] > pointX[i]) { direction += "Xn"; }
            else if (pointX[checkIndex] < pointX[i]) { direction += "Xp"; }

            if      (pointY[checkIndex] > pointY[i]) { direction += "Yn"; }
            else if (pointY[checkIndex] < pointY[i]) { direction += "Yp"; }

            vectorDirection[vectorCount] = direction;
            //Uloží délku
            if (vectorDirection[vectorCount].Substring(0, 1) == "X") { vectorLength[vectorCount] = vectorEndX[vectorCount] - vectorStartX[vectorCount]; }
            else if (vectorDirection[vectorCount].Substring(0, 1) == "Y") { vectorLength[vectorCount] = vectorEndY[vectorCount] - vectorStartY[vectorCount]; }
            vectorLength[vectorCount] = Math.Abs(vectorLength[vectorCount]);

            vectorRouteI[vectorCount] = vectorRoutesCount;
            listBoxVectors.Items.Add(vectorRouteI[vectorCount] + " [" + vectorStartX[vectorCount] + "," + vectorStartY[vectorCount] + "] -> [" + vectorEndX[vectorCount] + "," + vectorEndY[vectorCount] + "] (" + vectorDirection[vectorCount] + " : " + vectorLength[vectorCount] + ")");

            //Uloží
            vectorCount++;

            //Smaže první (začáteční) bod
            if (deletePoint == true) {
                pointX[checkIndex] = 0;
                pointY[checkIndex] = 0;
            }
            
        }

        //Najde nejbližší platný bod pro zadaný bod
        private int copmarePoints(int pointIndex, string direction) {
            int retVal = 0;
            int compareValue;
            int minCompareIndex = -1;

            switch (direction) {
                case "Yp":
                    compareValue = LoadedImage.Height;

                    for (int i = 0; i < pointCount; i++) {
                        string YDir = directionPoint[i].Substring(directionPoint[i].IndexOf("Y") + 1, 1);

                        if (pointX[pointIndex] == pointX[i] && pointY[i] < compareValue && YDir == "n" && pointY[i] > pointY[pointIndex]) {
                            compareValue = pointY[i];
                            minCompareIndex = i;
                            debugAddLine("Nalezen směr!");
                        }

                        if (pointX[pointIndex] == pointX[i] && pointY[i] < compareValue && YDir == "1" && pointY[i] > pointY[pointIndex]) {
                            compareValue = pointY[i];
                            minCompareIndex = i;
                            debugAddLine("Nalezena křižovatka! (" + directionPoint[i] + ") Index: " + minCompareIndex);
                        }
                    }

                    if (compareValue == LoadedImage.Height) { retVal = -1; } else { retVal = minCompareIndex; }
                    break;

                case "Yn":
                    compareValue = 0;

                    for (int i = 0; i < pointCount; i++) {
                        string YDir = directionPoint[i].Substring(directionPoint[i].IndexOf("Y") + 1, 1);

                        if (pointX[pointIndex] == pointX[i] && pointY[i] > compareValue && YDir == "p" && pointY[i] < pointY[pointIndex]) {
                            compareValue = pointY[i];
                            minCompareIndex = i;
                            debugAddLine("  -Nalezen směr!");
                        }

                        if (pointX[pointIndex] == pointX[i] && pointY[i] > compareValue && YDir == "1" && pointY[i] < pointY[pointIndex]) {
                            compareValue = pointY[i];
                            minCompareIndex = i;
                            debugAddLine("  -Nalezena křižovatka! (" + directionPoint[i] + ") Index: " + minCompareIndex);
                        }
                    }

                    if (compareValue == 0) { retVal = -1; } else { retVal = minCompareIndex; }
                    break;

                case "Xp":
                    compareValue = LoadedImage.Width;

                    //Křižovatky
                    for (int i = 0; i < pointCount; i++) {
                        string XDir = directionPoint[i].Substring(directionPoint[i].IndexOf("X") + 1, 1);

                        if (pointY[pointIndex] == pointY[i] && pointX[i] < compareValue && XDir == "n" && pointX[i] > pointX[pointIndex]) {
                            compareValue = pointX[i];
                            minCompareIndex = i;
                        }

                        if (pointY[pointIndex] == pointY[i] && pointX[i] < compareValue && XDir == "1" && pointX[i] > pointX[pointIndex]) {
                            compareValue = pointX[i];
                            minCompareIndex = i;
                        }
                    }

                    if (compareValue == LoadedImage.Width) { retVal = -1; } else { retVal = minCompareIndex; }
                    break;

                case "Xn":
                    compareValue = 0;

                    for (int i = 0; i < pointCount; i++) {
                        string XDir = directionPoint[i].Substring(directionPoint[i].IndexOf("X") + 1, 1);

                        if (pointY[pointIndex] == pointY[i] && pointX[i] > compareValue && XDir == "p" && pointX[i] < pointX[pointIndex]) {
                            compareValue = pointX[i];
                            minCompareIndex = i;
                        }

                        if (pointY[pointIndex] == pointY[i] && pointX[i] > compareValue && XDir == "1" && pointX[i] < pointX[pointIndex]) {
                            compareValue = pointX[i];
                            minCompareIndex = i;
                        }
                    }

                    if (compareValue == 0) { retVal = -1; } else { retVal = minCompareIndex; }
                    break;
            }

            return retVal;
        }

        private void convertToVectorAndRoute(int checkIndex) {
            string deleteDirection = "";
            string XDir; string YDir;

            do {
                XDir = "";
                YDir = "";

                if (deleteDirection != "") {
                    debugAddLine("deleteDirection: " + deleteDirection);

                    //Pro křižovatky
                    if (directionPoint[checkIndex].Substring(directionPoint[checkIndex].IndexOf("X") + 1, 1) == "1" || directionPoint[checkIndex].Substring(directionPoint[checkIndex].IndexOf("Y") + 1, 1) == "1") {
                        //Pokud je Lrozcestí
                        if (directionPoint[checkIndex].Substring(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, 1) == "1") {
                            //Obrátí směr
                            string reverseDir = deleteDirection.Substring(1, 1);
                            if (reverseDir == "n") { reverseDir = "p"; }
                            else if (reverseDir == "p") { reverseDir = "n"; }
                            else { reverseDir = "9"; }

                            directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, 1);
                            directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, reverseDir);
                            
                            debugAddLine("Upraven index " + checkIndex + " na: " + directionPoint[checkIndex] + " (Lrozcestí)");
                        } else {
                            //Pokud je -Rozcestí
                            //Přepíše
                            directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, 1);
                            directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, "0");

                            debugAddLine("Upraven index " + checkIndex + " na: " + directionPoint[checkIndex] + " (-rozcestí)");
                        }

                        debugAddLine("Upraveno deleteDirection (křižovatka)");
                    }else{
                    //Pro směry
                        directionPoint[checkIndex] = directionPoint[checkIndex].Replace(deleteDirection, deleteDirection.Substring(0, 1) + "0");
                        debugAddLine("Upraven index " + checkIndex + " na: " + directionPoint[checkIndex] + " (smer)");
                        debugAddLine("Upraveno deleteDirection (směr)");
                    }
                }

                debugAddLine("Bod: [" + pointX[checkIndex] + "," + pointY[checkIndex] + "]" + "Index: " + checkIndex);
                XDir = directionPoint[checkIndex].Substring(directionPoint[checkIndex].IndexOf("X") + 1, 1);
                YDir = directionPoint[checkIndex].Substring(directionPoint[checkIndex].IndexOf("Y") + 1, 1);
                debugAddLine(" XDir: " + XDir + " / YDir: " + YDir);

                //4 základní směry
                if (XDir == "0" && YDir == "p") {
                    int pointFindIndex = copmarePoints(checkIndex, "Yp");
                    if(pointFindIndex != -1){
                        processVector(checkIndex, pointFindIndex, deleteDirection, true);
                        checkIndex = pointFindIndex;
                        deleteDirection = "Yn";
                    } else { debugAddLine("ForceBreak! (X0Yp)"); break; }
                } else if (XDir == "0" && YDir == "n") {
                    int pointFindIndex = copmarePoints(checkIndex, "Yn");
                    if (pointFindIndex != -1) {
                        processVector(checkIndex, pointFindIndex, deleteDirection, true);
                        checkIndex = pointFindIndex;
                        deleteDirection = "Yp";
                    }else { debugAddLine("ForceBreak! (X0Yn)"); break; }
                } else if (XDir == "p" && YDir == "0") {
                    int pointFindIndex = copmarePoints(checkIndex, "Xp");
                    if (pointFindIndex != -1) {
                        processVector(checkIndex, pointFindIndex, deleteDirection, true);
                        checkIndex = pointFindIndex;
                        deleteDirection = "Xn";
                    }else { debugAddLine("ForceBreak! (XpY0)"); break; }
                } else if (XDir == "n" && YDir == "0") {
                    int pointFindIndex = copmarePoints(checkIndex, "Xn");
                    if (pointFindIndex != -1) {
                        processVector(checkIndex, pointFindIndex, deleteDirection, true);
                        checkIndex = pointFindIndex;
                        deleteDirection = "Xp";
                    } else { debugAddLine("ForceBreak! (XnY0)"); break; }
                } else if(XDir == "p" && YDir == "n"){
                    string checkVal = "";

                    string reverseDir = deleteDirection.Substring(1, 1);
                    if (reverseDir == "n") { reverseDir = "p"; }
                    else if (reverseDir == "p") { reverseDir = "n"; }
                    else { reverseDir = "9"; }
                        
                    checkVal = deleteDirection.Substring(0, 1) + reverseDir;
                    debugAddLine(checkVal);

                    int pointFindIndex = copmarePoints(checkIndex, checkVal);
                    if (pointFindIndex != -1) {
                        processVector(checkIndex, pointFindIndex, deleteDirection, false);
                    } else { debugAddLine("ForceBreak!"); break; }

                    //Smaže cestu, kterou lze pokračovat 
                    directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, 1);
                    directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, "0");

                    checkIndex = pointFindIndex;
                } else if (XDir == "n" && YDir == "p") {
                    string checkVal = "";

                    string reverseDir = deleteDirection.Substring(1, 1);
                    if (reverseDir == "n") { reverseDir = "p"; }
                    else if (reverseDir == "p") { reverseDir = "n"; }
                    else { reverseDir = "9"; }

                    checkVal = deleteDirection.Substring(0, 1) + reverseDir;
                    debugAddLine(checkVal);

                    int pointFindIndex = copmarePoints(checkIndex, checkVal);
                    if (pointFindIndex != -1) {
                        processVector(checkIndex, pointFindIndex, deleteDirection, false);
                    } else { debugAddLine("ForceBreak!"); break; }

                    //Smaže cestu, kterou lze pokračovat 
                    directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, 1);
                    directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, "0");

                    checkIndex = pointFindIndex;
                    
                } else if (XDir == "n" && YDir == "n") {
                    string checkVal = "";

                    string reverseDir = deleteDirection.Substring(1, 1);
                    if (reverseDir == "n") { reverseDir = "p"; }
                    else if (reverseDir == "p") { reverseDir = "n"; }
                    else { reverseDir = "9"; }

                    checkVal = deleteDirection.Substring(0, 1) + reverseDir;
                    debugAddLine(checkVal);

                    int pointFindIndex = copmarePoints(checkIndex, checkVal);
                    if (pointFindIndex != -1) {
                        processVector(checkIndex, pointFindIndex, deleteDirection, false);
                    } else { debugAddLine("ForceBreak!"); break; }

                    //Smaže cestu, kterou lze pokračovat 
                    directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, 1);
                    directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, "0");

                    checkIndex = pointFindIndex;
                } else if (XDir == "p" && YDir == "p") {
                    string checkVal = "";

                    string reverseDir = deleteDirection.Substring(1, 1);
                    if (reverseDir == "n") { reverseDir = "p"; }
                    else if (reverseDir == "p") { reverseDir = "n"; }
                    else { reverseDir = "9"; }

                    checkVal = deleteDirection.Substring(0, 1) + reverseDir;
                    debugAddLine(checkVal);

                    int pointFindIndex = copmarePoints(checkIndex, checkVal);
                    if (pointFindIndex != -1) {
                        processVector(checkIndex, pointFindIndex, deleteDirection, false);
                    } else { debugAddLine("ForceBreak!"); break; }

                    //Smaže cestu, kterou lze pokračovat 
                    directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, 1);
                    directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, "0");

                    checkIndex = pointFindIndex;
                } else if (XDir == "1" && YDir == "0") {
                    //Na rozcestí nelze pokračovat po směru, ze kterého jsem přišel
                    //Zvolí preferovaný směr (doprava +)
                    string checkVal = "Xp";

                    int pointFindIndex = copmarePoints(checkIndex, checkVal);
                    if (pointFindIndex != -1) {
                        processVector(checkIndex, pointFindIndex, deleteDirection, false);
                    } else { debugAddLine("ForceBreak!"); break; }

                    //Přepíše bod aby zůstal pouze platný směr (ten kterým tento cyklus nepojedeme)
                    directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf("X") + 1, 1);
                    directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf("X") + 1, "n");
                    debugAddLine("Upraven index " + checkIndex + " na " + directionPoint[checkIndex]);

                    YDir = "0";

                    checkIndex = pointFindIndex;
                    deleteDirection = "Xn";
                } else if (XDir == "0" && YDir == "1") {
                    //Na rozcestí nelze pokračovat po směru, ze kterého jsem přišel
                    //Zvolí preferovaný směr (nahoru -)
                    string checkVal = "Yn";

                    int pointFindIndex = copmarePoints(checkIndex, checkVal);
                    if (pointFindIndex != -1) {
                        processVector(checkIndex, pointFindIndex, deleteDirection, false);
                    } else { debugAddLine("ForceBreak!"); break; }

                    debugAddLine("Hodnota po po provedení: " + directionPoint[checkIndex] + "(" + pointX[checkIndex] + "," + pointY[checkIndex] + ") I: " + checkIndex);

                    //Přepíše bod aby zůstal pouze platný směr (ten kterým tento cyklus nepojedeme)
                    directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf("Y") + 1, 1);
                    directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf("Y") + 1, "p");

                    YDir = "0";

                    checkIndex = pointFindIndex;
                    deleteDirection = "Yp";
                }
                else { vectorRoutesCount++; break; }
            } while (true);

            //Pokud už nelze najít další bod cesty, smaže i poslední použitý bod
            pointX[checkIndex] = 0;
            pointY[checkIndex] = 0;

            //Aktualizuje body v listBoxVectors
            listBoxPoints.Items.Clear();
            for (int i = 0; i < pointCount; i++){
                listBoxPoints.Items.Add("[" + pointX_duplicate[i] + "," + pointY_duplicate[i] + "] " + directionPoint_duplicate[i]);
            }

        }

        public void debugAddLine(string text) {
                if (System.Windows.Forms.Application.OpenForms["formDebug"] != null) {
                    (System.Windows.Forms.Application.OpenForms["formDebug"] as formDebug).addLineDebug(text);
                }
        }

        private void listBoxVectors_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBoxPoints.SelectedIndex >= 0) {
                listBoxPointsDrill.SelectedIndex = -1;
                listBoxVectors.SelectedIndex = -1;
                showBitmap.Dispose();
                showBitmap = new Bitmap(LoadedImage.Width, LoadedImage.Height);
                showBitmap.SetPixel(pointX_duplicate[listBoxPoints.SelectedIndex], pointY_duplicate[listBoxPoints.SelectedIndex], Color.DarkBlue);
                ReloadPictureBoxs();
            }
        }

        private void listBoxPointsDrill_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBoxPointsDrill.SelectedIndex >= 0) {
                listBoxPoints.SelectedIndex = -1;
                listBoxVectors.SelectedIndex = -1;
                showBitmap.Dispose();
                showBitmap = new Bitmap(LoadedImage.Width, LoadedImage.Height);
                showBitmap.SetPixel(drillPointX[listBoxPointsDrill.SelectedIndex], drillPointY[listBoxPointsDrill.SelectedIndex], Color.DarkBlue);
                ReloadPictureBoxs();
            }
        }

        private void listBoxVectors_SelectedIndexChanged_1(object sender, EventArgs e) {
            if (listBoxVectors.SelectedIndex >= 0) {
                listBoxPoints.SelectedIndex = -1;
                listBoxPointsDrill.SelectedIndex = -1;
                showBitmap.Dispose();
                showBitmap = new Bitmap(LoadedImage.Width, LoadedImage.Height);
                showBitmap.SetPixel(vectorStartX[listBoxVectors.SelectedIndex], vectorStartY[listBoxVectors.SelectedIndex], Color.Blue);
                showBitmap.SetPixel(vectorEndX[listBoxVectors.SelectedIndex], vectorEndY[listBoxVectors.SelectedIndex], Color.Red);
                ReloadPictureBoxs();
            } 
        }

        private void buttonDrawVectors_Click(object sender, EventArgs e) {
            if (isPictureLoaded == true) {
                showBitmap.Dispose();
                showBitmap = new Bitmap(LoadedImage.Width, LoadedImage.Height);

                for (int ii = 0; ii < vectorCount; ii++) {
                    int x = vectorEndX[ii] - vectorStartX[ii];
                    int y = vectorEndY[ii] - vectorStartY[ii];


                    if (x != 0) {
                        for (int i = 0; i <= Math.Abs(x); i++) {
                            if (x > 0) {
                                showBitmap.SetPixel(vectorStartX[ii] + i, vectorStartY[ii], Color.Green);
                            }

                            if (x < 0) {
                                showBitmap.SetPixel(vectorStartX[ii] - i, vectorStartY[ii], Color.Green);
                            }
                        }
                    }

                    if (y != 0) {
                        for (int i = 0; i <= Math.Abs(y); i++) {
                            if (y > 0) {
                                showBitmap.SetPixel(vectorStartX[ii], vectorStartY[ii] + i, Color.Green);
                            }

                            if (y < 0) {
                                showBitmap.SetPixel(vectorStartX[ii], vectorStartY[ii] - i, Color.Green);
                            }
                        }
                    }
                }

                ReloadPictureBoxs();
            }
        }

        private int getRouteIStart(int routeI) {
            int retVal = -1;
            for (int i = 0; i <= vectorCount; i++) {
                if (vectorRouteI[i] == routeI) {
                    retVal = i;
                    break;
                }
            }

            return retVal;
        }

        private void buttonPrint_Click(object sender, EventArgs e) {
            if (isPictureDrawed == true) {
                if (Serial.IsOpen() == true) {

                    PrinterControl.SetDefaultPosPen();

                    decimal DpiXRadio = (decimal)(PrinterControl.xRadio * 25.4F / PrinterControl.Dpi);
                    decimal DpiYRadio = (decimal)(PrinterControl.yRadio * 25.4F / PrinterControl.Dpi);

                    int lastI = 0; int currectDrawingRouteI = 1; string lastYDir = "";
                    for (int routeI = 1; routeI < vectorRoutesCount; routeI++) {
                        int endPointX, endPointY;
                        if (lastI != 0) {
                            endPointX = vectorEndX[lastI - 1];
                            endPointY = vectorEndY[lastI - 1];
                        } else { endPointX = 0; endPointY = 0; }

                        int moveX = endPointX - vectorStartX[getRouteIStart(routeI)];
                        int moveY = endPointY - vectorStartY[getRouteIStart(routeI)];

                        int stepsStartX = (int)Math.Round((Math.Abs(moveX) * DpiXRadio), 0);
                        int stepsStartY = (int)Math.Round((Math.Abs(moveY) * DpiYRadio), 0);

                        PrinterQuery.AddCommand("SPU");
                        string xDir, yDir;
                        if (moveX < 0) { xDir = "XR"; } else { xDir = "XL"; }
                        if (moveY < 0) { yDir = "YU"; } else { yDir = "YD"; }

                        if (yDir == "YU" && lastYDir == "YD") { stepsStartY += 12; }
                        if (yDir == "YL" && lastYDir == "YR") { stepsStartY += 12; }
                        lastYDir = yDir;

                        PrinterQuery.AddCommand("M" + xDir + "(" + stepsStartX + ")");
                        PrinterQuery.AddCommand("M" + yDir + "(" + stepsStartY + ")");
                        PrinterQuery.AddCommand("SPD");

                        int i = lastI;
                        float stepsRestEnd = 0;
                        while (vectorRouteI[i] == currectDrawingRouteI) {
                            listBoxVectors.SelectedIndex = i;

                            int stepsEnd = 0;
                            if (vectorDirection[i].Substring(0, 1) == "X") {
                                stepsEnd = (int)Math.Round((vectorLength[i] * DpiXRadio) + (decimal)stepsRestEnd, 0);
                                stepsRestEnd = (float)(vectorLength[i] * DpiXRadio - stepsEnd);
                            } else if (vectorDirection[i].Substring(0, 1) == "Y") {
                                stepsEnd = (int)Math.Round((vectorLength[i] * DpiYRadio) + (decimal)stepsRestEnd, 0);
                                stepsRestEnd = (float)(vectorLength[i] * DpiYRadio - stepsEnd);
                            }

                            if (i != 0){
                                if (i == lastI) {
                                    if (vectorDirection[i] == "Yp" && lastYDir == "Yn") { stepsEnd += 12; }
                                    if (vectorDirection[i] == "Yn" && lastYDir == "Yp") { stepsEnd += 12; }
                                } else {
                                    if (vectorDirection[i] == "Yp" && vectorDirection[i - 1] == "Yn") { stepsEnd += 12; }
                                    if (vectorDirection[i] == "Yn" && vectorDirection[i - 1] == "Yp") { stepsEnd += 12; }
                                }
                            }

                            string dir = "";
                            switch(vectorDirection[i]) {
                                case "Xp":
                                    dir = "XR";
                                    break;

                                case "Xn":
                                    dir = "XL";
                                    break;

                                case "Yp":
                                    dir = "YU";
                                    break;

                                case "Yn":
                                    dir = "YD";
                                    break;
                            }

                            PrinterQuery.AddCommand("M" + dir + "(" + stepsEnd + ")");
                            i++;
                        }
                        
                        lastI = i;
                        currectDrawingRouteI++;
                    }
                    PrinterQuery.Start();
                }
            }
        }

        private void buttonDrill_Click(object sender, EventArgs e) {
            tabControl.SelectedIndex = 1;

            decimal DpiXRadio = (decimal)(PrinterControl.xRadio * 25.4F / PrinterControl.Dpi);
            decimal DpiYRadio = (decimal)(PrinterControl.yRadio * 25.4F / PrinterControl.Dpi);

            for (int modeI = 1; modeI <= 2; modeI++ ) {
                if (modeI == 1) {
                    PrinterControl.SetDefaultPosDrill();
                    PrinterQuery.AddCommand("MZD(140)");
                } else if (modeI == 2) {
                    PrinterControl.SetDefaultPosPen();
                }
                Thread.Sleep(50);
                Application.DoEvents();

                for (int holeI = 0; holeI < drillPointCount; holeI++) {
                    listBoxPointsDrill.SelectedIndex = holeI;

                    int moveX, moveY;
                    if (holeI != 0){
                        moveX = drillPointX[holeI] - drillPointX[holeI - 1];
                        moveY = drillPointY[holeI] - drillPointY[holeI - 1];
                    } else { moveX = drillPointX[holeI]; moveY = drillPointY[holeI]; }

                    int stepsStartX = (int)Math.Round((Math.Abs(moveX) * DpiXRadio), 0);
                    int stepsStartY = (int)Math.Round((Math.Abs(moveY) * DpiYRadio), 0);

                    string xDir, yDir;
                    if (moveX < 0) { xDir = "XL"; } else { xDir = "XR"; }
                    if (moveY < 0) { yDir = "YD"; } else { yDir = "YU"; }

                    PrinterQuery.AddCommand("M" + xDir + "(" + stepsStartX + ")");
                    PrinterQuery.AddCommand("M" + yDir + "(" + stepsStartY + ")");
                    
                    if (modeI == 1){
                        //Mod vrtačky
                        PrinterQuery.AddCommand("SDR");
                        PrinterQuery.AddCommand("SDD");
                    }else if (modeI == 2) {
                        //Mod tužky
                        PrinterQuery.AddCommand("SPD");
                        PrinterQuery.AddCommand("SPU");
                    }
                }
            }

            PrinterQuery.Start();

        }

        private void buttonPrintAndDraw_Click(object sender, EventArgs e) {
            if (Serial.IsOpen() == true) {
                buttonPrint.PerformClick();
                Thread.Sleep(500);
                Application.DoEvents();
                buttonDrill.PerformClick();
                Thread.Sleep(50);
                Application.DoEvents();
                PrinterControl.SetDefaultPosDrill();
            }
        }

        private void timerPrinterCheck_Tick(object sender, EventArgs e) {
            /*
            if (testTimerTicks == 0) { timerPrinterCheck.Enabled = false; }

            bool status = PrinterControl.GetSenstorState(128);
            if (testTimerTicks == 0 && status == true){
                try { 
                    Serial.Close();
                } catch (Exception) { }
                picOpenPort.BackColor = Color.Maroon;
                btnPort.Text = "Otevřít port";
                toolPortStatus.Text = "Stav portu: Port je uzavřen!";
                debugAddLine("Tiskárna není připojena!");
                debugAddLine("Port byl uzavřen");
            } else { testTimerTicks--; }
            */
        }

    }

}
