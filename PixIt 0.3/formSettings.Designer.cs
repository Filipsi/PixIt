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
            ((System.ComponentModel.ISupportInitialize)(this.picCursorColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDrillColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPathColor)).BeginInit();
            this.groupSetColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTranslationColor)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRoute
            // 
            this.btnRoute.Location = new System.Drawing.Point(65, 19);
            this.btnRoute.Name = "btnRoute";
            this.btnRoute.Size = new System.Drawing.Size(75, 23);
            this.btnRoute.TabIndex = 0;
            this.btnRoute.Text = "Cesta";
            this.btnRoute.UseVisualStyleBackColor = true;
            this.btnRoute.Click += new System.EventHandler(this.btnRoute_Click);
            // 
            // btnDrill
            // 
            this.btnDrill.Location = new System.Drawing.Point(65, 64);
            this.btnDrill.Name = "btnDrill";
            this.btnDrill.Size = new System.Drawing.Size(75, 23);
            this.btnDrill.TabIndex = 1;
            this.btnDrill.Text = "Vrtání";
            this.btnDrill.UseVisualStyleBackColor = true;
            this.btnDrill.Click += new System.EventHandler(this.btnDrill_Click);
            // 
            // picCursorColor
            // 
            this.picCursorColor.BackColor = System.Drawing.Color.White;
            this.picCursorColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCursorColor.Location = new System.Drawing.Point(6, 19);
            this.picCursorColor.Name = "picCursorColor";
            this.picCursorColor.Size = new System.Drawing.Size(53, 120);
            this.picCursorColor.TabIndex = 3;
            this.picCursorColor.TabStop = false;
            // 
            // picDrillColor
            // 
            this.picDrillColor.BackColor = System.Drawing.Color.White;
            this.picDrillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDrillColor.Location = new System.Drawing.Point(68, 82);
            this.picDrillColor.Name = "picDrillColor";
            this.picDrillColor.Size = new System.Drawing.Size(69, 13);
            this.picDrillColor.TabIndex = 4;
            this.picDrillColor.TabStop = false;
            // 
            // picPathColor
            // 
            this.picPathColor.BackColor = System.Drawing.Color.White;
            this.picPathColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPathColor.Location = new System.Drawing.Point(68, 38);
            this.picPathColor.Name = "picPathColor";
            this.picPathColor.Size = new System.Drawing.Size(69, 13);
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
            this.groupSetColor.Location = new System.Drawing.Point(12, 12);
            this.groupSetColor.Name = "groupSetColor";
            this.groupSetColor.Size = new System.Drawing.Size(147, 151);
            this.groupSetColor.TabIndex = 7;
            this.groupSetColor.TabStop = false;
            this.groupSetColor.Text = "Nastavení barev";
            // 
            // btnTransition
            // 
            this.btnTransition.Location = new System.Drawing.Point(65, 108);
            this.btnTransition.Name = "btnTransition";
            this.btnTransition.Size = new System.Drawing.Size(75, 23);
            this.btnTransition.TabIndex = 6;
            this.btnTransition.Text = "Přechod";
            this.btnTransition.UseVisualStyleBackColor = true;
            this.btnTransition.Click += new System.EventHandler(this.btnTransition_Click);
            // 
            // picTranslationColor
            // 
            this.picTranslationColor.BackColor = System.Drawing.Color.White;
            this.picTranslationColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTranslationColor.Location = new System.Drawing.Point(68, 126);
            this.picTranslationColor.Name = "picTranslationColor";
            this.picTranslationColor.Size = new System.Drawing.Size(69, 13);
            this.picTranslationColor.TabIndex = 7;
            this.picTranslationColor.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numPort);
            this.groupBox1.Location = new System.Drawing.Point(166, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 150);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nastavení COM portu";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(6, 21);
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(121, 20);
            this.numPort.TabIndex = 0;
            this.numPort.Click += new System.EventHandler(this.numPort_Click);
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 175);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupSetColor);
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
    }
}