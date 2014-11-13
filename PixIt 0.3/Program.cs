using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PixIt_0._3
{
    static class Program
    {

        public static formMain Form = new formMain();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(Form);
        }
    }
}
