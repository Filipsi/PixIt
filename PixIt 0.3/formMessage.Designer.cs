namespace PixIt_0._3 {
    partial class formMessage {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.PictureBoxMesssage = new System.Windows.Forms.PictureBox();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.LabelText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMesssage)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxMesssage
            // 
            this.PictureBoxMesssage.BackgroundImage = global::PixIt_0._3.Properties.Resources.error;
            this.PictureBoxMesssage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBoxMesssage.Location = new System.Drawing.Point(9, 9);
            this.PictureBoxMesssage.Name = "PictureBoxMesssage";
            this.PictureBoxMesssage.Size = new System.Drawing.Size(128, 128);
            this.PictureBoxMesssage.TabIndex = 0;
            this.PictureBoxMesssage.TabStop = false;
            // 
            // LabelTitle
            // 
            this.LabelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelTitle.Location = new System.Drawing.Point(147, 12);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(306, 30);
            this.LabelTitle.TabIndex = 1;
            this.LabelTitle.Text = "Title";
            // 
            // LabelText
            // 
            this.LabelText.Location = new System.Drawing.Point(152, 42);
            this.LabelText.Name = "LabelText";
            this.LabelText.Size = new System.Drawing.Size(297, 95);
            this.LabelText.TabIndex = 2;
            this.LabelText.Text = "Text";
            // 
            // formMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 146);
            this.Controls.Add(this.LabelText);
            this.Controls.Add(this.LabelTitle);
            this.Controls.Add(this.PictureBoxMesssage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "formMessage";
            this.Text = "Systémové upozornění";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMesssage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxMesssage;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Label LabelText;
    }
}