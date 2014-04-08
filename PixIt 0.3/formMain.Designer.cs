namespace PixIt_0._3
{
    partial class formMain
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSetttings = new System.Windows.Forms.Button();
            this.btnPort = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.btnDraw = new System.Windows.Forms.Button();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picDraw = new System.Windows.Forms.PictureBox();
            this.listBoxVectors = new System.Windows.Forms.ListBox();
            this.labelOriginal = new System.Windows.Forms.Label();
            this.labelDraw = new System.Windows.Forms.Label();
            this.labelVectots = new System.Windows.Forms.Label();
            this.picOpenPort = new System.Windows.Forms.PictureBox();
            this.dialogOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolPortStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolWidth = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolHeight = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonDebug = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDraw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpenPort)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(19, 5);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 28);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Načíst";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSetttings
            // 
            this.btnSetttings.Location = new System.Drawing.Point(19, 41);
            this.btnSetttings.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetttings.Name = "btnSetttings";
            this.btnSetttings.Size = new System.Drawing.Size(100, 28);
            this.btnSetttings.TabIndex = 1;
            this.btnSetttings.Text = "Nastavení";
            this.btnSetttings.UseVisualStyleBackColor = true;
            this.btnSetttings.Click += new System.EventHandler(this.btnSetttings_Click);
            // 
            // btnPort
            // 
            this.btnPort.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPort.Location = new System.Drawing.Point(19, 76);
            this.btnPort.Margin = new System.Windows.Forms.Padding(4);
            this.btnPort.Name = "btnPort";
            this.btnPort.Size = new System.Drawing.Size(100, 41);
            this.btnPort.TabIndex = 2;
            this.btnPort.Text = "Otevřít port";
            this.btnPort.UseVisualStyleBackColor = true;
            this.btnPort.Click += new System.EventHandler(this.btnPort_Click);
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(19, 124);
            this.btnManual.Margin = new System.Windows.Forms.Padding(4);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(100, 48);
            this.btnManual.TabIndex = 3;
            this.btnManual.Text = "Manuální ovládání";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnDraw
            // 
            this.btnDraw.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnDraw.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDraw.Location = new System.Drawing.Point(16, 343);
            this.btnDraw.Margin = new System.Windows.Forms.Padding(4);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(100, 60);
            this.btnDraw.TabIndex = 4;
            this.btnDraw.Text = "Vykreslit";
            this.btnDraw.UseVisualStyleBackColor = false;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // picOriginal
            // 
            this.picOriginal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.picOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOriginal.Location = new System.Drawing.Point(127, 31);
            this.picOriginal.Margin = new System.Windows.Forms.Padding(4);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(466, 372);
            this.picOriginal.TabIndex = 5;
            this.picOriginal.TabStop = false;
            this.picOriginal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picOriginal_MouseClick);
            this.picOriginal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picOriginal_MouseMove);
            // 
            // picDraw
            // 
            this.picDraw.BackColor = System.Drawing.SystemColors.ControlLight;
            this.picDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDraw.Location = new System.Drawing.Point(597, 31);
            this.picDraw.Margin = new System.Windows.Forms.Padding(4);
            this.picDraw.Name = "picDraw";
            this.picDraw.Size = new System.Drawing.Size(466, 372);
            this.picDraw.TabIndex = 6;
            this.picDraw.TabStop = false;
            // 
            // listBoxVectors
            // 
            this.listBoxVectors.FormattingEnabled = true;
            this.listBoxVectors.ItemHeight = 16;
            this.listBoxVectors.Location = new System.Drawing.Point(1076, 31);
            this.listBoxVectors.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxVectors.Name = "listBoxVectors";
            this.listBoxVectors.Size = new System.Drawing.Size(159, 372);
            this.listBoxVectors.TabIndex = 7;
            // 
            // labelOriginal
            // 
            this.labelOriginal.AutoSize = true;
            this.labelOriginal.Location = new System.Drawing.Point(135, 11);
            this.labelOriginal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Size = new System.Drawing.Size(57, 17);
            this.labelOriginal.TabIndex = 9;
            this.labelOriginal.Text = "Originál";
            // 
            // labelDraw
            // 
            this.labelDraw.AutoSize = true;
            this.labelDraw.Location = new System.Drawing.Point(611, 11);
            this.labelDraw.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDraw.Name = "labelDraw";
            this.labelDraw.Size = new System.Drawing.Size(72, 17);
            this.labelDraw.TabIndex = 10;
            this.labelDraw.Text = "Zobrazení";
            // 
            // labelVectots
            // 
            this.labelVectots.AutoSize = true;
            this.labelVectots.Location = new System.Drawing.Point(1072, 11);
            this.labelVectots.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVectots.Name = "labelVectots";
            this.labelVectots.Size = new System.Drawing.Size(56, 17);
            this.labelVectots.TabIndex = 12;
            this.labelVectots.Text = "Vektory";
            // 
            // picOpenPort
            // 
            this.picOpenPort.BackColor = System.Drawing.Color.Red;
            this.picOpenPort.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picOpenPort.Location = new System.Drawing.Point(28, 106);
            this.picOpenPort.Margin = new System.Windows.Forms.Padding(4);
            this.picOpenPort.Name = "picOpenPort";
            this.picOpenPort.Size = new System.Drawing.Size(81, 9);
            this.picOpenPort.TabIndex = 14;
            this.picOpenPort.TabStop = false;
            // 
            // dialogOpenFile
            // 
            this.dialogOpenFile.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolPortStatus,
            this.toolWidth,
            this.toolHeight});
            this.statusStrip1.Location = new System.Drawing.Point(0, 413);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1239, 25);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolPortStatus
            // 
            this.toolPortStatus.Name = "toolPortStatus";
            this.toolPortStatus.Size = new System.Drawing.Size(186, 20);
            this.toolPortStatus.Text = "Stav portu: Port je uzavřen!";
            // 
            // toolWidth
            // 
            this.toolWidth.Margin = new System.Windows.Forms.Padding(30, 3, 0, 2);
            this.toolWidth.Name = "toolWidth";
            this.toolWidth.Size = new System.Drawing.Size(64, 20);
            this.toolWidth.Text = "Width: 0";
            // 
            // toolHeight
            // 
            this.toolHeight.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolHeight.Name = "toolHeight";
            this.toolHeight.Size = new System.Drawing.Size(69, 20);
            this.toolHeight.Text = "Height: 0";
            // 
            // buttonDebug
            // 
            this.buttonDebug.Location = new System.Drawing.Point(19, 181);
            this.buttonDebug.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDebug.Name = "buttonDebug";
            this.buttonDebug.Size = new System.Drawing.Size(100, 28);
            this.buttonDebug.TabIndex = 21;
            this.buttonDebug.Text = "Debug";
            this.buttonDebug.UseVisualStyleBackColor = true;
            this.buttonDebug.Click += new System.EventHandler(this.buttonDebug_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 438);
            this.Controls.Add(this.buttonDebug);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.picOpenPort);
            this.Controls.Add(this.labelVectots);
            this.Controls.Add(this.labelDraw);
            this.Controls.Add(this.labelOriginal);
            this.Controls.Add(this.listBoxVectors);
            this.Controls.Add(this.picDraw);
            this.Controls.Add(this.picOriginal);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.btnManual);
            this.Controls.Add(this.btnPort);
            this.Controls.Add(this.btnSetttings);
            this.Controls.Add(this.btnLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formMain";
            this.Text = "PixIt 0.3";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDraw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpenPort)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSetttings;
        private System.Windows.Forms.Button btnPort;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picDraw;
        private System.Windows.Forms.ListBox listBoxVectors;
        private System.Windows.Forms.Label labelOriginal;
        private System.Windows.Forms.Label labelDraw;
        private System.Windows.Forms.Label labelVectots;
        private System.Windows.Forms.PictureBox picOpenPort;
        private System.Windows.Forms.OpenFileDialog dialogOpenFile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolWidth;
        private System.Windows.Forms.ToolStripStatusLabel toolHeight;
        private System.Windows.Forms.Button buttonDebug;
        public System.Windows.Forms.ToolStripStatusLabel toolPortStatus;
    }
}

