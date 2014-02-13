namespace PixIt_2._0
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Dialog_ChooseColor = new System.Windows.Forms.ColorDialog();
            this.pictureBox_Bitmap_Original = new System.Windows.Forms.PictureBox();
            this.button_LoadImage = new System.Windows.Forms.Button();
            this.Dialog_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_draw = new System.Windows.Forms.Button();
            this.button_settings = new System.Windows.Forms.Button();
            this.listBox_Vectors = new System.Windows.Forms.ListBox();
            this.pictureBox_DrawVectors = new System.Windows.Forms.PictureBox();
            this.listBox_mode = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelI = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Bitmap_Original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DrawVectors)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Bitmap_Original
            // 
            this.pictureBox_Bitmap_Original.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox_Bitmap_Original.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Bitmap_Original.Location = new System.Drawing.Point(100, 42);
            this.pictureBox_Bitmap_Original.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_Bitmap_Original.Name = "pictureBox_Bitmap_Original";
            this.pictureBox_Bitmap_Original.Size = new System.Drawing.Size(350, 300);
            this.pictureBox_Bitmap_Original.TabIndex = 2;
            this.pictureBox_Bitmap_Original.TabStop = false;
            this.pictureBox_Bitmap_Original.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_BitMap_MouseDown);
            this.pictureBox_Bitmap_Original.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Bitmap_Original_MouseMove);
            // 
            // button_LoadImage
            // 
            this.button_LoadImage.Location = new System.Drawing.Point(9, 38);
            this.button_LoadImage.Margin = new System.Windows.Forms.Padding(2);
            this.button_LoadImage.Name = "button_LoadImage";
            this.button_LoadImage.Size = new System.Drawing.Size(86, 29);
            this.button_LoadImage.TabIndex = 3;
            this.button_LoadImage.Text = "Načíst obrázek";
            this.button_LoadImage.UseVisualStyleBackColor = true;
            this.button_LoadImage.Click += new System.EventHandler(this.button_LoadImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Originál";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Zobrazení";
            // 
            // button_draw
            // 
            this.button_draw.Enabled = false;
            this.button_draw.Location = new System.Drawing.Point(9, 247);
            this.button_draw.Margin = new System.Windows.Forms.Padding(2);
            this.button_draw.Name = "button_draw";
            this.button_draw.Size = new System.Drawing.Size(86, 29);
            this.button_draw.TabIndex = 11;
            this.button_draw.Text = "Vykreslit";
            this.button_draw.UseVisualStyleBackColor = true;
            this.button_draw.Click += new System.EventHandler(this.button_Draw_Click);
            // 
            // button_settings
            // 
            this.button_settings.Enabled = false;
            this.button_settings.Location = new System.Drawing.Point(9, 72);
            this.button_settings.Margin = new System.Windows.Forms.Padding(2);
            this.button_settings.Name = "button_settings";
            this.button_settings.Size = new System.Drawing.Size(86, 20);
            this.button_settings.TabIndex = 17;
            this.button_settings.Text = "Nastavení";
            this.button_settings.UseVisualStyleBackColor = true;
            this.button_settings.Click += new System.EventHandler(this.button_settings_Click);
            // 
            // listBox_Vectors
            // 
            this.listBox_Vectors.FormattingEnabled = true;
            this.listBox_Vectors.Location = new System.Drawing.Point(808, 39);
            this.listBox_Vectors.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_Vectors.Name = "listBox_Vectors";
            this.listBox_Vectors.Size = new System.Drawing.Size(115, 303);
            this.listBox_Vectors.TabIndex = 18;
            this.listBox_Vectors.SelectedIndexChanged += new System.EventHandler(this.listBox_Vectors_SelectedIndexChanged);
            // 
            // pictureBox_DrawVectors
            // 
            this.pictureBox_DrawVectors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox_DrawVectors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_DrawVectors.Location = new System.Drawing.Point(454, 42);
            this.pictureBox_DrawVectors.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_DrawVectors.Name = "pictureBox_DrawVectors";
            this.pictureBox_DrawVectors.Size = new System.Drawing.Size(350, 300);
            this.pictureBox_DrawVectors.TabIndex = 20;
            this.pictureBox_DrawVectors.TabStop = false;
            // 
            // listBox_mode
            // 
            this.listBox_mode.Enabled = false;
            this.listBox_mode.FormattingEnabled = true;
            this.listBox_mode.Items.AddRange(new object[] {
            "Cesty",
            "Vrtani"});
            this.listBox_mode.Location = new System.Drawing.Point(9, 212);
            this.listBox_mode.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_mode.Name = "listBox_mode";
            this.listBox_mode.Size = new System.Drawing.Size(87, 30);
            this.listBox_mode.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 196);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Mody vykresleni:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(805, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Legnth";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(373, 408);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 26;
            this.labelX.Text = "X";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(373, 431);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 13);
            this.labelY.TabIndex = 27;
            this.labelY.Text = "Y";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(407, 408);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 28;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelI
            // 
            this.labelI.AutoSize = true;
            this.labelI.Location = new System.Drawing.Point(498, 431);
            this.labelI.Name = "labelI";
            this.labelI.Size = new System.Drawing.Size(9, 13);
            this.labelI.TabIndex = 29;
            this.labelI.Text = "i";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(536, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "NextPix";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 494);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelI);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox_mode);
            this.Controls.Add(this.pictureBox_DrawVectors);
            this.Controls.Add(this.listBox_Vectors);
            this.Controls.Add(this.button_settings);
            this.Controls.Add(this.button_draw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_LoadImage);
            this.Controls.Add(this.pictureBox_Bitmap_Original);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "PixIt";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Bitmap_Original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DrawVectors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog Dialog_ChooseColor;
        private System.Windows.Forms.PictureBox pictureBox_Bitmap_Original;
        private System.Windows.Forms.Button button_LoadImage;
        private System.Windows.Forms.OpenFileDialog Dialog_OpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_draw;
        private System.Windows.Forms.Button button_settings;
        private System.Windows.Forms.ListBox listBox_Vectors;
        private System.Windows.Forms.PictureBox pictureBox_DrawVectors;
        private System.Windows.Forms.ListBox listBox_mode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelI;
        private System.Windows.Forms.Button button1;
    }
}

