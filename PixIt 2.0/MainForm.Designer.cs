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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelI = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonOpenPort = new System.Windows.Forms.Button();
            this.labelPortStatus = new System.Windows.Forms.Label();
            this.listBoxSerialRead = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Bitmap_Original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DrawVectors)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Bitmap_Original
            // 
            this.pictureBox_Bitmap_Original.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox_Bitmap_Original.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Bitmap_Original.Location = new System.Drawing.Point(133, 52);
            this.pictureBox_Bitmap_Original.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_Bitmap_Original.Name = "pictureBox_Bitmap_Original";
            this.pictureBox_Bitmap_Original.Size = new System.Drawing.Size(466, 369);
            this.pictureBox_Bitmap_Original.TabIndex = 2;
            this.pictureBox_Bitmap_Original.TabStop = false;
            this.pictureBox_Bitmap_Original.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_BitMap_MouseDown);
            this.pictureBox_Bitmap_Original.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Bitmap_Original_MouseMove);
            // 
            // button_LoadImage
            // 
            this.button_LoadImage.Location = new System.Drawing.Point(12, 47);
            this.button_LoadImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_LoadImage.Name = "button_LoadImage";
            this.button_LoadImage.Size = new System.Drawing.Size(115, 36);
            this.button_LoadImage.TabIndex = 3;
            this.button_LoadImage.Text = "Načíst obrázek";
            this.button_LoadImage.UseVisualStyleBackColor = true;
            this.button_LoadImage.Click += new System.EventHandler(this.button_LoadImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Originál";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(601, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Zobrazení";
            // 
            // button_draw
            // 
            this.button_draw.Enabled = false;
            this.button_draw.Location = new System.Drawing.Point(12, 385);
            this.button_draw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_draw.Name = "button_draw";
            this.button_draw.Size = new System.Drawing.Size(115, 36);
            this.button_draw.TabIndex = 11;
            this.button_draw.Text = "Vykreslit";
            this.button_draw.UseVisualStyleBackColor = true;
            this.button_draw.Click += new System.EventHandler(this.button_Draw_Click);
            // 
            // button_settings
            // 
            this.button_settings.Location = new System.Drawing.Point(12, 89);
            this.button_settings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_settings.Name = "button_settings";
            this.button_settings.Size = new System.Drawing.Size(115, 25);
            this.button_settings.TabIndex = 17;
            this.button_settings.Text = "Nastavení";
            this.button_settings.UseVisualStyleBackColor = true;
            this.button_settings.Click += new System.EventHandler(this.button_settings_Click);
            // 
            // listBox_Vectors
            // 
            this.listBox_Vectors.FormattingEnabled = true;
            this.listBox_Vectors.ItemHeight = 16;
            this.listBox_Vectors.Location = new System.Drawing.Point(1077, 48);
            this.listBox_Vectors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox_Vectors.Name = "listBox_Vectors";
            this.listBox_Vectors.Size = new System.Drawing.Size(152, 372);
            this.listBox_Vectors.TabIndex = 18;
            this.listBox_Vectors.SelectedIndexChanged += new System.EventHandler(this.listBox_Vectors_SelectedIndexChanged);
            // 
            // pictureBox_DrawVectors
            // 
            this.pictureBox_DrawVectors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox_DrawVectors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_DrawVectors.Location = new System.Drawing.Point(605, 52);
            this.pictureBox_DrawVectors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_DrawVectors.Name = "pictureBox_DrawVectors";
            this.pictureBox_DrawVectors.Size = new System.Drawing.Size(466, 369);
            this.pictureBox_DrawVectors.TabIndex = 20;
            this.pictureBox_DrawVectors.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1073, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "Legnth";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(497, 502);
            this.labelX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(17, 17);
            this.labelX.TabIndex = 26;
            this.labelX.Text = "X";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(497, 530);
            this.labelY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(17, 17);
            this.labelY.TabIndex = 27;
            this.labelY.Text = "Y";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(543, 502);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 28;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelI
            // 
            this.labelI.AutoSize = true;
            this.labelI.Location = new System.Drawing.Point(664, 530);
            this.labelI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelI.Name = "labelI";
            this.labelI.Size = new System.Drawing.Size(11, 17);
            this.labelI.TabIndex = 29;
            this.labelI.Text = "i";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(715, 489);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 30;
            this.button1.Text = "NextPix";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // buttonOpenPort
            // 
            this.buttonOpenPort.Location = new System.Drawing.Point(12, 119);
            this.buttonOpenPort.Name = "buttonOpenPort";
            this.buttonOpenPort.Size = new System.Drawing.Size(115, 25);
            this.buttonOpenPort.TabIndex = 31;
            this.buttonOpenPort.Text = "Otevřít Port";
            this.buttonOpenPort.UseVisualStyleBackColor = true;
            this.buttonOpenPort.Click += new System.EventHandler(this.buttonOpenPort_Click);
            // 
            // labelPortStatus
            // 
            this.labelPortStatus.AutoSize = true;
            this.labelPortStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPortStatus.Location = new System.Drawing.Point(12, 147);
            this.labelPortStatus.Name = "labelPortStatus";
            this.labelPortStatus.Size = new System.Drawing.Size(70, 12);
            this.labelPortStatus.TabIndex = 32;
            this.labelPortStatus.Text = "Port je uzavřen!";
            // 
            // listBoxSerialRead
            // 
            this.listBoxSerialRead.Enabled = false;
            this.listBoxSerialRead.FormattingEnabled = true;
            this.listBoxSerialRead.ItemHeight = 16;
            this.listBoxSerialRead.Location = new System.Drawing.Point(1077, 456);
            this.listBoxSerialRead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxSerialRead.Name = "listBoxSerialRead";
            this.listBoxSerialRead.Size = new System.Drawing.Size(152, 148);
            this.listBoxSerialRead.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1073, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 17);
            this.label3.TabIndex = 34;
            this.label3.Text = "Data ze Sériového portu";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 608);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxSerialRead);
            this.Controls.Add(this.labelPortStatus);
            this.Controls.Add(this.buttonOpenPort);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelI);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox_DrawVectors);
            this.Controls.Add(this.listBox_Vectors);
            this.Controls.Add(this.button_settings);
            this.Controls.Add(this.button_draw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_LoadImage);
            this.Controls.Add(this.pictureBox_Bitmap_Original);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelI;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonOpenPort;
        private System.Windows.Forms.Label labelPortStatus;
        private System.Windows.Forms.ListBox listBoxSerialRead;
        private System.Windows.Forms.Label label3;
    }
}

