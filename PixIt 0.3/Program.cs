using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace PixIt_0._3 {

    static class Program {

        public static formMain Form = new formMain();

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.Run(Form);
        }

        public static void ShowMessageForm(string _title, string _text) {
            new formMessage(_title, _text).Show();
        }

    }
}
