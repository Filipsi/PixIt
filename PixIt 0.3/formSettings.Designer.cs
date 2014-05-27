namespace PixIt_0._3
{
    partial class formSettings
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
            this.btnRoute = new System.Windows.Forms.Button();
            this.btnDrill = new System.Windows.Forms.Button();
            this.picCursorColor = new System.Windows.Forms.PictureBox();
            this.picDrillColor = new System.Windows.Forms.PictureBox();
            this.picPathColor = new System.Windows.Forms.PictureBox();
            this.groupSetColor = new System.Windows.Forms.GroupBox();
            this.btnTransition = new System.Windows.Forms.Button();
            this.picTranslationColor = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericDpi = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericDrillTouchNum = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.picCursorColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDrillColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPathColor)).BeginInit();
            this.groupSetColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTranslationColor)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDpi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDrillTouchNum)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRoute
            // 
            this.btnRoute.Location = new System.Drawing.Point(87, 23);
            this.btnRoute.Margin = new System.Windows.Forms.Padding(4);
            this.btnRoute.Name = "btnRoute";
            this.btnRoute.Size = new System.Drawing.Size(100, 28);
            this.btnRoute.TabIndex = 0;
            this.btnRoute.Text = "Cesta";
            this.btnRoute.UseVisualStyleBackColor = true;
            this.btnRoute.Click += new System.EventHandler(this.btnRoute_Click);
            // 
            // btnDrill
            // 
            this.btnDrill.Location = new System.Drawing.Point(87, 79);
            this.btnDrill.Margin = new System.Windows.Forms.Padding(4);
            this.btnDrill.Name = "btnDrill";
            this.btnDrill.Size = new System.Drawing.Size(100, 28);
            this.btnDrill.TabIndex = 1;
            this.btnDrill.Text = "Vrtání";
            this.btnDrill.UseVisualStyleBackColor = true;
            this.btnDrill.Click += new System.EventHandler(this.btnDrill_Click);
            // 
            // picCursorColor
            // 
            this.picCursorColor.BackColor = System.Drawing.Color.White;
            this.picCursorColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCursorColor.Location = new System.Drawing.Point(8, 23);
            this.picCursorColor.Margin = new System.Windows.Forms.Padding(4);
            this.picCursorColor.Name = "picCursorColor";
            this.picCursorColor.Size = new System.Drawing.Size(70, 181);
            this.picCursorColor.TabIndex = 3;
            this.picCursorColor.TabStop = false;
            // 
            // picDrillColor
            // 
            this.picDrillColor.BackColor = System.Drawing.Color.White;
            this.picDrillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDrillColor.Location = new System.Drawing.Point(91, 101);
            this.picDrillColor.Margin = new System.Windows.Forms.Padding(4);
            this.picDrillColor.Name = "picDrillColor";
            this.picDrillColor.Size = new System.Drawing.Size(91, 16);
            this.picDrillColor.TabIndex = 4;
            this.picDrillColor.TabStop = false;
            // 
            // picPathColor
            // 
            this.picPathColor.BackColor = System.Drawing.Color.White;
            this.picPathColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPathColor.Location = new System.Drawing.Point(91, 47);
            this.picPathColor.Margin = new System.Windows.Forms.Padding(4);
            this.picPathColor.Name = "picPathColor";
            this.picPathColor.Size = new System.Drawing.Size(91, 16);
            this.picPathColor.TabIndex = 5;
            this.picPathColor.TabStop = false;
            // 
            // groupSetColor
            // 
            this.groupSetColor.Controls.Add(this.btnTransition);
            this.groupSetColor.Controls.Add(this.picTranslationColor);
            this.groupSetColor.Controls.Add(this.picCursorColor);
            this.groupSetColor.Controls.Add(this.btnDrill);
            this.groupSetColor.Controls.Add(this.btnRoute);
            this.groupSetColor.Controls.Add(this.picDrillColor);
            this.groupSetColor.Controls.Add(this.picPathColor);
            this.groupSetColor.Location = new System.Drawing.Point(16, 15);
            this.groupSetColor.Margin = new System.Windows.Forms.Padding(4);
            this.groupSetColor.Name = "groupSetColor";
            this.groupSetColor.Padding = new System.Windows.Forms.Padding(4);
            this.groupSetColor.Size = new System.Drawing.Size(196, 212);
            this.groupSetColor.TabIndex = 7;
            this.groupSetColor.TabStop = false;
            this.groupSetColor.Text = "Nastavení barev";
            // 
            // btnTransition
            // 
            this.btnTransition.Location = new System.Drawing.Point(87, 133);
            this.btnTransition.Margin = new System.Windows.Forms.Padding(4);
            this.btnTransition.Name = "btnTransition";
            this.btnTransition.Size = new System.Drawing.Size(100, 28);
            this.btnTransition.TabIndex = 6;
            this.btnTransition.Text = "Přechod";
            this.btnTransition.UseVisualStyleBackColor = true;
            this.btnTransition.Click += new System.EventHandler(this.btnTransition_Click);
            // 
            // picTranslationColor
            // 
            this.picTranslationColor.BackColor = System.Drawing.Color.White;
            this.picTranslationColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTranslationColor.Location = new System.Drawing.Point(91, 155);
            this.picTranslationColor.Margin = new System.Windows.Forms.Padding(4);
            this.picTranslationColor.Name = "picTranslationColor";
            this.picTranslationColor.Size = new System.Drawing.Size(91, 16);
            this.picTranslationColor.TabIndex = 7;
            this.picTranslationColor.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numPort);
            this.groupBox1.Location = new System.Drawing.Point(221, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(230, 62);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nastavení COM portu";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(8, 26);
            this.numPort.Margin = new System.Windows.Forms.Padding(4);
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(214, 22);
            this.numPort.TabIndex = 0;
            this.numPort.ValueChanged += new System.EventHandler(this.numPort_ValueChanged);
            this.numPort.Click += new System.EventHandler(this.numPort_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericDrillTouchNum);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numericDpi);
            this.groupBox2.Location = new System.Drawing.Point(220, 86);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(231, 133);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nastavení tisku a vrtání";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "DPI";
            // 
            // numericDpi
            // 
            this.numericDpi.Location = new System.Drawing.Point(45, 26);
            this.numericDpi.Margin = new System.Windows.Forms.Padding(4);
            this.numericDpi.Maximum = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            this.numericDpi.Name = "numericDpi";
            this.numericDpi.Size = new System.Drawing.Size(178, 22);
            this.numericDpi.TabIndex = 0;
            this.numericDpi.ValueChanged += new System.EventHandler(this.numericDpi_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Při dotiku plochy zvednout o:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Vrtání:";
            // 
            // numericDrillTouchNum
            // 
            this.numericDrillTouchNum.Location = new System.Drawing.Point(11, 94);
            this.numericDrillTouchNum.Margin = new System.Windows.Forms.Padding(4);
            this.numericDrillTouchNum.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericDrillTouchNum.Name = "numericDrillTouchNum";
            this.numericDrillTouchNum.Size = new System.Drawing.Size(212, 22);
            this.numericDrillTouchNum.TabIndex = 12;
            this.numericDrillTouchNum.ValueChanged += new System.EventHandler(this.numericDrillTouchNum_ValueChanged);
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 240);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupSetColor);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formSettings";
            this.Text = "Nastavení";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCursorColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDrillColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPathColor)).EndInit();
            this.groupSetColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTranslationColor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDpi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDrillTouchNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRoute;
        private System.Windows.Forms.Button btnDrill;
        private System.Windows.Forms.PictureBox picDrillColor;
        private System.Windows.Forms.PictureBox picPathColor;
        private System.Windows.Forms.GroupBox groupSetColor;
        private System.Windows.Forms.Button btnTransition;
        private System.Windows.Forms.PictureBox picTranslationColor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numPort;
        public System.Windows.Forms.PictureBox picCursorColor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericDpi;
        private System.Windows.Forms.NumericUpDown numericDrillTouchNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}