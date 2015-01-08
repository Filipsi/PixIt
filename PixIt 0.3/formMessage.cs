using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PixIt_0._3 {

    public partial class formMessage : Form {

        public formMessage(string _title, string _text) {
            InitializeComponent();
            LabelTitle.Text = _title;
            LabelText.Text = _text;
        }

    }

}
