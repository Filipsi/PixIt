using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PixIt_0._3 {

    static class PixItCore {

        private static string[, ,] point = new string[1000, 1000, 20];

        private static int[] pointX = new int[10000];
        private static int[] pointY = new int[10000];
        private static string[] directionPoint = new string[10000];
        private static int pointCount = 0;

        public static int[] drillPointX = new int[10000];
        public static int[] drillPointY = new int[10000];
        private static int drillPointCount = 0;

        public static int[] vectorStartX = new int[10000];
        public static int[] vectorStartY = new int[10000];
        public static int[] vectorEndX = new int[10000];
        public static int[] vectorEndY = new int[10000];
        public static string[] vectorDirection = new string[10000];
        public static int[] vectorRouteI = new int[10000];
        public static int[] vectorLength = new int[10000];
        public static int vectorCount = 0;
        private static int vectorRoutesCount = 1;

        private static int x = 0;
        private static int y = 0;

        //Bitmapa
        public static Bitmap LoadedImage;

        //Nastavení vykreslování
        public static Color colorPath = Color.White;
        public static Color colorDrill = Color.White;
        public static Color colorTranslation = Color.White;
        public static bool drawSolderingAreas = false;

        public static void ClearMemeory() {
            Program.Form.listBoxPoints.Items.Clear();
            Program.Form.listBoxPointsDrill.Items.Clear();
            Program.Form.listBoxVectors.Items.Clear();
            BitmapPixelPointer.DisposeAll();

            point = new string[1000, 1000, 20];
            pointX = new int[10000];
            pointY = new int[10000];
            directionPoint = new string[10000];
            pointCount = 0;
            drillPointX = new int[10000];
            drillPointY = new int[10000];
            drillPointCount = 0;
            vectorStartX = new int[10000];
            vectorStartY = new int[10000];
            vectorEndX = new int[10000];
            vectorEndY = new int[10000];
            vectorDirection = new string[10000];
            vectorRouteI = new int[10000];
            vectorLength = new int[10000];
            vectorCount = 0;
            vectorRoutesCount = 1;
            x = 0;
            y = 0;

            if(LoadedImage != null) { LoadedImage.Dispose(); }
        }

        //Vrátí startovní I trasy
        private static int GetRouteIStart(int routeI) {
            int retVal = -1;
            for(int i = 0; i <= vectorCount; i++) {
                if(vectorRouteI[i] == routeI) {
                    retVal = i;
                    break;
                }
            }

            return retVal;
        }

        //Vrátí index bodu, který je nejbližší začátku pole a má pouze jeden platný směr
        private static int GetStartPoint() {
            int retVal = -1;

            for(int i = 0; i < pointCount; i++) {
                if(pointX[i] != 0 && pointY[i] != 0) {
                    string XDir = directionPoint[i].Substring(directionPoint[i].IndexOf("X") + 1, 1);
                    string YDir = directionPoint[i].Substring(directionPoint[i].IndexOf("Y") + 1, 1);

                    if(XDir == "0" && (YDir == "p" || YDir == "n")) {
                        retVal = i;
                        break;
                    } else if(YDir == "0" && (XDir == "p" || XDir == "n")) {
                        retVal = i;
                        break;
                    }
                }
            }

            return retVal;
        }

        //Zjistí trasy v obrázku
        private static void GetRoutes() {
            int citac = 0;
            int citac2 = 0;
            Color thisPixel = LoadedImage.GetPixel(x, y);

            while(x < LoadedImage.Width - 1 || y < LoadedImage.Height - 1) {
                thisPixel = LoadedImage.GetPixel(x, y);
                if(thisPixel == colorPath || thisPixel == colorTranslation) {
                    point[x, y, 0] = "ROUTE";
                    citac++;
                } else {
                    point[x, y, 0] = "NULL";
                }

                if(thisPixel == colorDrill || thisPixel == colorTranslation) {
                    point[x, y, 10] = "DRILL";
                    citac2++;
                } else {
                    point[x, y, 10] = "NULL";
                }

                if(x < LoadedImage.Width - 1) {
                    x++;
                } else {
                    x = 0; y++;
                }
            }

            Program.DebugAddLine("V obrázku je " + citac + " pixelů trasy");
            Program.DebugAddLine("V obrázku je " + citac2 + " pixelů vrtani");
        }

        //Zjistí body
        private static void GetPoints() {
            for(int u = 2; u < LoadedImage.Height; u++) {
                for(int i = 2; i < LoadedImage.Width; i++) {
                    if(point[i, u, 0] == "ROUTE") {
                        if(point[i + 3, u, 0] == "ROUTE" && point[i - 2, u, 0] == "NULL" && point[i, u + 2, 0] == "ROUTE" && point[i, u - 2, 0] == "NULL" && point[i, u + 3, 0] == "NULL" && point[i, u - 1, 0] == "ROUTE" && point[i + 2, u + 1, 0] == "ROUTE") {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XpY0";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XpY0";

                            pointCount++;
                        } else if(point[i + 2, u, 0] == "ROUTE" && point[i - 1, u, 0] == "NULL" && point[i, u + 1, 0] == "NULL" && point[i, u - 2, 0] == "ROUTE" && point[i + 3, u, 0] == "NULL" && point[i, u - 3, 0] == "NULL") {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XpYn";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XpYn";

                            pointCount++;
                        } else if(point[i + 2, u, 0] == "ROUTE" && point[i - 1, u, 0] == "NULL" && point[i, u + 2, 0] == "NULL" && point[i, u - 2, 0] == "NULL") {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XpY0";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XpY0";

                            pointCount++;
                        } else if(point[i + 1, u, 0] == "NULL" && point[i - 2, u, 0] == "ROUTE" && point[i, u + 2, 0] == "NULL" && point[i, u - 2, 0] == "NULL") {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XnY0";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XnY0";

                            pointCount++;
                        } else if(point[i + 2, u, 0] == "NULL" && point[i - 2, u, 0] == "NULL" && point[i, u + 2, 0] == "ROUTE" && point[i, u - 1, 0] == "NULL") {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "X0Yp";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "X0Yp";

                            pointCount++;
                        } else if(point[i + 2, u, 0] == "NULL" && point[i - 2, u, 0] == "NULL" && point[i, u + 1, 0] == "NULL" && point[i, u - 2, 0] == "ROUTE") {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "X0Yn";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "X0Yn";

                            pointCount++;
                        } else if(point[i + 3, u, 0] == "ROUTE" && point[i - 2, u, 0] == "NULL" && point[i, u + 3, 0] == "ROUTE" && point[i, u - 3, 0] == "ROUTE" && point[i + 2, u - 2, 0] == "NULL" && point[i + 2, u + 2, 0] == "NULL") {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XpY1";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XpY1";

                            pointCount++;
                        } else if(point[i + 2, u, 0] == "NULL" && point[i - 3, u, 0] == "ROUTE" && point[i, u + 3, 0] == "ROUTE" && point[i, u - 3, 0] == "ROUTE" && point[i - 2, u - 2, 0] == "NULL" && point[i - 2, u + 2, 0] == "NULL") {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XnY1";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XnY1";

                            pointCount++;
                        } else if(point[i + 3, u, 0] == "ROUTE" && point[i - 3, u, 0] == "ROUTE" && point[i, u + 3, 0] == "ROUTE" && point[i, u - 2, 0] == "NULL" && point[i + 2, u + 2, 0] == "NULL" && point[i - 2, u + 2, 0] == "NULL") {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "X1Yp";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "X1Yp";

                            pointCount++;
                        } else if(point[i + 3, u, 0] == "ROUTE" && point[i - 3, u, 0] == "ROUTE" && point[i, u + 2, 0] == "NULL" && point[i, u - 3, 0] == "ROUTE" && point[i + 2, u - 2, 0] == "NULL" && point[i - 2, u - 2, 0] == "NULL") {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "X1Yn";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "X1Yn";

                            pointCount++;
                        } else if(point[i + 3, u, 0] == "ROUTE" && point[i - 2, u, 0] == "NULL" && point[i, u + 3, 0] == "ROUTE" && point[i, u - 2, 0] == "NULL" && point[i + 2, u + 2, 0] == "NULL") {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XpYp";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XpYp";

                            pointCount++;
                        } else if(point[i + 2, u, 0] == "NULL" && point[i - 3, u, 0] == "ROUTE" && point[i, u + 3, 0] == "ROUTE" && point[i, u - 2, 0] == "NULL" && point[i - 2, u + 2, 0] == "NULL") {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XnYp";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XnYp";

                            pointCount++;
                        } else if(point[i + 3, u, 0] == "ROUTE" && point[i - 2, u, 0] == "NULL" && point[i, u + 2, 0] == "NULL" && point[i, u - 3, 0] == "ROUTE" && point[i + 2, u - 2, 0] == "NULL") {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XpYn";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XpYn";

                            pointCount++;
                        } else if(point[i + 2, u, 0] == "NULL" && point[i - 3, u, 0] == "ROUTE" && point[i, u + 2, 0] == "NULL" && point[i, u - 3, 0] == "ROUTE" && point[i - 2, u - 2, 0] == "NULL") {
                            LoadedImage.SetPixel(i, u, Color.Red);
                            point[i, u, 1] = "XnYn";

                            pointX[pointCount] = i;
                            pointY[pointCount] = u;
                            directionPoint[pointCount] = "XnYn";

                            pointCount++;
                        } else if(point[i + 3, u, 0] == "ROUTE" && point[i - 3, u, 0] == "ROUTE" && point[i, u + 3, 0] == "ROUTE" && point[i, u - 3, 0] == "ROUTE") {
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

            Program.Form.ReloadPictureBox();
        }

        private static void GetDrills() {
            int citac = 0;

            for(int u = 2; u < LoadedImage.Height; u++) {
                for(int i = 2; i < LoadedImage.Width; i++) {
                    int v = 1;

                    if(point[i, u, 10] == "NULL") {
                        while(v <= 2) {
                            if(point[i - v, u - v, 10] == "DRILL") {
                                if(point[i + v, u + v, 10] != "DRILL" || point[i + v, u - v, 10] != "DRILL" || point[i - v, u + v, 10] != "DRILL" || point[i + 1, u, 10] == "DRILL" || point[i - 1, u, 10] == "DRILL" || point[i, u + 1, 10] == "DRILL" || point[i, u - 1, 10] == "DRILL") {
                                    v = 2;
                                } else {
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

            Program.DebugAddLine("V obrázku je " + citac + " pixelů vrtů");
        }

        //Zpracuje vektor
        private static void ProcessVector(int checkIndex, int i, string deleteDirection, bool deletePoint) {
            Program.DebugAddLine("  Nalezen bod: " + pointX[i] + "," + pointY[i]);

            //Uloží dvojci bodů jako vektor
            //Zapíše StartX/Y
            vectorStartX[vectorCount] = pointX[checkIndex];
            vectorStartY[vectorCount] = pointY[checkIndex];
            //Zapíše EndX/Y
            vectorEndX[vectorCount] = pointX[i];
            vectorEndY[vectorCount] = pointY[i];
            //Zapíše direction
            string direction = "";
            if(pointX[checkIndex] > pointX[i]) { direction += "Xn"; } else if(pointX[checkIndex] < pointX[i]) { direction += "Xp"; }

            if(pointY[checkIndex] > pointY[i]) { direction += "Yn"; } else if(pointY[checkIndex] < pointY[i]) { direction += "Yp"; }

            vectorDirection[vectorCount] = direction;

            //Uloží délku
            if(vectorDirection[vectorCount].Substring(0, 1) == "X") { vectorLength[vectorCount] = vectorEndX[vectorCount] - vectorStartX[vectorCount]; } else if(vectorDirection[vectorCount].Substring(0, 1) == "Y") { vectorLength[vectorCount] = vectorEndY[vectorCount] - vectorStartY[vectorCount]; }
            vectorLength[vectorCount] = Math.Abs(vectorLength[vectorCount]);

            vectorRouteI[vectorCount] = vectorRoutesCount;
            Program.Form.listBoxVectors.Items.Add(vectorRouteI[vectorCount] + " [" + vectorStartX[vectorCount] + "," + vectorStartY[vectorCount] + "] -> [" + vectorEndX[vectorCount] + "," + vectorEndY[vectorCount] + "] (" + vectorDirection[vectorCount] + " : " + vectorLength[vectorCount] + ")");

            //Uloží
            vectorCount++;

            //Smaže první (začáteční) bod
            if(deletePoint) {
                pointX[checkIndex] = 0;
                pointY[checkIndex] = 0;
            }

        }

        //Najde nejbližší platný bod pro zadaný bod
        private static int ComparePoints(int pointIndex, string direction) {
            int retVal = 0;
            int compareValue;
            int minCompareIndex = -1;

            switch(direction) {
                case "Yp":
                    compareValue = LoadedImage.Height;

                    for(int i = 0; i < pointCount; i++) {
                        string YDir = directionPoint[i].Substring(directionPoint[i].IndexOf("Y") + 1, 1);

                        if(pointX[pointIndex] == pointX[i] && pointY[i] < compareValue && YDir == "n" && pointY[i] > pointY[pointIndex]) {
                            compareValue = pointY[i];
                            minCompareIndex = i;
                            Program.DebugAddLine("Nalezen směr!");
                        }

                        if(pointX[pointIndex] == pointX[i] && pointY[i] < compareValue && YDir == "1" && pointY[i] > pointY[pointIndex]) {
                            compareValue = pointY[i];
                            minCompareIndex = i;
                            Program.DebugAddLine("Nalezena křižovatka! (" + directionPoint[i] + ") Index: " + minCompareIndex);
                        }
                    }

                    if(compareValue == LoadedImage.Height) { retVal = -1; } else { retVal = minCompareIndex; }
                    break;

                case "Yn":
                    compareValue = 0;

                    for(int i = 0; i < pointCount; i++) {
                        string YDir = directionPoint[i].Substring(directionPoint[i].IndexOf("Y") + 1, 1);

                        if(pointX[pointIndex] == pointX[i] && pointY[i] > compareValue && YDir == "p" && pointY[i] < pointY[pointIndex]) {
                            compareValue = pointY[i];
                            minCompareIndex = i;
                            Program.DebugAddLine("  -Nalezen směr!");
                        }

                        if(pointX[pointIndex] == pointX[i] && pointY[i] > compareValue && YDir == "1" && pointY[i] < pointY[pointIndex]) {
                            compareValue = pointY[i];
                            minCompareIndex = i;
                            Program.DebugAddLine("  -Nalezena křižovatka! (" + directionPoint[i] + ") Index: " + minCompareIndex);
                        }
                    }

                    if(compareValue == 0) { retVal = -1; } else { retVal = minCompareIndex; }
                    break;

                case "Xp":
                    compareValue = LoadedImage.Width;

                    //Křižovatky
                    for(int i = 0; i < pointCount; i++) {
                        string XDir = directionPoint[i].Substring(directionPoint[i].IndexOf("X") + 1, 1);

                        if(pointY[pointIndex] == pointY[i] && pointX[i] < compareValue && XDir == "n" && pointX[i] > pointX[pointIndex]) {
                            compareValue = pointX[i];
                            minCompareIndex = i;
                        }

                        if(pointY[pointIndex] == pointY[i] && pointX[i] < compareValue && XDir == "1" && pointX[i] > pointX[pointIndex]) {
                            compareValue = pointX[i];
                            minCompareIndex = i;
                        }
                    }

                    if(compareValue == LoadedImage.Width) { retVal = -1; } else { retVal = minCompareIndex; }
                    break;

                case "Xn":
                    compareValue = 0;

                    for(int i = 0; i < pointCount; i++) {
                        string XDir = directionPoint[i].Substring(directionPoint[i].IndexOf("X") + 1, 1);

                        if(pointY[pointIndex] == pointY[i] && pointX[i] > compareValue && XDir == "p" && pointX[i] < pointX[pointIndex]) {
                            compareValue = pointX[i];
                            minCompareIndex = i;
                        }

                        if(pointY[pointIndex] == pointY[i] && pointX[i] > compareValue && XDir == "1" && pointX[i] < pointX[pointIndex]) {
                            compareValue = pointX[i];
                            minCompareIndex = i;
                        }
                    }

                    if(compareValue == 0) { retVal = -1; } else { retVal = minCompareIndex; }
                    break;
            }

            return retVal;
        }

        private static void ConvertToVectorAndRoute(int checkIndex) {
            string deleteDirection = "";
            string XDir; string YDir;

            do {
                XDir = "";
                YDir = "";

                if(deleteDirection != "") {
                    Program.DebugAddLine("deleteDirection: " + deleteDirection);

                    //Pro křižovatky
                    if(directionPoint[checkIndex].Substring(directionPoint[checkIndex].IndexOf("X") + 1, 1) == "1" || directionPoint[checkIndex].Substring(directionPoint[checkIndex].IndexOf("Y") + 1, 1) == "1") {
                        //Pokud je Lrozcestí
                        if(directionPoint[checkIndex].Substring(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, 1) == "1") {
                            //Obrátí směr
                            string reverseDir = deleteDirection.Substring(1, 1);
                            if(reverseDir == "n") { reverseDir = "p"; } else if(reverseDir == "p") { reverseDir = "n"; } else { reverseDir = "9"; }

                            directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, 1);
                            directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, reverseDir);

                            Program.DebugAddLine("Upraven index " + checkIndex + " na: " + directionPoint[checkIndex] + " (Lrozcestí)");
                        } else {
                            //Pokud je -Rozcestí
                            //Přepíše
                            directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, 1);
                            directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, "0");

                            Program.DebugAddLine("Upraven index " + checkIndex + " na: " + directionPoint[checkIndex] + " (-rozcestí)");
                        }

                        Program.DebugAddLine("Upraveno deleteDirection (křižovatka)");
                    } else {
                        //Pro směry
                        directionPoint[checkIndex] = directionPoint[checkIndex].Replace(deleteDirection, deleteDirection.Substring(0, 1) + "0");
                        Program.DebugAddLine("Upraven index " + checkIndex + " na: " + directionPoint[checkIndex] + " (smer)");
                        Program.DebugAddLine("Upraveno deleteDirection (směr)");
                    }
                }

                Program.DebugAddLine("Bod: [" + pointX[checkIndex] + "," + pointY[checkIndex] + "]" + "Index: " + checkIndex);
                XDir = directionPoint[checkIndex].Substring(directionPoint[checkIndex].IndexOf("X") + 1, 1);
                YDir = directionPoint[checkIndex].Substring(directionPoint[checkIndex].IndexOf("Y") + 1, 1);
                Program.DebugAddLine(" XDir: " + XDir + " / YDir: " + YDir);

                //4 základní směry
                if(XDir == "0" && YDir == "p") {
                    int pointFindIndex = ComparePoints(checkIndex, "Yp");
                    if(pointFindIndex != -1) {
                        ProcessVector(checkIndex, pointFindIndex, deleteDirection, true);
                        checkIndex = pointFindIndex;
                        deleteDirection = "Yn";
                    } else { Program.DebugAddLine("ForceBreak! (X0Yp)"); break; }
                } else if(XDir == "0" && YDir == "n") {
                    int pointFindIndex = ComparePoints(checkIndex, "Yn");
                    if(pointFindIndex != -1) {
                        ProcessVector(checkIndex, pointFindIndex, deleteDirection, true);
                        checkIndex = pointFindIndex;
                        deleteDirection = "Yp";
                    } else { Program.DebugAddLine("ForceBreak! (X0Yn)"); break; }
                } else if(XDir == "p" && YDir == "0") {
                    int pointFindIndex = ComparePoints(checkIndex, "Xp");
                    if(pointFindIndex != -1) {
                        ProcessVector(checkIndex, pointFindIndex, deleteDirection, true);
                        checkIndex = pointFindIndex;
                        deleteDirection = "Xn";
                    } else { Program.DebugAddLine("ForceBreak! (XpY0)"); break; }
                } else if(XDir == "n" && YDir == "0") {
                    int pointFindIndex = ComparePoints(checkIndex, "Xn");
                    if(pointFindIndex != -1) {
                        ProcessVector(checkIndex, pointFindIndex, deleteDirection, true);
                        checkIndex = pointFindIndex;
                        deleteDirection = "Xp";
                    } else { Program.DebugAddLine("ForceBreak! (XnY0)"); break; }
                } else if(XDir == "p" && YDir == "n") {
                    string checkVal = "";

                    string reverseDir = deleteDirection.Substring(1, 1);
                    if(reverseDir == "n") { reverseDir = "p"; } else if(reverseDir == "p") { reverseDir = "n"; } else { reverseDir = "9"; }

                    checkVal = deleteDirection.Substring(0, 1) + reverseDir;
                    Program.DebugAddLine(checkVal);

                    int pointFindIndex = ComparePoints(checkIndex, checkVal);
                    if(pointFindIndex != -1) {
                        ProcessVector(checkIndex, pointFindIndex, deleteDirection, false);
                    } else { Program.DebugAddLine("ForceBreak!"); break; }

                    //Smaže cestu, kterou lze pokračovat 
                    directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, 1);
                    directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, "0");

                    checkIndex = pointFindIndex;
                } else if(XDir == "n" && YDir == "p") {
                    string checkVal = "";

                    string reverseDir = deleteDirection.Substring(1, 1);
                    if(reverseDir == "n") { reverseDir = "p"; } else if(reverseDir == "p") { reverseDir = "n"; } else { reverseDir = "9"; }

                    checkVal = deleteDirection.Substring(0, 1) + reverseDir;
                    Program.DebugAddLine(checkVal);

                    int pointFindIndex = ComparePoints(checkIndex, checkVal);
                    if(pointFindIndex != -1) {
                        ProcessVector(checkIndex, pointFindIndex, deleteDirection, false);
                    } else { Program.DebugAddLine("ForceBreak!"); break; }

                    //Smaže cestu, kterou lze pokračovat 
                    directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, 1);
                    directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, "0");

                    checkIndex = pointFindIndex;

                } else if(XDir == "n" && YDir == "n") {
                    string checkVal = "";

                    string reverseDir = deleteDirection.Substring(1, 1);
                    if(reverseDir == "n") { reverseDir = "p"; } else if(reverseDir == "p") { reverseDir = "n"; } else { reverseDir = "9"; }

                    checkVal = deleteDirection.Substring(0, 1) + reverseDir;
                    Program.DebugAddLine(checkVal);

                    int pointFindIndex = ComparePoints(checkIndex, checkVal);
                    if(pointFindIndex != -1) {
                        ProcessVector(checkIndex, pointFindIndex, deleteDirection, false);
                    } else { Program.DebugAddLine("ForceBreak!"); break; }

                    //Smaže cestu, kterou lze pokračovat 
                    directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, 1);
                    directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, "0");

                    checkIndex = pointFindIndex;
                } else if(XDir == "p" && YDir == "p") {
                    string checkVal = "";

                    string reverseDir = deleteDirection.Substring(1, 1);
                    if(reverseDir == "n") { reverseDir = "p"; } else if(reverseDir == "p") { reverseDir = "n"; } else { reverseDir = "9"; }

                    checkVal = deleteDirection.Substring(0, 1) + reverseDir;
                    Program.DebugAddLine(checkVal);

                    int pointFindIndex = ComparePoints(checkIndex, checkVal);
                    if(pointFindIndex != -1) {
                        ProcessVector(checkIndex, pointFindIndex, deleteDirection, false);
                    } else { Program.DebugAddLine("ForceBreak!"); break; }

                    //Smaže cestu, kterou lze pokračovat 
                    directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, 1);
                    directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf(deleteDirection.Substring(0, 1)) + 1, "0");

                    checkIndex = pointFindIndex;
                } else if(XDir == "1" && YDir == "0") {
                    //Na rozcestí nelze pokračovat po směru, ze kterého jsem přišel
                    //Zvolí preferovaný směr (doprava +)
                    string checkVal = "Xp";

                    int pointFindIndex = ComparePoints(checkIndex, checkVal);
                    if(pointFindIndex != -1) {
                        ProcessVector(checkIndex, pointFindIndex, deleteDirection, false);
                    } else { Program.DebugAddLine("ForceBreak!"); break; }

                    //Přepíše bod aby zůstal pouze platný směr (ten kterým tento cyklus nepojedeme)
                    directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf("X") + 1, 1);
                    directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf("X") + 1, "n");
                    Program.DebugAddLine("Upraven index " + checkIndex + " na " + directionPoint[checkIndex]);

                    YDir = "0";

                    checkIndex = pointFindIndex;
                    deleteDirection = "Xn";
                } else if(XDir == "0" && YDir == "1") {
                    //Na rozcestí nelze pokračovat po směru, ze kterého jsem přišel
                    //Zvolí preferovaný směr (nahoru -)
                    string checkVal = "Yn";

                    int pointFindIndex = ComparePoints(checkIndex, checkVal);
                    if(pointFindIndex != -1) {
                        ProcessVector(checkIndex, pointFindIndex, deleteDirection, false);
                    } else { Program.DebugAddLine("ForceBreak!"); break; }

                    Program.DebugAddLine("Hodnota po po provedení: " + directionPoint[checkIndex] + "(" + pointX[checkIndex] + "," + pointY[checkIndex] + ") I: " + checkIndex);

                    //Přepíše bod aby zůstal pouze platný směr (ten kterým tento cyklus nepojedeme)
                    directionPoint[checkIndex] = directionPoint[checkIndex].Remove(directionPoint[checkIndex].IndexOf("Y") + 1, 1);
                    directionPoint[checkIndex] = directionPoint[checkIndex].Insert(directionPoint[checkIndex].IndexOf("Y") + 1, "p");

                    YDir = "0";

                    checkIndex = pointFindIndex;
                    deleteDirection = "Yp";
                } else { vectorRoutesCount++; break; }
            } while(true);

            //Pokud už nelze najít další bod cesty, smaže i poslední použitý bod
            pointX[checkIndex] = 0;
            pointY[checkIndex] = 0;

            //Aktualizuje body v listBoxVectors
            Program.Form.listBoxPoints.Items.Clear();
            for(int i = 0; i < pointCount; i++) {
                Program.Form.listBoxPoints.Items.Add("[" + Program.Form.pointX_duplicate[i] + "," + Program.Form.pointY_duplicate[i] + "] " + Program.Form.directionPoint_duplicate[i]);
            }

        }

        //Vykreslí obrázek
        public static void DrawPicture() {
            if(Program.Form.isPictureLoaded) {
                GetRoutes();
                GetPoints();
                GetDrills();

                for(int i = 0; i < pointCount; i++) {
                    Program.Form.listBoxPoints.Items.Add("[" + pointX[i] + "," + pointY[i] + "] " + directionPoint[i]);
                }

                for(int i = 0; i < pointCount; i++) {
                    Program.Form.pointX_duplicate[i] = pointX[i];
                    Program.Form.pointY_duplicate[i] = pointY[i];
                    Program.Form.directionPoint_duplicate[i] = directionPoint[i];
                }

                //Přidá body vrtání do ListBoxu
                Program.DebugAddLine(drillPointCount.ToString());
                for(int i = 0; i < drillPointCount; i++) {
                    Size area = GetSolderingArea(drillPointX[i], drillPointY[i]);
                    Program.Form.listBoxPointsDrill.Items.Add("Bod: [" + drillPointX[i] + "," + drillPointY[i] + "], (" + area.Width.ToString() + "," + area.Height.ToString() + ")");
                }


                //Smaže křižovatky typu + z pole, nesou potřeba
                for(int i = 0; i < pointCount; i++) {
                    string XDir = directionPoint[i].Substring(directionPoint[i].IndexOf("X") + 1, 1);
                    string YDir = directionPoint[i].Substring(directionPoint[i].IndexOf("Y") + 1, 1);
                    if(XDir == "1" && YDir == "1") {
                        pointX[i] = 0;
                        pointY[i] = 0;
                    }
                }

                //Vypočítá cesty
                int startPointIndex = 0;
                while(startPointIndex != -1) {
                    startPointIndex = GetStartPoint();
                    Program.DebugAddLine("----------------------------");
                    if(startPointIndex != -1) {
                        ConvertToVectorAndRoute(startPointIndex);
                    }
                }



                Program.Form.buttonDrawVectors.PerformClick();
                Program.Form.isPictureDrawed = true;
            } else { Program.DebugAddLine("Nelze vykreslit! Nebyl načten obrázek!"); }
        }

        private static string TranslateRouteDirection(string _direction) {
            switch(_direction) {
                case "Xp":
                    return "XR";

                case "Xn":
                    return "XL";

                case "Yp":
                    return "YU";

                case "Yn":
                   return "YD";
            }

            return "";
        }

        //Vrátí true, pokud je okolo daného bodu pájecí oblast
        private static bool HasSolderingArea(int _drillPointX, int _drillPointY) {
            int range = 5;

            for(int x = -range; x <= range; x++) {
                for(int y = -range; y <= range; y++) {
                    //Zjistí jestli jsme nevyjeli z obrázku
                    if((_drillPointX - x) >= 0 && (_drillPointY - y) >= 0 && (_drillPointX + x) <= LoadedImage.Width && (_drillPointY + y) <= LoadedImage.Height) {
                        //Zkontzroluje barvu pixelu na souřadnicích
                        Color pixel = LoadedImage.GetPixel(_drillPointX + x, _drillPointY + y);
                        if(pixel == colorDrill || pixel == colorTranslation) {
                            return true;
                        }
                    }
                }
            }

            return false;
        }


        private static Size GetSolderingArea(int _drillPointX, int _drillPointY) {
            if(HasSolderingArea(_drillPointX, _drillPointY)) {
                int lengthX = 1;
                int lengthY = 1;

                bool OnSolderingArea = false;
                while(true) {
                    Color pixel = LoadedImage.GetPixel(_drillPointX + lengthX, _drillPointY);
                    if(pixel == colorDrill || pixel == colorTranslation) {
                        if(OnSolderingArea == false) {
                            OnSolderingArea = true;
                        }
                    } else {
                        if(OnSolderingArea == true) {
                            break;
                        }
                    }

                    lengthX++;
                }

                OnSolderingArea = false;
                while(true) {
                    Color pixel = LoadedImage.GetPixel(_drillPointX, _drillPointY + lengthY);
                    if(pixel == colorDrill || pixel == colorTranslation) {
                        if(OnSolderingArea == false) {
                            OnSolderingArea = true;
                        }
                    } else {
                        if(OnSolderingArea == true) {
                            break;
                        }
                    }

                    lengthY++;
                }

                return new Size(lengthX * 2, lengthY * 2);
            } else {
                return new Size(0, 0);
            }
        }

        public static void AnalizeRoutes() {
            decimal DpiXRadio = (decimal)(PrinterControl.xRadio * 25.4F / PrinterControl.Dpi);
            decimal DpiYRadio = (decimal)(PrinterControl.yRadio * 25.4F / PrinterControl.Dpi);

            PrinterControl.SetDefaultPosPen();
            //Tisk tras
            int lastI = 0; int currectDrawingRouteI = 1; string lastYDir = "";
            for(int routeI = 1; routeI < vectorRoutesCount; routeI++) {
                int endPointX, endPointY;
                if(lastI != 0) {
                    endPointX = vectorEndX[lastI - 1];
                    endPointY = vectorEndY[lastI - 1];
                } else { endPointX = 0; endPointY = 0; }

                int moveX = endPointX - vectorStartX[GetRouteIStart(routeI)];
                int moveY = endPointY - vectorStartY[GetRouteIStart(routeI)];

                int stepsStartX = (int)Math.Round((Math.Abs(moveX) * DpiXRadio), 0);
                int stepsStartY = (int)Math.Round((Math.Abs(moveY) * DpiYRadio), 0);

                PrinterQuery.AddCommand("SPU");
                string xDir, yDir;
                if(moveX < 0) { xDir = "XR"; } else { xDir = "XL"; }
                if(moveY < 0) { yDir = "YU"; } else { yDir = "YD"; }

                if(yDir == "YU" && lastYDir == "YD") { stepsStartY += 0; }
                if(yDir == "YL" && lastYDir == "YR") { stepsStartY += 0; }
                lastYDir = yDir;

                PrinterQuery.AddCommand("M" + xDir + "(" + stepsStartX + ")");
                PrinterQuery.AddCommand("M" + yDir + "(" + stepsStartY + ")");
                PrinterQuery.AddCommand("SPD");

                int i = lastI;
                float stepsRestEnd = 0;
                while(vectorRouteI[i] == currectDrawingRouteI) {
                    int stepsEnd = 0;
                    if(vectorDirection[i].Substring(0, 1) == "X") {
                        stepsEnd = (int)Math.Round((vectorLength[i] * DpiXRadio) + (decimal)stepsRestEnd, 0);
                        stepsRestEnd = (float)(vectorLength[i] * DpiXRadio - stepsEnd);
                    } else if(vectorDirection[i].Substring(0, 1) == "Y") {
                        stepsEnd = (int)Math.Round((vectorLength[i] * DpiYRadio) + (decimal)stepsRestEnd, 0);
                        stepsRestEnd = (float)(vectorLength[i] * DpiYRadio - stepsEnd);
                    }

                    if(i != 0) {
                        if(i == lastI) {
                            if(vectorDirection[i] == "Yp" && lastYDir == "Yn") { stepsEnd += 12; }
                            if(vectorDirection[i] == "Yn" && lastYDir == "Yp") { stepsEnd += 12; }
                        } else {
                            if(vectorDirection[i] == "Yp" && vectorDirection[i - 1] == "Yn") { stepsEnd += 12; }
                            if(vectorDirection[i] == "Yn" && vectorDirection[i - 1] == "Yp") { stepsEnd += 12; }
                        }
                    }

                    PrinterQuery.AddCommand("M" + TranslateRouteDirection(vectorDirection[i]) + "(" + stepsEnd + ")");
                    i++;
                }

                lastI = i;
                currectDrawingRouteI++;
            }
        }

        public static void PrintSolderingAreas() {
            decimal DpiXRadio = (decimal)(PrinterControl.xRadio * 25.4F / PrinterControl.Dpi);
            decimal DpiYRadio = (decimal)(PrinterControl.yRadio * 25.4F / PrinterControl.Dpi);

            //Vykreslení pájecích ploch
            PrinterControl.SetDefaultPosPen();
            for(int holeI = 0; holeI < drillPointCount; holeI++) {
                int moveX, moveY;
                if(holeI != 0) {
                    moveX = drillPointX[holeI] - drillPointX[holeI - 1];
                    moveY = drillPointY[holeI] - drillPointY[holeI - 1];
                } else { moveX = drillPointX[holeI]; moveY = drillPointY[holeI]; }

                int stepsStartX = (int)Math.Round((Math.Abs(moveX) * DpiXRadio), 0);
                int stepsStartY = (int)Math.Round((Math.Abs(moveY) * DpiYRadio), 0);

                string xDir, yDir;
                if(moveX < 0) { xDir = "XL"; } else { xDir = "XR"; }
                if(moveY < 0) { yDir = "YD"; } else { yDir = "YU"; }

                //Přesun na souřadnice
                PrinterQuery.AddCommand("M" + xDir + "(" + stepsStartX + ")");
                PrinterQuery.AddCommand("M" + yDir + "(" + stepsStartY + ")");


                //Výpočet pájecí plochy
                Size area = GetSolderingArea(drillPointX[holeI], drillPointY[holeI]);

                //Přesun na 0,0 pájecí plochy
                PrinterQuery.AddCommand("MXL" + "(" + (int)Math.Round((Math.Abs(area.Width) * DpiXRadio), 0) / 2 + ")");
                PrinterQuery.AddCommand("MYD" + "(" + (int)Math.Round((Math.Abs(area.Height) * DpiYRadio), 0) / 2 + ")");
                PrinterQuery.AddCommand("SPD");

                //Vykreslení samotné plochy
                for(int y = 0; y <= area.Height; y += 2) {
                    PrinterQuery.AddCommand("MXR" + "(" + (int)Math.Round((Math.Abs(area.Width) * DpiXRadio), 0) + ")");
                    PrinterQuery.AddCommand("MYU" + "(" + "1" + ")");
                    PrinterQuery.AddCommand("MXL" + "(" + (int)Math.Round((Math.Abs(area.Width) * DpiXRadio), 0) + ")");
                    PrinterQuery.AddCommand("MYU" + "(" + "1" + ")");
                }
                PrinterQuery.AddCommand("SPU");

                //Přesun
                PrinterQuery.AddCommand("MXR" + "(" + (int)Math.Round((Math.Abs(area.Width) * DpiXRadio), 0) / 2 + ")");
                PrinterQuery.AddCommand("MYD" + "(" + (int)Math.Round((Math.Abs(area.Height) * DpiYRadio), 0) / 2 + ")");
            }
        }

        public static void PrintDrillPoints() {
            decimal DpiXRadio = (decimal)(PrinterControl.xRadio * 25.4F / PrinterControl.Dpi);
            decimal DpiYRadio = (decimal)(PrinterControl.yRadio * 25.4F / PrinterControl.Dpi);

            for(int modeI = 1; modeI <= 2; modeI++) {
                if(modeI == 1) {
                    PrinterControl.SetDefaultPosDrill();
                    PrinterQuery.AddCommand("MZD(140)");
                } else if(modeI == 2) {
                    PrinterControl.SetDefaultPosPen();
                }

                for(int holeI = 0; holeI < drillPointCount; holeI++) {
                    int moveX, moveY;
                    if(holeI != 0) {
                        moveX = drillPointX[holeI] - drillPointX[holeI - 1];
                        moveY = drillPointY[holeI] - drillPointY[holeI - 1];
                    } else { moveX = drillPointX[holeI]; moveY = drillPointY[holeI]; }

                    int stepsStartX = (int)Math.Round((Math.Abs(moveX) * DpiXRadio), 0);
                    int stepsStartY = (int)Math.Round((Math.Abs(moveY) * DpiYRadio), 0);

                    string xDir, yDir;
                    if(moveX < 0) { xDir = "XL"; } else { xDir = "XR"; }
                    if(moveY < 0) { yDir = "YD"; } else { yDir = "YU"; }

                    PrinterQuery.AddCommand("M" + xDir + "(" + stepsStartX + ")");
                    PrinterQuery.AddCommand("M" + yDir + "(" + stepsStartY + ")");

                    if(modeI == 1) {
                        //Mod vrtačky
                        PrinterQuery.AddCommand("SDR");
                        PrinterQuery.AddCommand("SDD");
                    } else if(modeI == 2) {
                        //Mod tužky
                        PrinterQuery.AddCommand("SPD");
                        PrinterQuery.AddCommand("SPU");
                    }
                }
            }
        }

    }

}
