namespace PixIt_0._3 {
    partial class formPrintProgress {
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
            this.ProgressBarPrint = new System.Windows.Forms.ProgressBar();
            this.LabelCommand = new System.Windows.Forms.Label();
            this.ButtonPause = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProgressBarPrint
            // 
            this.ProgressBarPrint.Cursor = System.Windows.Forms.Cursors.Default;
            this.ProgressBarPrint.Location = new System.Drawing.Point(91, 8);
            this.ProgressBarPrint.Name = "ProgressBarPrint";
            this.ProgressBarPrint.Size = new System.Drawing.Size(346, 36);
            this.ProgressBarPrint.Step = 1;
            this.ProgressBarPrint.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBarPrint.TabIndex = 0;
            // 
            // LabelCommand
            // 
            this.LabelCommand.Font = new System.Drawing.Font("Agency FB", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCommand.ForeColor = System.Drawing.Color.Gray;
            this.LabelCommand.Location = new System.Drawing.Point(91, 48);
            this.LabelCommand.Name = "LabelCommand";
            this.LabelCommand.Size = new System.Drawing.Size(346, 32);
            this.LabelCommand.TabIndex = 3;
            this.LabelCommand.Text = "Command";
            this.LabelCommand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonPause
            // 
            this.ButtonPause.BackColor = System.Drawing.Color.Transparent;
            this.ButtonPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ButtonPause.Location = new System.Drawing.Point(443, 8);
            this.ButtonPause.Name = "ButtonPause";
            this.ButtonPause.Size = new System.Drawing.Size(107, 36);
            this.ButtonPause.TabIndex = 4;
            this.ButtonPause.Text = "Pozastavit";
            this.ButtonPause.UseVisualStyleBackColor = false;
            this.ButtonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PixIt_0._3.Properties.Resources.time;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // formPrintProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 89);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ButtonPause);
            this.Controls.Add(this.LabelCommand);
            this.Controls.Add(this.ProgressBarPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "formPrintProgress";
            this.Text = "Stav tisku";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formPrintProgress_FormClosed);
            this.Load += new System.EventHandler(this.formPrintProgress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBarPrint;
        private System.Windows.Forms.Label LabelCommand;
        private System.Windows.Forms.Button ButtonPause;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}