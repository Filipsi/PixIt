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
            this.components = new System.ComponentModel.Container();
            this.ProgressBarPrint = new System.Windows.Forms.ProgressBar();
            this.LabelInfo = new System.Windows.Forms.Label();
            this.TimerUpdate = new System.Windows.Forms.Timer(this.components);
            this.LabelCommand = new System.Windows.Forms.Label();
            this.ButtonPause = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProgressBarPrint
            // 
            this.ProgressBarPrint.Cursor = System.Windows.Forms.Cursors.Default;
            this.ProgressBarPrint.Location = new System.Drawing.Point(11, 10);
            this.ProgressBarPrint.Name = "ProgressBarPrint";
            this.ProgressBarPrint.Size = new System.Drawing.Size(637, 32);
            this.ProgressBarPrint.Step = 1;
            this.ProgressBarPrint.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBarPrint.TabIndex = 0;
            // 
            // LabelInfo
            // 
            this.LabelInfo.Location = new System.Drawing.Point(12, 48);
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size(633, 23);
            this.LabelInfo.TabIndex = 2;
            this.LabelInfo.Text = "Info";
            this.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimerUpdate
            // 
            this.TimerUpdate.Enabled = true;
            this.TimerUpdate.Interval = 10;
            this.TimerUpdate.Tick += new System.EventHandler(this.TimerUpdate_Tick);
            // 
            // LabelCommand
            // 
            this.LabelCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelCommand.ForeColor = System.Drawing.Color.Gray;
            this.LabelCommand.Location = new System.Drawing.Point(11, 71);
            this.LabelCommand.Name = "LabelCommand";
            this.LabelCommand.Size = new System.Drawing.Size(637, 16);
            this.LabelCommand.TabIndex = 3;
            this.LabelCommand.Text = "Command";
            this.LabelCommand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonPause
            // 
            this.ButtonPause.BackColor = System.Drawing.Color.LightGray;
            this.ButtonPause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonPause.Location = new System.Drawing.Point(553, 48);
            this.ButtonPause.Name = "ButtonPause";
            this.ButtonPause.Size = new System.Drawing.Size(95, 39);
            this.ButtonPause.TabIndex = 4;
            this.ButtonPause.Text = "Pozastavit";
            this.ButtonPause.UseVisualStyleBackColor = false;
            this.ButtonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // formPrintProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 94);
            this.Controls.Add(this.ButtonPause);
            this.Controls.Add(this.LabelCommand);
            this.Controls.Add(this.LabelInfo);
            this.Controls.Add(this.ProgressBarPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "formPrintProgress";
            this.Text = "Tisk";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formPrintProgress_FormClosed);
            this.Load += new System.EventHandler(this.formPrintProgress_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBarPrint;
        private System.Windows.Forms.Label LabelInfo;
        private System.Windows.Forms.Timer TimerUpdate;
        private System.Windows.Forms.Label LabelCommand;
        private System.Windows.Forms.Button ButtonPause;
    }
}