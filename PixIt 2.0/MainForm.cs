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

namespace PixIt_2._0
{
    public partial class Main : Form
    {
        Bitmap LoadedImage;
        Bitmap ShowVectors;
        Settings settingsForm;

        //Delegát pro práci s DataReceived_Event
        delegate void SetTextCallback(string text);

        //Vytvoření handleru pro sériový port
        SerialPort mainSerialPort = new SerialPort();

        int x = 0;
        int y = 0;
        int vectorI = 0;
        bool settingsFormOpen = false;

        int[] vectorStartX = new int[500];
        int[] vectorStartY = new int[500];
        int[,] point = new int[400,400];
        int pointI = 0;
        bool licha = true;
        int size = 0;
        int[] vectorEndX = new int[500];
        int[] vectorEndY = new int[500];
        string[] vectorDirection = new string[500];
        int[] vectorPx= new int[500];
        //int[] pointX = new int[500];
        //int[] pointY = new int[500];

        public static string settingColor = "";

        public static Color colorPath = Color.White;
        public static Color colorDrill = Color.White;
        public static Color colorTranslation = Color.White;
        public static int numericPort = 3;


        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,string key, string def, StringBuilder retVal, int size, string filePath);

        public void IniWriteValue(string path, string Section, string Key, string Value)
        {
            var totalPath = Path.Combine(Application.StartupPath, path);
            WritePrivateProfileString(Section, Key, Value, totalPath);
        }

        public string IniReadValue(string path, string Section, string Key)
        {
            var totalPath = Path.Combine(Application.StartupPath, path);
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, totalPath);
            return temp.ToString();
        }

        private void ReloadPictureBoxs()
        {
            pictureBox_Bitmap_Original.Image = (Image)LoadedImage;
        }

        //Funkce pro převod do binární soustavy
        private string toBinary(int data)
        {
            string bufferData = "";
            while (data > 0)
            {
                bufferData += data % 2;
                data = data / 2;
            }

            return bufferData;
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Dialog_OpenFile.Filter = "All Files (*.*)|*.*";
            Dialog_OpenFile.FilterIndex = 1;

            //Načtení nastavení z INI
            if (File.Exists(Path.Combine(Application.StartupPath, "settings.ini")) == true){
                colorPath = Color.FromArgb(Convert.ToInt32(IniReadValue("settings.ini", "Colors", "path")));
                colorDrill = Color.FromArgb(Convert.ToInt32(IniReadValue("settings.ini", "Colors", "drill")));
                colorTranslation = Color.FromArgb(Convert.ToInt32(IniReadValue("settings.ini", "Colors", "translation")));
                numericPort = Convert.ToInt32(IniReadValue("settings.ini", "COM", "port"));
            }
        }

        private void buttonOpenPort_Click(object sender, EventArgs e)
        {
            //Nastavení o tevření portu
            mainSerialPort.PortName = "COM" + numericPort.ToString();
            mainSerialPort.BaudRate = 115200;
            mainSerialPort.Parity = Parity.None;
            mainSerialPort.StopBits = StopBits.One;
            mainSerialPort.DataBits = 8;
            mainSerialPort.Handshake = Handshake.None;
            mainSerialPort.DataReceived += DataReceived_Read;
            mainSerialPort.DtrEnable = true;
            mainSerialPort.RtsEnable = true;
            mainSerialPort.Close();

            try{
                mainSerialPort.Open();
            }catch (Exception ex){
                labelPortStatus.Text = ex.GetType().ToString();
            }


            if (mainSerialPort.IsOpen == true){
                labelPortStatus.Text = "Port je otevřen!";
            }
        }

        //Čtení ze Sériového portu
        private void DataReceived_Read(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort mySerial = (SerialPort)sender;

            if (this.InvokeRequired)
            {
                listBoxSerialRead.BeginInvoke(new MethodInvoker(delegate
                {
                    listBoxSerialRead.Items.Add(mySerial.ReadChar());
                    listBoxSerialRead.SelectedIndex = listBoxSerialRead.Items.Count - 1;
                }));
            }
        }

        private void pictureBox_BitMap_MouseDown(object sender, MouseEventArgs e)
        {
            switch(settingColor){
                case "path":
                    colorPath = LoadedImage.GetPixel(e.X, e.Y);
                break;

                case "drill":
                    colorDrill = LoadedImage.GetPixel(e.X, e.Y);
                break;

                case "translation":
                    colorTranslation = LoadedImage.GetPixel(e.X, e.Y);
                break;

            }
            settingColor = ""; settingsForm.loadColors();
        }

        private void button_LoadImage_Click(object sender, EventArgs e)
        {
            DialogResult result = Dialog_OpenFile.ShowDialog();
	        if (result == DialogResult.OK){
                LoadedImage = new Bitmap(Dialog_OpenFile.FileName);
                button_draw.Enabled = true;             
                label5.Text = LoadedImage.Width.ToString() ;
                label6.Text = LoadedImage.Height.ToString() ;

                ReloadPictureBoxs();
            }
        }

        private bool isColorMatch(Color color)
        {
            bool retVal = false;
            if (color == colorPath || color == colorTranslation)
            {
                retVal = true;
            }

            return retVal;
        }

        private void button_Draw_Click(object sender, EventArgs e)
        {
            x = 0; y = 0;
            int pocet = 0;
            SaveLines(); // najde cesty v obvodu
            GetSize(); // zjistí šířku cest
            SaveLineEnds(); //uloží konce cest
            GetRouteVectors(); //převede cesty na vektory
            ReloadPictureBoxs(); // obnoví obrázek
            for (int i = 0; i < 400; i++)
            {
                for (int u = 0; u < 400; u++)
                {
                    if (point[i, u] == 11)
                    {
                        pocet++;
                    }
                }
            }
            x = 0; y = 0;
            labelI.Text = Convert.ToString(pocet);
        }
        private void SaveLines ()
        {
            Color thisPixel = LoadedImage.GetPixel(x, y);
            while (x < LoadedImage.Width - 1 || y < LoadedImage.Height - 1){
                thisPixel = LoadedImage.GetPixel(x, y);
                if (thisPixel == colorPath || thisPixel == colorTranslation){
                    point[x, y] = 1;
                    pointI++;
                }else{
                    point[x, y] = 2;
                    pointI++;
                }
                if (x < LoadedImage.Width - 1){
                     x++;
                }else{
                    x = 0; y++;
                }
            }labelI.Text = pointI.ToString(); x = 0; y = 0;
        }
        
        private void GetSize()
        {
            for (int i = 0; i < 400; i++)
            {
                if (point[i, i] != 1 && size > 0)
                {
                    if (size % 2 > 0) { size++; licha = true; }
                    else { licha = false; }
                    size = (int)Math.Round(Convert.ToDecimal(size / 2));
                    break;
                }
                else if (point[x + i, y + i] == 1)
                {
                    size++;
                }

            } labelI.Text = size.ToString(); x = 0; y = 0;
        }

        private void SaveLineEnds()
        {
            int citac = 0;
            for (int i = 0 + size + 1; i < 400 - size - 1; i++)
            {
                for (int u = 0 + size + 1; u < 400 - size - 1; u++)
                {
                    if (point[i, u] == 1 && point[i, u + 1] != 11 && point[i, u - 1] != 11 && point[i + 1, u] != 11 && point[i - 1, u] != 11)
                    {
                        if (point[i, u - 1] != 1 && point[i + size, u] != 1 && point[i, u + size + 2] == 1 && point[i - size - 1, u] != 1)//top ends
                        {
                            LoadedImage.SetPixel(i, u, Color.White);
                            point[i, u] = 11;
                            vectorDirection[u] = "Yp";
                            citac++;
                        }
                        else if (point[i, u - size - 2] == 1 && point[i + size, u] != 1 && point[i, u + 1] != 1 && point[i - size - 1, u] != 1)// bottom ends
                        {
                            LoadedImage.SetPixel(i, u, Color.White);
                            point[i, u] = 11;
                            vectorDirection[u] = "Yn";
                            citac++;
                        }
                        else if (point[i, u - size - 1] != 1 && point[i + size + 2, u] == 1 && point[i, u + size] != 1 && point[i - 1, u] != 1)// left ends
                        {
                            LoadedImage.SetPixel(i, u, Color.White);
                            point[i, u] = 11;
                            vectorDirection[i] = "Xn";
                            citac++;
                        }
                        else if (point[i, u - size - 1] != 1 && point[i + 1, u] != 1 && point[i, u + size] != 1 && point[i - size - 2, u] == 1)// right ends
                        {
                            LoadedImage.SetPixel(i, u, Color.White);
                            point[i, u] = 11;
                            vectorDirection[i] = "Xp";
                            citac++;
                        }
                        else if (point[i, u] == 1 && point[i + size + 1, u - 1] == 1 && point[i + 1, u - size - 1] == 1 && point[i + size + 1, u - size - 1] == 1 && point[i - 1, u] != 1 && point[i, u + 1] != 1 && point[i, u - size - 1] != 1 && point[i + size + 1, u] != 1)// left-down slant end
                        {
                            LoadedImage.SetPixel(i, u, Color.White);
                            point[i, u] = 11;
                            vectorDirection[u+i] = "YnXp";
                            citac++;
                        }
                    }
                }
            }
        }
        
        private void GetRouteVectors()
        {
            int citac = 0;
            int vectornumber = 0;
            for (int i = 0; i < 400; i++)
            {
                for (int u = 0; u < 400; u++)
                {
                    if (point[i, u] == 11 && vectorDirection[u] == "Yp")
                    {
                        do
                        {
                            LoadedImage.SetPixel(i, u, Color.White);
                            u++;
                            citac++;
                        } while (point[i, u + size] != 2);
                        listBox_Vectors.Items.Add("[" + i + "," + (u-citac) + "] [" + i + "," + u + "]");                       
                        vectorStartX[vectornumber] = i;
                        vectorStartY[vectornumber] = u - citac;
                        vectorEndY[vectornumber] = u;
                        vectorDirection[vectornumber] = "Yp";
                        vectornumber++;
                        u = u - citac;
                        citac = 0;
                    }
                    else if (point[i, u] == 11 && vectorDirection[u] == "Yn")
                    {
                        do
                        {
                            LoadedImage.SetPixel(i, u, Color.White);
                            u--;
                            citac++;
                        } while (point[i, u - size] != 2);
                        listBox_Vectors.Items.Add("[" + i + "," + (u + citac) + "] [" + i + "," + u + "]");
                        vectorStartX[vectornumber] = i;
                        vectorStartY[vectornumber] = u + citac;
                        vectorEndY[vectornumber] = u;
                        vectorDirection[vectornumber] = "Yn";
                        vectornumber++;
                        u = u + citac;
                        citac = 0;
                    }
                }
            }
        }
/*
        private void SaveLineMiddles()
        {
            for (int i = 0 + size + 3; i < 400 - size - 3; i++)
            {
                for (int u = 0 + size + 1; u < 400 - size - 1; u++)
                {
                    if (point[i, u] == 1 && point[i, u + 1] != 11 && point[i, u - 1] != 11 && point[i + 1, u] != 11 && point[i - 1, u] != 11)
                    {
                        if (licha == false)
                        {
                            if (point[i - size - 1, u - size - 1] != 1 && point[i + size, u - size - 1] != 1 && point[i + size, u + size] != 1 && point[i - size - 1, u + size] != 1)
                            {
                                if (point[i + size, u] == 1 && point[i - size, u] == 1 && (point[i, u + size] == 1 || point[i, u - size] == 1))
                                {
                                    LoadedImage.SetPixel(i, u, Color.Red);
                                    point[i, u] = 12;
                                }
                                else if (point[i, u + size] == 1 && point[i, u - size] == 1 && (point[i + size, u] == 1 || point[i - size, u] == 1))
                                {
                                    LoadedImage.SetPixel(i, u, Color.Red);
                                    point[i, u] = 12;
                                }
                            }
                        }
                        else if (licha == true)
                        {
                            if (point[i, u] == 1 && point[i, u + size] != 12 && point[i, u - size] != 12 && point[i + size, u] != 12 && point[i - size, u] != 12 && point[i, u + size] != 11 && point[i, u - size] != 11 && point[i + size, u] != 11 && point[i - size, u] != 11) //bod nesmí sousedit se zkontrolovanými skupinami
                            {
                                if (point[i - size, u - size] != 1 && point[i + size, u - size] != 1 && point[i + size, u + size] != 1 && point[i - size, u + size] != 1)// jedná se o středový bod
                                {
                                    if (point[i + size, u] == 1 && point[i - size, u] == 1 && (point[i, u + size] == 1 || point[i, u - size] == 1)) //  rozcestníky z X
                                    {
                                        LoadedImage.SetPixel(i, u, Color.White);
                                        point[i, u] = 11;
                                    }
                                    else if (point[i, u + size] == 1 && point[i, u - size] == 1 && (point[i + size, u] == 1 || point[i - size, u] == 1))// rozcestníky z Y
                                    {
                                        LoadedImage.SetPixel(i, u, Color.White);
                                        point[i, u] = 11;
                                    }
                                    else if ((point[i, u + size] == 1 && point[i, u - size] != 1) || (point[i + size, u] == 1 && point[i - size, u] != 1))// rohy leve- horní, dolní
                                    {
                                        LoadedImage.SetPixel(i, u, Color.Red);
                                        point[i, u] = 12;
                                    }
                                    else if ((point[i, u + size] != 1 && point[i, u - size] == 1) || (point[i + size, u] != 1 && point[i - size, u] == 1))// rohy pravé - horní, dolní
                                    {
                                        LoadedImage.SetPixel(i, u, Color.Red);
                                        point[i, u] = 12;
                                    }
                                }
                            }
                            if (point[i, u] == 1 && point[i + size + 1, u - 1] == 1 && point[i + 1, u - size - 1] == 1 && point[i + size + 1, u - size - 1] == 1 && point[i - 1, u] != 1 && point[i, u + 1] != 1 && point[i, u - size - 1] != 1 && point[i + size + 1, u] != 1)
                            {
                                LoadedImage.SetPixel(i, u, Color.Red);
                                point[i, u] = 12;
                            }
                        }
                    }
                }
            }
        }

        */
            /*
                for (int i = 3; i < 397; i++)
                {
                    for (int u = 3; u < 397; u++)
                    {                       
                        int sleft = point[i - 1, u]; int sright = point[i + 1, u]; int stop = point[i, u - 1]; int sbottom = point[i, u + 1];
                        int left = point[i - 2, u]; int right = point[i + 2, u]; int top = point[i, u - 2]; int bottom = point[i, u + 2];
                        int bleft = point[i - 3, u]; int bright = point[i + 3, u]; int btop = point[i, u - 3]; int bbottom = point[i, u + 3];
                        int pmiddle = point[i + 2, u - 2]; int nmiddle = point[i - 2, u + 2];
                        if (point[i, u] == 1 && left != 1 && bright == 1 && top != 1 && bbottom != 1 && pmiddle != 1 && sleft == 1 && stop == 1)
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                        }
                        else if (point[i, u] == 1 && left != 1 && right == 1 && top != 1 && bottom != 1 && sleft == 1)
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                        }
                        else if (point[i, u] == 1 && left == 1 && right != 1 && top != 1 && bottom != 1 && sright == 1)
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                        }
                        else if (point[i, u] == 1 && left != 1 && right != 1 && top != 1 && bottom == 1 && stop == 1)
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                        }
                        else if (point[i, u] == 1 && left != 1 && right != 1 && top == 1 && bottom != 1 && sbottom == 1)
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                        }
                        else if (point[i, u] == 1 && left != 1 && right == 1 && top != 1 && bottom == 1 && stop == 1 && sleft == 1 && pmiddle != 1 && point[i + 2, u + 1] == 1) //top-left
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                        }
                        else if (point[i, u] == 1 && left == 1 && right != 1 && top != 1 && bottom == 1 && point[i, u - 1] == 1 && point[i + 1, u] == 1) //top-right
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                        }
                        else if (point[i, u] == 1 && left != 1 && right == 1 && top == 1 && bottom != 1 && point[i, u + 1] == 1 && point[i - 1, u] == 1) //bottom-left
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                        }
                        else if (point[i, u] == 1 && left == 1 && right != 1 && top == 1 && bottom != 1 && point[i, u + 1] == 1 && point[i + 1, u] == 1 && point[i - 2, u + 2] != 1 && point[i + 1, u + 1] == 1) //bottom-right
                        {
                            LoadedImage.SetPixel(i, u, Color.Red);
                        }
                    }
                } ReloadPictureBoxs();
            */
            /*
            Color thisPixel;
            x = 0;
            y = 0;
            while (x < LoadedImage.Width - 1 || y < LoadedImage.Height - 1)
            {
               thisPixel = LoadedImage.GetPixel(x, y);
               if (thisPixel == colorPath || thisPixel == colorTranslation)
               {
                    point[pointI] = new Point(x, y);
                    pointI++;
               }

               if (x < LoadedImage.Width - 1)
               {
                   x++;
               }
               else
               {
                   x = 0; y++;
               }
            } ReloadPictureBoxs(); x = 0; y = 0; labelI.Text = pointI.ToString();
            int citac = 0;
            for (int i=0; i < pointI; i++)
            {
                */
            /*
            Color col0X;
            Color col1X;
            Color col0Y;
            Color col1Y;
            col0X = LoadedImage.GetPixel(point[i].X+2, point[i].Y);
            col1X = LoadedImage.GetPixel(point[i].X+2, point[i].Y);
            col0Y = LoadedImage.GetPixel(point[i].X, point[i].Y-2);
            col1Y = LoadedImage.GetPixel(point[i].X, point[i].Y+2);
            //if ((isColorMatch(col0X)==true && isColorMatch(col0Y)==true) && (isColorMatch(col0X)==true && isColorMatch(col1Y)==true) 
            //    ||(isColorMatch(col1X)==true && isColorMatch(col0Y)==true) && (isColorMatch(col1X)==true && isColorMatch(col1Y)==true))
            if (isColorMatch(col0X) != true && isColorMatch(col1X) != true && isColorMatch(col0Y) != true && isColorMatch(col1Y) == true)
            {
                point2[citac].X = point[i].X;
                point2[citac].Y = point[i].Y;
                citac++;
            }
            else if (isColorMatch(col0X) != true && isColorMatch(col1X) != true && isColorMatch(col0Y) == true && isColorMatch(col1Y) != true)
            {
                point2[citac].X = point[i].X;
                point2[citac].Y = point[i].Y;
                citac++;
            }
            else if (isColorMatch(col0X) != true && isColorMatch(col1X) == true && isColorMatch(col0Y) != true && isColorMatch(col1Y) != true)
            {
                point2[citac].X = point[i].X;
                point2[citac].Y = point[i].Y;
                citac++;
            }
            else if (isColorMatch(col0X) == true && isColorMatch(col1X) != true && isColorMatch(col0Y) != true && isColorMatch(col1Y) != true)
            {
                point2[citac].X = point[i].X;
                point2[citac].Y = point[i].Y;
                citac++;
            }
            else if (isColorMatch(col0X) != true && isColorMatch(col1X) == true && isColorMatch(col0Y) == true && isColorMatch(col1Y) != true)
            {
                point2[citac].X = point[i].X;
                point2[citac].Y = point[i].Y;
                citac++;
            }
            else if (isColorMatch(col0X) == true && isColorMatch(col1X) != true && isColorMatch(col0Y) == true && isColorMatch(col1Y) != true)
            {
                point2[citac].X = point[i].X;
                point2[citac].Y = point[i].Y;
                citac++;
            }
            else if (isColorMatch(col0X) != true && isColorMatch(col1X) == true && isColorMatch(col0Y) != true && isColorMatch(col1Y) == true)
            {
                point2[citac].X = point[i].X;
                point2[citac].Y = point[i].Y;
                citac++;
            }
            else if (isColorMatch(col0X) == true && isColorMatch(col1X) != true && isColorMatch(col0Y) != true && isColorMatch(col1Y) == true)
            {
                point2[citac].X = point[i].X;
                point2[citac].Y = point[i].Y;
                citac++;
            }
        } labelI.Text = citac.ToString();
        */
            /*button_draw.Enabled = false;

             int stop = 0;
             while (x < LoadedImage.Width - 1 || y <  LoadedImage.Height-1)
             {
                
                 Color thisPixel;
                 if (listBox_mode.SelectedIndex == 0)
                 {
                     thisPixel = LoadedImage.GetPixel(x, y);
                     if (thisPixel == colorPath || thisPixel == colorTranslation)
                     {
                         Color pixelXp; Color pixelXn; Color pixelYp; Color pixelYn;
                         while (true)
                         {
                             pixelXp = LoadedImage.GetPixel(x + 1, y);
                             pixelXn = LoadedImage.GetPixel(x - 1, y);
                             pixelYp = LoadedImage.GetPixel(x, y + 1);
                             pixelYn = LoadedImage.GetPixel(x, y - 1);

                             if (pixelXp == colorPath || pixelXp == colorTranslation) { tryDirection("Xp"); }
                             else
                                 if (pixelXn == colorPath || pixelXn == colorTranslation) { tryDirection("Xn"); }
                                 else
                                     if (pixelYp == colorPath || pixelYp == colorTranslation) { tryDirection("Yp"); }
                                     else
                                         if (pixelYn == colorPath || pixelYn == colorTranslation) { tryDirection("Yn"); } else { break; }
                         }
                         x = 0; y = 0;


                         //stop++;
                         //if (stop > 1){ break; }
                     }
                 }

                 if (x != LoadedImage.Width - 1) { x++; } else { y++; x = 0; }
             }
             ReloadPictureBoxs();
             label4.Text = vectorI.ToString();
        }

        private void tryDirection(string direction)
        {*/
            /*
            int lineI = 0; int startX = 0; int startY = 0;
            Color pixelColor = Color.White;
            Color pixelColor2 = Color.White;

             while (true)
             {
                switch (direction)
                {
                    case "Xp":
                        pixelColor = LoadedImage.GetPixel(x + 1, y);
                        break;

                    case "Xn": 
                        pixelColor = LoadedImage.GetPixel(x - 1, y);
                        break;

                    case "Yp":
                        pixelColor = LoadedImage.GetPixel(x, y + 1);
                        break;

                    case "Yn": 
                        pixelColor = LoadedImage.GetPixel(x, y - 1);
                        break;
                }

                //Překreslení pixelu
                LoadedImage.SetPixel(x, y, Color.Red);

                if (pixelColor == colorPath || pixelColor == colorTranslation)
                {
                    //Posunutí na další
                    if (startX == 0 && startY == 0) {startX = x; startY = y;}
                    switch (direction) {
                        case "Xp": x++; break;
                        case "Xn": x--; break;
                        case "Yp": y++; break;
                        case "Yn": y--; break;
                    }
                    lineI++;

                }else{
                    if (pixelColor2 == colorPath || pixelColor2 == colorTranslation) {
                        /*if (startX == 0 && startY == 0) { startX = x; startY = y; }
                        switch (direction)
                        {
                            case "Xp": x++; break;
                            case "Xn": x--; break;
                            case "Yp": y++; break;
                            case "Yn": y--; break;
                        }
                        lineI++;*/
        /* }else{

             for (int i = 0; i < lineI; i++){
                 switch (direction)
                 {
                     case "Xp":
                             if(LoadedImage.GetPixel(startX + i, startY+1) == colorPath || LoadedImage.GetPixel(startX+i, startY+1) == colorTranslation ){
                                 LoadedImage.SetPixel(startX + i, startY + 1, Color.Red);
                                 LoadedImage.SetPixel(startX + i, startY + 2, Color.Red);
                             }

                             if (LoadedImage.GetPixel(startX + i, startY - 1) == colorPath || LoadedImage.GetPixel(startX + i, startY - 1) == colorTranslation){
                                 LoadedImage.SetPixel(startX + i, startY - 1, Color.Red);
                                 LoadedImage.SetPixel(startX + i, startY - 2, Color.Red);
                             }
                         break;

                     case "Xn":
                             if(LoadedImage.GetPixel(startX - i, startY+1) == colorPath || LoadedImage.GetPixel(startX-i, startY+1) == colorTranslation ){
                                 LoadedImage.SetPixel(startX - i, startY + 1, Color.Red);
                                 LoadedImage.SetPixel(startX - i, startY + 2, Color.Red);
                             }

                             if (LoadedImage.GetPixel(startX - i, startY - 1) == colorPath || LoadedImage.GetPixel(startX - i, startY - 1) == colorTranslation){
                                 LoadedImage.SetPixel(startX - i, startY - 1, Color.Red);
                                 LoadedImage.SetPixel(startX - i, startY - 2, Color.Red);
                             }
                         break;

                     case "Yp":
                             if(LoadedImage.GetPixel(startX + 1, startY + i) == colorPath || LoadedImage.GetPixel(startX + 1, startY + i) == colorTranslation ){
                                 LoadedImage.SetPixel(startX + 1, startY + i, Color.Red);
                                 LoadedImage.SetPixel(startX + 2, startY + i, Color.Red);
                             }

                             if (LoadedImage.GetPixel(startX - 1, startY + i) == colorPath || LoadedImage.GetPixel(startX - 1, startY + i) == colorTranslation){
                                 LoadedImage.SetPixel(startX - 1, startY + i, Color.Red);
                                 LoadedImage.SetPixel(startX - 2, startY + i, Color.Red);
                             }
                         break;

                     case "Yn":
                             if(LoadedImage.GetPixel(startX + 1, startY - i) == colorPath || LoadedImage.GetPixel(startX + 1, startY - i) == colorTranslation ){
                                 LoadedImage.SetPixel(startX + 1, startY - i, Color.Red);
                                 LoadedImage.SetPixel(startX + 2, startY - i, Color.Red);
                             }

                             if (LoadedImage.GetPixel(startX - 1, startY - i) == colorPath || LoadedImage.GetPixel(startX - 1, startY - i) == colorTranslation){
                                 LoadedImage.SetPixel(startX - 1, startY - i, Color.Red);
                                 LoadedImage.SetPixel(startX - 2, startY - i, Color.Red);
                             }
                         break;
                 }
             }

             vectorStartX[vectorI] = startX;
             vectorStartY[vectorI] = startY;

             switch (direction) {
                 case "Xp": vectorEndX[vectorI] = startX + lineI; vectorEndY[vectorI] = startY; break;
                 case "Xn": vectorEndX[vectorI] = startX - lineI; vectorEndY[vectorI] = startY; break;
                 case "Yp": vectorEndX[vectorI] = startX; vectorEndY[vectorI] = startY + lineI; break;
                 case "Yn": vectorEndX[vectorI] = startX; vectorEndY[vectorI] = startY - lineI; break;
             }

             //Zapsání do tabulky
             //listBox_Vectors.Items.Add("[" + startX + "," + startY + "] "+direction+" " + lineI + "px");
             listBox_Vectors.Items.Add("[" + startX + "," + startY + "] ["+vectorEndX[vectorI]+","+vectorEndY[vectorI]+"]");

             vectorDirection[vectorI] = direction;
             vectorPx[vectorI] = lineI;

             vectorI++;
             lineI = 0;
             startX = 0;
             startY = 0;
             break;
         }
     }
 }
    }*/

        private void button_settings_Click(object sender, EventArgs e)
        {
            if (settingsFormOpen == false) {
                settingsFormOpen = true;
                settingsForm = new Settings();
                settingsForm.FormClosed += new FormClosedEventHandler(settings_close);
                settingsForm.Show();
            }
        }

        private void settings_close(object sender, FormClosedEventArgs e)
        {
            //Zapsání nastavení do INI
            settingsFormOpen = false;
            IniWriteValue("settings.ini", "Colors", "path", colorPath.ToArgb().ToString());
            IniWriteValue("settings.ini", "Colors", "drill", colorDrill.ToArgb().ToString());
            IniWriteValue("settings.ini", "Colors", "translation", colorTranslation.ToArgb().ToString());
            IniWriteValue("settings.ini", "COM", "port", numericPort.ToString());
        }

        private void listBox_Vectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowVectors = new Bitmap(pictureBox_DrawVectors.Width, pictureBox_DrawVectors.Height);

            int drawX = 0; int drawY = 0; int drawYEnd = 0;
            //for (int i = 0; i < vectorPx[listBox_Vectors.SelectedIndex]; i++)
            //{
                
                //if(i==0){
                    drawX = vectorStartX[listBox_Vectors.SelectedIndex];
                    drawY = vectorStartY[listBox_Vectors.SelectedIndex];
                    drawYEnd = vectorEndY[listBox_Vectors.SelectedIndex] - vectorStartY[listBox_Vectors.SelectedIndex];
                    ShowVectors.SetPixel(drawX, drawY, Color.Green);
                    for (int i = 0; i < drawYEnd; i++)
                    {
                        ShowVectors.SetPixel(drawX, drawY + i, Color.Green);
                    }
                        //}else{
                        //switch (vectorDirection[listBox_Vectors.SelectedIndex]) {
                        //case "Xp": drawX++; break;
                        //case "Xn": drawX--; break;
                        //case "Yp": drawY++; break;
                        //case "Yn": drawY--; break;
                        //}
                        //}
                        //}
                        pictureBox_DrawVectors.Image = (Image)ShowVectors;
        }

        private void pictureBox_Bitmap_Original_MouseMove(object sender, MouseEventArgs e)
        {
            if (settingsFormOpen == true && e.X < LoadedImage.Width && e.X > 0 && e.Y < LoadedImage.Height && e.Y > 0)
            {
                settingsForm.pictureBox_cursorColor.BackColor = LoadedImage.GetPixel(e.X, e.Y);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int myPoint = point[x,y];
            labelX.Text = myPoint.ToString();

            LoadedImage.SetPixel(x, y, Color.Red);
            ReloadPictureBoxs();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
                if (x < LoadedImage.Width - 1)
                {
                    x++;
                }
                else
                {
                    x = 0; y++;
                }
        }
    }
}
