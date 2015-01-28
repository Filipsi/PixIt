namespace PixIt_0._3
{
    partial class formDebug
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
            this.components = new System.ComponentModel.Container();
            this.listBoxDebug = new System.Windows.Forms.ListBox();
            this.TextBoxCommandLine = new System.Windows.Forms.TextBox();
            this.groupConsole = new System.Windows.Forms.GroupBox();
            this.groupPinControl = new System.Windows.Forms.GroupBox();
            this.groupPinStatus = new System.Windows.Forms.GroupBox();
            this.labelPin7 = new System.Windows.Forms.Label();
            this.pbPin7 = new System.Windows.Forms.PictureBox();
            this.pbPin6 = new System.Windows.Forms.PictureBox();
            this.labelPin6 = new System.Windows.Forms.Label();
            this.pbPin5 = new System.Windows.Forms.PictureBox();
            this.labelPin5 = new System.Windows.Forms.Label();
            this.pbPin4 = new System.Windows.Forms.PictureBox();
            this.labelPin4 = new System.Windows.Forms.Label();
            this.pbPin3 = new System.Windows.Forms.PictureBox();
            this.labelPin3 = new System.Windows.Forms.Label();
            this.pbPin2 = new System.Windows.Forms.PictureBox();
            this.labelPin2 = new System.Windows.Forms.Label();
            this.pbPin1 = new System.Windows.Forms.PictureBox();
            this.labelPin1 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.timerPinControl = new System.Windows.Forms.Timer(this.components);
            this.groupConsole.SuspendLayout();
            this.groupPinControl.SuspendLayout();
            this.groupPinStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPin7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPin6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPin5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPin4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPin3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPin1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxDebug
            // 
            this.listBoxDebug.BackColor = System.Drawing.Color.Black;
            this.listBoxDebug.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxDebug.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxDebug.ForeColor = System.Drawing.Color.White;
            this.listBoxDebug.FormattingEnabled = true;
            this.listBoxDebug.Location = new System.Drawing.Point(6, 19);
            this.listBoxDebug.Name = "listBoxDebug";
            this.listBoxDebug.Size = new System.Drawing.Size(490, 238);
            this.listBoxDebug.TabIndex = 15;
            this.listBoxDebug.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxDebug_DrawItem);
            // 
            // TextBoxCommandLine
            // 
            this.TextBoxCommandLine.Location = new System.Drawing.Point(5, 262);
            this.TextBoxCommandLine.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxCommandLine.Name = "TextBoxCommandLine";
            this.TextBoxCommandLine.Size = new System.Drawing.Size(491, 20);
            this.TextBoxCommandLine.TabIndex = 17;
            this.TextBoxCommandLine.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBoxCommandLine_PreviewKeyDown);
            // 
            // groupConsole
            // 
            this.groupConsole.Controls.Add(this.listBoxDebug);
            this.groupConsole.Controls.Add(this.TextBoxCommandLine);
            this.groupConsole.Location = new System.Drawing.Point(12, 12);
            this.groupConsole.Name = "groupConsole";
            this.groupConsole.Size = new System.Drawing.Size(508, 292);
            this.groupConsole.TabIndex = 19;
            this.groupConsole.TabStop = false;
            this.groupConsole.Text = "Konzole";
            // 
            // groupPinControl
            // 
            this.groupPinControl.Controls.Add(this.groupPinStatus);
            this.groupPinControl.Controls.Add(this.labelStatus);
            this.groupPinControl.Location = new System.Drawing.Point(526, 12);
            this.groupPinControl.Name = "groupPinControl";
            this.groupPinControl.Size = new System.Drawing.Size(302, 101);
            this.groupPinControl.TabIndex = 20;
            this.groupPinControl.TabStop = false;
            this.groupPinControl.Text = "PinControl";
            // 
            // groupPinStatus
            // 
            this.groupPinStatus.BackColor = System.Drawing.Color.Transparent;
            this.groupPinStatus.Controls.Add(this.labelPin7);
            this.groupPinStatus.Controls.Add(this.pbPin7);
            this.groupPinStatus.Controls.Add(this.pbPin6);
            this.groupPinStatus.Controls.Add(this.labelPin6);
            this.groupPinStatus.Controls.Add(this.pbPin5);
            this.groupPinStatus.Controls.Add(this.labelPin5);
            this.groupPinStatus.Controls.Add(this.pbPin4);
            this.groupPinStatus.Controls.Add(this.labelPin4);
            this.groupPinStatus.Controls.Add(this.pbPin3);
            this.groupPinStatus.Controls.Add(this.labelPin3);
            this.groupPinStatus.Controls.Add(this.pbPin2);
            this.groupPinStatus.Controls.Add(this.labelPin2);
            this.groupPinStatus.Controls.Add(this.pbPin1);
            this.groupPinStatus.Controls.Add(this.labelPin1);
            this.groupPinStatus.Location = new System.Drawing.Point(9, 38);
            this.groupPinStatus.Name = "groupPinStatus";
            this.groupPinStatus.Size = new System.Drawing.Size(282, 52);
            this.groupPinStatus.TabIndex = 23;
            this.groupPinStatus.TabStop = false;
            this.groupPinStatus.Text = "Piny Arduina";
            // 
            // labelPin7
            // 
            this.labelPin7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPin7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPin7.Location = new System.Drawing.Point(243, 35);
            this.labelPin7.Name = "labelPin7";
            this.labelPin7.Size = new System.Drawing.Size(32, 12);
            this.labelPin7.TabIndex = 26;
            this.labelPin7.Text = "?";
            this.labelPin7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPin7
            // 
            this.pbPin7.BackColor = System.Drawing.Color.Silver;
            this.pbPin7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPin7.Location = new System.Drawing.Point(243, 19);
            this.pbPin7.Name = "pbPin7";
            this.pbPin7.Size = new System.Drawing.Size(32, 16);
            this.pbPin7.TabIndex = 25;
            this.pbPin7.TabStop = false;
            // 
            // pbPin6
            // 
            this.pbPin6.BackColor = System.Drawing.Color.Silver;
            this.pbPin6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPin6.Location = new System.Drawing.Point(196, 19);
            this.pbPin6.Name = "pbPin6";
            this.pbPin6.Size = new System.Drawing.Size(32, 16);
            this.pbPin6.TabIndex = 24;
            this.pbPin6.TabStop = false;
            // 
            // labelPin6
            // 
            this.labelPin6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPin6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPin6.Location = new System.Drawing.Point(196, 35);
            this.labelPin6.Name = "labelPin6";
            this.labelPin6.Size = new System.Drawing.Size(32, 12);
            this.labelPin6.TabIndex = 25;
            this.labelPin6.Text = "?";
            this.labelPin6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPin5
            // 
            this.pbPin5.BackColor = System.Drawing.Color.Silver;
            this.pbPin5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPin5.Location = new System.Drawing.Point(158, 19);
            this.pbPin5.Name = "pbPin5";
            this.pbPin5.Size = new System.Drawing.Size(32, 16);
            this.pbPin5.TabIndex = 29;
            this.pbPin5.TabStop = false;
            // 
            // labelPin5
            // 
            this.labelPin5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPin5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPin5.Location = new System.Drawing.Point(158, 35);
            this.labelPin5.Name = "labelPin5";
            this.labelPin5.Size = new System.Drawing.Size(32, 12);
            this.labelPin5.TabIndex = 30;
            this.labelPin5.Text = "?";
            this.labelPin5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPin4
            // 
            this.pbPin4.BackColor = System.Drawing.Color.Silver;
            this.pbPin4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPin4.Location = new System.Drawing.Point(120, 19);
            this.pbPin4.Name = "pbPin4";
            this.pbPin4.Size = new System.Drawing.Size(32, 16);
            this.pbPin4.TabIndex = 27;
            this.pbPin4.TabStop = false;
            // 
            // labelPin4
            // 
            this.labelPin4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPin4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPin4.Location = new System.Drawing.Point(120, 35);
            this.labelPin4.Name = "labelPin4";
            this.labelPin4.Size = new System.Drawing.Size(32, 12);
            this.labelPin4.TabIndex = 28;
            this.labelPin4.Text = "?";
            this.labelPin4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPin3
            // 
            this.pbPin3.BackColor = System.Drawing.Color.Silver;
            this.pbPin3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPin3.Location = new System.Drawing.Point(82, 19);
            this.pbPin3.Name = "pbPin3";
            this.pbPin3.Size = new System.Drawing.Size(32, 16);
            this.pbPin3.TabIndex = 25;
            this.pbPin3.TabStop = false;
            // 
            // labelPin3
            // 
            this.labelPin3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPin3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPin3.Location = new System.Drawing.Point(82, 35);
            this.labelPin3.Name = "labelPin3";
            this.labelPin3.Size = new System.Drawing.Size(32, 12);
            this.labelPin3.TabIndex = 26;
            this.labelPin3.Text = "?";
            this.labelPin3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPin2
            // 
            this.pbPin2.BackColor = System.Drawing.Color.Silver;
            this.pbPin2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPin2.Location = new System.Drawing.Point(44, 19);
            this.pbPin2.Name = "pbPin2";
            this.pbPin2.Size = new System.Drawing.Size(32, 16);
            this.pbPin2.TabIndex = 23;
            this.pbPin2.TabStop = false;
            // 
            // labelPin2
            // 
            this.labelPin2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPin2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPin2.Location = new System.Drawing.Point(44, 35);
            this.labelPin2.Name = "labelPin2";
            this.labelPin2.Size = new System.Drawing.Size(32, 12);
            this.labelPin2.TabIndex = 24;
            this.labelPin2.Text = "?";
            this.labelPin2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPin1
            // 
            this.pbPin1.BackColor = System.Drawing.Color.Silver;
            this.pbPin1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPin1.Location = new System.Drawing.Point(6, 19);
            this.pbPin1.Name = "pbPin1";
            this.pbPin1.Size = new System.Drawing.Size(32, 16);
            this.pbPin1.TabIndex = 0;
            this.pbPin1.TabStop = false;
            // 
            // labelPin1
            // 
            this.labelPin1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPin1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPin1.Location = new System.Drawing.Point(6, 35);
            this.labelPin1.Name = "labelPin1";
            this.labelPin1.Size = new System.Drawing.Size(32, 12);
            this.labelPin1.TabIndex = 22;
            this.labelPin1.Text = "?";
            this.labelPin1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.labelStatus.Location = new System.Drawing.Point(6, 16);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(74, 13);
            this.labelStatus.TabIndex = 21;
            this.labelStatus.Text = "Neznámý stav";
            // 
            // timerPinControl
            // 
            this.timerPinControl.Enabled = true;
            this.timerPinControl.Interval = 1000;
            this.timerPinControl.Tick += new System.EventHandler(this.timerPinControl_Tick);
            // 
            // formDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 313);
            this.Controls.Add(this.groupPinControl);
            this.Controls.Add(this.groupConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "formDebug";
            this.Text = "Debug okno";
            this.Load += new System.EventHandler(this.formDebug_Load);
            this.groupConsole.ResumeLayout(false);
            this.groupConsole.PerformLayout();
            this.groupPinControl.ResumeLayout(false);
            this.groupPinControl.PerformLayout();
            this.groupPinStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPin7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPin6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPin5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPin4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPin3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPin1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox listBoxDebug;
        private System.Windows.Forms.TextBox TextBoxCommandLine;
        private System.Windows.Forms.GroupBox groupConsole;
        private System.Windows.Forms.GroupBox groupPinControl;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.PictureBox pbPin1;
        private System.Windows.Forms.Timer timerPinControl;
        private System.Windows.Forms.GroupBox groupPinStatus;
        private System.Windows.Forms.PictureBox pbPin6;
        private System.Windows.Forms.PictureBox pbPin5;
        private System.Windows.Forms.PictureBox pbPin4;
        private System.Windows.Forms.PictureBox pbPin3;
        private System.Windows.Forms.PictureBox pbPin2;
        private System.Windows.Forms.Label labelPin1;
        private System.Windows.Forms.Label labelPin6;
        private System.Windows.Forms.Label labelPin5;
        private System.Windows.Forms.Label labelPin4;
        private System.Windows.Forms.Label labelPin3;
        private System.Windows.Forms.Label labelPin2;
        private System.Windows.Forms.Label labelPin7;
        private System.Windows.Forms.PictureBox pbPin7;
    }
}