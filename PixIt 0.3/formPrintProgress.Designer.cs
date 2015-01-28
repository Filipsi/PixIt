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
            this.LabelProgress = new System.Windows.Forms.Label();
            this.ButtonPause = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelCommand = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProgressBarPrint
            // 
            this.ProgressBarPrint.Cursor = System.Windows.Forms.Cursors.Default;
            this.ProgressBarPrint.Location = new System.Drawing.Point(82, 6);
            this.ProgressBarPrint.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressBarPrint.Name = "ProgressBarPrint";
            this.ProgressBarPrint.Size = new System.Drawing.Size(260, 29);
            this.ProgressBarPrint.Step = 1;
            this.ProgressBarPrint.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBarPrint.TabIndex = 0;
            // 
            // LabelProgress
            // 
            this.LabelProgress.Font = new System.Drawing.Font("Agency FB", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelProgress.ForeColor = System.Drawing.Color.Black;
            this.LabelProgress.Location = new System.Drawing.Point(82, 39);
            this.LabelProgress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelProgress.Name = "LabelProgress";
            this.LabelProgress.Size = new System.Drawing.Size(260, 25);
            this.LabelProgress.TabIndex = 3;
            this.LabelProgress.Text = "Progress";
            this.LabelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonPause
            // 
            this.ButtonPause.BackColor = System.Drawing.Color.Transparent;
            this.ButtonPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ButtonPause.Location = new System.Drawing.Point(346, 6);
            this.ButtonPause.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonPause.Name = "ButtonPause";
            this.ButtonPause.Size = new System.Drawing.Size(80, 29);
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
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 75);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // labelCommand
            // 
            this.labelCommand.Font = new System.Drawing.Font("Agency FB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommand.ForeColor = System.Drawing.Color.Gray;
            this.labelCommand.Location = new System.Drawing.Point(82, 64);
            this.labelCommand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCommand.Name = "labelCommand";
            this.labelCommand.Size = new System.Drawing.Size(260, 17);
            this.labelCommand.TabIndex = 6;
            this.labelCommand.Text = "Command";
            this.labelCommand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formPrintProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 94);
            this.Controls.Add(this.labelCommand);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ButtonPause);
            this.Controls.Add(this.LabelProgress);
            this.Controls.Add(this.ProgressBarPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formPrintProgress";
            this.Text = "Stav tisku";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formPrintProgress_FormClosed);
            this.Load += new System.EventHandler(this.formPrintProgress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBarPrint;
        private System.Windows.Forms.Label LabelProgress;
        private System.Windows.Forms.Button ButtonPause;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelCommand;
    }
}