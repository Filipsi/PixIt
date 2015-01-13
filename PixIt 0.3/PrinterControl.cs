using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_0._3 {

    static class PrinterControl {

        public const float xRadio = 2.12F;
        public const float yRadio = 8.6F;
        public static float Dpi = 0;

        public static bool PrinterDebugMode = false;

        public static void SetDefaultPosPen() {
            PrinterQuery.AddCommand("SPU");
            PrinterQuery.AddCommand("SD0");
            PrinterQuery.AddCommand("SDU");
            PrinterQuery.AddCommand("SSX");
            PrinterQuery.AddCommand("SSY");
            PrinterQuery.AddCommand("MXR(128)");
            PrinterQuery.AddCommand("MYU(108)");
        }

        public static void SetDefaultPosDrill() {
            PrinterQuery.AddCommand("SPU");
            PrinterQuery.AddCommand("SD0");
            PrinterQuery.AddCommand("SDU");
            PrinterQuery.AddCommand("SSX");
            PrinterQuery.AddCommand("SSY");
            PrinterQuery.AddCommand("MXR(41)");
            PrinterQuery.AddCommand("MYU(15)");
        }

        public static void StartPrinting() {
            if(Serial.IsOpen()) {
                PrinterQuery.StartSerial();
            } else if(Tcp.IsConnected()) {
                PrinterQuery.StartTcp();
            }
        }

    }
}
