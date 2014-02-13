namespace PixIt_2._0
{
    partial class Settings
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
            this.button_SetColorPath = new System.Windows.Forms.Button();
            this.pictureBox_PathColor = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_SetColorDrill = new System.Windows.Forms.Button();
            this.pictureBox_DrillColor = new System.Windows.Forms.PictureBox();
            this.button_SetColorTranslation = new System.Windows.Forms.Button();
            this.pictureBox_TranslationColor = new System.Windows.Forms.PictureBox();
            this.pictureBox_cursorColor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PathColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DrillColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TranslationColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cursorColor)).BeginInit();
            this.SuspendLayout();
            // 
            // button_SetColorPath
            // 
            this.button_SetColorPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_SetColorPath.Location = new System.Drawing.Point(15, 29);
            this.button_SetColorPath.Name = "button_SetColorPath";
            this.button_SetColorPath.Size = new System.Drawing.Size(57, 30);
            this.button_SetColorPath.TabIndex = 13;
            this.button_SetColorPath.Text = "Cesta";
            this.button_SetColorPath.UseVisualStyleBackColor = true;
            this.button_SetColorPath.Click += new System.EventHandler(this.button_SetColorPath_Click);
            // 
            // pictureBox_PathColor
            // 
            this.pictureBox_PathColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_PathColor.Location = new System.Drawing.Point(27, 52);
            this.pictureBox_PathColor.Name = "pictureBox_PathColor";
            this.pictureBox_PathColor.Size = new System.Drawing.Size(34, 16);
            this.pictureBox_PathColor.TabIndex = 14;
            this.pictureBox_PathColor.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Nastavení barev";
            // 
            // button_SetColorDrill
            // 
            this.button_SetColorDrill.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_SetColorDrill.Location = new System.Drawing.Point(78, 29);
            this.button_SetColorDrill.Name = "button_SetColorDrill";
            this.button_SetColorDrill.Size = new System.Drawing.Size(57, 30);
            this.button_SetColorDrill.TabIndex = 16;
            this.button_SetColorDrill.Text = "Vrtani";
            this.button_SetColorDrill.UseVisualStyleBackColor = true;
            this.button_SetColorDrill.Click += new System.EventHandler(this.button_SetColorDrill_Click);
            // 
            // pictureBox_DrillColor
            // 
            this.pictureBox_DrillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_DrillColor.Location = new System.Drawing.Point(89, 52);
            this.pictureBox_DrillColor.Name = "pictureBox_DrillColor";
            this.pictureBox_DrillColor.Size = new System.Drawing.Size(34, 16);
            this.pictureBox_DrillColor.TabIndex = 17;
            this.pictureBox_DrillColor.TabStop = false;
            // 
            // button_SetColorTranslation
            // 
            this.button_SetColorTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_SetColorTranslation.Location = new System.Drawing.Point(141, 29);
            this.button_SetColorTranslation.Name = "button_SetColorTranslation";
            this.button_SetColorTranslation.Size = new System.Drawing.Size(83, 30);
            this.button_SetColorTranslation.TabIndex = 18;
            this.button_SetColorTranslation.Text = "Přechod";
            this.button_SetColorTranslation.UseVisualStyleBackColor = true;
            this.button_SetColorTranslation.Click += new System.EventHandler(this.button_SetColorTranslation_Click);
            // 
            // pictureBox_TranslationColor
            // 
            this.pictureBox_TranslationColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_TranslationColor.Location = new System.Drawing.Point(150, 52);
            this.pictureBox_TranslationColor.Name = "pictureBox_TranslationColor";
            this.pictureBox_TranslationColor.Size = new System.Drawing.Size(65, 16);
            this.pictureBox_TranslationColor.TabIndex = 19;
            this.pictureBox_TranslationColor.TabStop = false;
            // 
            // pictureBox_cursorColor
            // 
            this.pictureBox_cursorColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_cursorColor.Location = new System.Drawing.Point(-6, -5);
            this.pictureBox_cursorColor.Name = "pictureBox_cursorColor";
            this.pictureBox_cursorColor.Size = new System.Drawing.Size(15, 155);
            this.pictureBox_cursorColor.TabIndex = 20;
            this.pictureBox_cursorColor.TabStop = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 143);
            this.Controls.Add(this.pictureBox_cursorColor);
            this.Controls.Add(this.button_SetColorTranslation);
            this.Controls.Add(this.button_SetColorDrill);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_SetColorPath);
            this.Controls.Add(this.pictureBox_PathColor);
            this.Controls.Add(this.pictureBox_DrillColor);
            this.Controls.Add(this.pictureBox_TranslationColor);
            this.Name = "Settings";
            this.ShowIcon = false;
            this.Text = "Nastavení";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PathColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DrillColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TranslationColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cursorColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_SetColorPath;
        private System.Windows.Forms.PictureBox pictureBox_PathColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_SetColorDrill;
        private System.Windows.Forms.PictureBox pictureBox_DrillColor;
        private System.Windows.Forms.Button button_SetColorTranslation;
        private System.Windows.Forms.PictureBox pictureBox_TranslationColor;
        public System.Windows.Forms.PictureBox pictureBox_cursorColor;
    }
}