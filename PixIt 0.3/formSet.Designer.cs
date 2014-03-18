namespace PixIt_0._3
{
    partial class formSet
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupSetColor = new System.Windows.Forms.GroupBox();
            this.btnTransition = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupSetColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
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
            // 
            // btnDrill
            // 
            this.btnDrill.Location = new System.Drawing.Point(65, 64);
            this.btnDrill.Name = "btnDrill";
            this.btnDrill.Size = new System.Drawing.Size(75, 23);
            this.btnDrill.TabIndex = 1;
            this.btnDrill.Text = "Vrtání";
            this.btnDrill.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 120);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(68, 82);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 13);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(68, 38);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(69, 13);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // groupSetColor
            // 
            this.groupSetColor.Controls.Add(this.btnTransition);
            this.groupSetColor.Controls.Add(this.pictureBox4);
            this.groupSetColor.Controls.Add(this.pictureBox1);
            this.groupSetColor.Controls.Add(this.btnDrill);
            this.groupSetColor.Controls.Add(this.btnRoute);
            this.groupSetColor.Controls.Add(this.pictureBox2);
            this.groupSetColor.Controls.Add(this.pictureBox3);
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
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(68, 126);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(69, 13);
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
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
            // 
            // formSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 175);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupSetColor);
            this.Name = "formSet";
            this.Text = "Nastavení";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupSetColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRoute;
        private System.Windows.Forms.Button btnDrill;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox groupSetColor;
        private System.Windows.Forms.Button btnTransition;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numPort;
    }
}