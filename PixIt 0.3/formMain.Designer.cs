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
            this.components = new System.ComponentModel.Container();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSetttings = new System.Windows.Forms.Button();
            this.btnPort = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picDraw = new System.Windows.Forms.PictureBox();
            this.listBoxPoints = new System.Windows.Forms.ListBox();
            this.labelOriginal = new System.Windows.Forms.Label();
            this.labelDraw = new System.Windows.Forms.Label();
            this.picOpenPort = new System.Windows.Forms.PictureBox();
            this.dialogOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolPortStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolWidth = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolHeight = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolVectorCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonDebug = new System.Windows.Forms.Button();
            this.buttonDrawVectors = new System.Windows.Forms.Button();
            this.listBoxVectors = new System.Windows.Forms.ListBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.listBoxPointsDrill = new System.Windows.Forms.ListBox();
            this.buttonDrill = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabRoutes = new System.Windows.Forms.TabPage();
            this.tabDrill = new System.Windows.Forms.TabPage();
            this.tabVectors = new System.Windows.Forms.TabPage();
            this.buttonPrintAndDraw = new System.Windows.Forms.Button();
            this.timerPrinterCheck = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDraw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpenPort)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabRoutes.SuspendLayout();
            this.tabDrill.SuspendLayout();
            this.tabVectors.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.White;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Location = new System.Drawing.Point(13, 240);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(106, 28);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Načíst obrázek";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSetttings
            // 
            this.btnSetttings.BackColor = System.Drawing.Color.White;
            this.btnSetttings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetttings.Location = new System.Drawing.Point(13, 31);
            this.btnSetttings.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetttings.Name = "btnSetttings";
            this.btnSetttings.Size = new System.Drawing.Size(106, 28);
            this.btnSetttings.TabIndex = 1;
            this.btnSetttings.Text = "Nastavení";
            this.btnSetttings.UseVisualStyleBackColor = false;
            this.btnSetttings.Click += new System.EventHandler(this.btnSetttings_Click);
            // 
            // btnPort
            // 
            this.btnPort.BackColor = System.Drawing.Color.White;
            this.btnPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPort.Location = new System.Drawing.Point(13, 118);
            this.btnPort.Margin = new System.Windows.Forms.Padding(4);
            this.btnPort.Name = "btnPort";
            this.btnPort.Size = new System.Drawing.Size(106, 41);
            this.btnPort.TabIndex = 2;
            this.btnPort.Text = "Otevřít port";
            this.btnPort.UseVisualStyleBackColor = false;
            this.btnPort.Click += new System.EventHandler(this.btnPort_Click);
            // 
            // btnManual
            // 
            this.btnManual.BackColor = System.Drawing.Color.White;
            this.btnManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManual.Location = new System.Drawing.Point(13, 167);
            this.btnManual.Margin = new System.Windows.Forms.Padding(4);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(106, 48);
            this.btnManual.TabIndex = 3;
            this.btnManual.Text = "Manuální ovládání";
            this.btnManual.UseVisualStyleBackColor = false;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
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
            // listBoxPoints
            // 
            this.listBoxPoints.FormattingEnabled = true;
            this.listBoxPoints.ItemHeight = 16;
            this.listBoxPoints.Location = new System.Drawing.Point(8, 7);
            this.listBoxPoints.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxPoints.Name = "listBoxPoints";
            this.listBoxPoints.Size = new System.Drawing.Size(269, 324);
            this.listBoxPoints.TabIndex = 7;
            this.listBoxPoints.SelectedIndexChanged += new System.EventHandler(this.listBoxVectors_SelectedIndexChanged);
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
            // picOpenPort
            // 
            this.picOpenPort.BackColor = System.Drawing.Color.Maroon;
            this.picOpenPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picOpenPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOpenPort.Location = new System.Drawing.Point(13, 118);
            this.picOpenPort.Margin = new System.Windows.Forms.Padding(4);
            this.picOpenPort.Name = "picOpenPort";
            this.picOpenPort.Size = new System.Drawing.Size(10, 41);
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
            this.toolHeight,
            this.toolVectorCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 418);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1383, 25);
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
            // toolVectorCount
            // 
            this.toolVectorCount.Margin = new System.Windows.Forms.Padding(30, 3, 0, 2);
            this.toolVectorCount.Name = "toolVectorCount";
            this.toolVectorCount.Size = new System.Drawing.Size(89, 20);
            this.toolVectorCount.Text = "Počet tras: 0";
            // 
            // buttonDebug
            // 
            this.buttonDebug.BackColor = System.Drawing.Color.White;
            this.buttonDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDebug.Location = new System.Drawing.Point(13, 66);
            this.buttonDebug.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDebug.Name = "buttonDebug";
            this.buttonDebug.Size = new System.Drawing.Size(106, 28);
            this.buttonDebug.TabIndex = 21;
            this.buttonDebug.Text = "Debug";
            this.buttonDebug.UseVisualStyleBackColor = false;
            this.buttonDebug.Click += new System.EventHandler(this.buttonDebug_Click);
            // 
            // buttonDrawVectors
            // 
            this.buttonDrawVectors.BackColor = System.Drawing.Color.Silver;
            this.buttonDrawVectors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDrawVectors.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDrawVectors.Location = new System.Drawing.Point(7, 306);
            this.buttonDrawVectors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDrawVectors.Name = "buttonDrawVectors";
            this.buttonDrawVectors.Size = new System.Drawing.Size(272, 32);
            this.buttonDrawVectors.TabIndex = 23;
            this.buttonDrawVectors.Text = "Zobraz všechny vektory";
            this.buttonDrawVectors.UseVisualStyleBackColor = false;
            this.buttonDrawVectors.Click += new System.EventHandler(this.buttonDrawVectors_Click);
            // 
            // listBoxVectors
            // 
            this.listBoxVectors.FormattingEnabled = true;
            this.listBoxVectors.ItemHeight = 16;
            this.listBoxVectors.Location = new System.Drawing.Point(8, 7);
            this.listBoxVectors.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxVectors.Name = "listBoxVectors";
            this.listBoxVectors.Size = new System.Drawing.Size(269, 292);
            this.listBoxVectors.TabIndex = 25;
            this.listBoxVectors.SelectedIndexChanged += new System.EventHandler(this.listBoxVectors_SelectedIndexChanged_1);
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonPrint.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPrint.Location = new System.Drawing.Point(13, 276);
            this.buttonPrint.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(106, 28);
            this.buttonPrint.TabIndex = 30;
            this.buttonPrint.Text = "Tisk";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // listBoxPointsDrill
            // 
            this.listBoxPointsDrill.FormattingEnabled = true;
            this.listBoxPointsDrill.ItemHeight = 16;
            this.listBoxPointsDrill.Location = new System.Drawing.Point(8, 7);
            this.listBoxPointsDrill.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxPointsDrill.Name = "listBoxPointsDrill";
            this.listBoxPointsDrill.Size = new System.Drawing.Size(269, 324);
            this.listBoxPointsDrill.TabIndex = 34;
            this.listBoxPointsDrill.SelectedIndexChanged += new System.EventHandler(this.listBoxPointsDrill_SelectedIndexChanged);
            // 
            // buttonDrill
            // 
            this.buttonDrill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonDrill.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonDrill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDrill.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDrill.Location = new System.Drawing.Point(13, 312);
            this.buttonDrill.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDrill.Name = "buttonDrill";
            this.buttonDrill.Size = new System.Drawing.Size(106, 28);
            this.buttonDrill.TabIndex = 37;
            this.buttonDrill.Text = "Vrtat";
            this.buttonDrill.UseVisualStyleBackColor = false;
            this.buttonDrill.Click += new System.EventHandler(this.buttonDrill_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabRoutes);
            this.tabControl.Controls.Add(this.tabDrill);
            this.tabControl.Controls.Add(this.tabVectors);
            this.tabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl.Location = new System.Drawing.Point(1072, 31);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(297, 373);
            this.tabControl.TabIndex = 38;
            // 
            // tabRoutes
            // 
            this.tabRoutes.Controls.Add(this.listBoxPoints);
            this.tabRoutes.Location = new System.Drawing.Point(4, 25);
            this.tabRoutes.Margin = new System.Windows.Forms.Padding(4);
            this.tabRoutes.Name = "tabRoutes";
            this.tabRoutes.Padding = new System.Windows.Forms.Padding(4);
            this.tabRoutes.Size = new System.Drawing.Size(289, 344);
            this.tabRoutes.TabIndex = 0;
            this.tabRoutes.Text = "Body cest";
            this.tabRoutes.UseVisualStyleBackColor = true;
            // 
            // tabDrill
            // 
            this.tabDrill.Controls.Add(this.listBoxPointsDrill);
            this.tabDrill.Location = new System.Drawing.Point(4, 25);
            this.tabDrill.Margin = new System.Windows.Forms.Padding(4);
            this.tabDrill.Name = "tabDrill";
            this.tabDrill.Padding = new System.Windows.Forms.Padding(4);
            this.tabDrill.Size = new System.Drawing.Size(289, 344);
            this.tabDrill.TabIndex = 1;
            this.tabDrill.Text = "Body vrtání";
            this.tabDrill.UseVisualStyleBackColor = true;
            // 
            // tabVectors
            // 
            this.tabVectors.BackColor = System.Drawing.Color.White;
            this.tabVectors.Controls.Add(this.listBoxVectors);
            this.tabVectors.Controls.Add(this.buttonDrawVectors);
            this.tabVectors.Location = new System.Drawing.Point(4, 25);
            this.tabVectors.Margin = new System.Windows.Forms.Padding(4);
            this.tabVectors.Name = "tabVectors";
            this.tabVectors.Padding = new System.Windows.Forms.Padding(4);
            this.tabVectors.Size = new System.Drawing.Size(289, 344);
            this.tabVectors.TabIndex = 2;
            this.tabVectors.Text = "Vektory";
            // 
            // buttonPrintAndDraw
            // 
            this.buttonPrintAndDraw.BackColor = System.Drawing.Color.Silver;
            this.buttonPrintAndDraw.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonPrintAndDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrintAndDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPrintAndDraw.Location = new System.Drawing.Point(13, 348);
            this.buttonPrintAndDraw.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrintAndDraw.Name = "buttonPrintAndDraw";
            this.buttonPrintAndDraw.Size = new System.Drawing.Size(106, 56);
            this.buttonPrintAndDraw.TabIndex = 39;
            this.buttonPrintAndDraw.Text = "Vytiskout a vyvrtat";
            this.buttonPrintAndDraw.UseVisualStyleBackColor = false;
            this.buttonPrintAndDraw.Click += new System.EventHandler(this.buttonPrintAndDraw_Click);
            // 
            // timerPrinterCheck
            // 
            this.timerPrinterCheck.Interval = 300;
            this.timerPrinterCheck.Tick += new System.EventHandler(this.timerPrinterCheck_Tick);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 443);
            this.Controls.Add(this.buttonPrintAndDraw);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonDrill);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonDebug);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.picOpenPort);
            this.Controls.Add(this.labelDraw);
            this.Controls.Add(this.labelOriginal);
            this.Controls.Add(this.picDraw);
            this.Controls.Add(this.picOriginal);
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
            this.tabControl.ResumeLayout(false);
            this.tabRoutes.ResumeLayout(false);
            this.tabDrill.ResumeLayout(false);
            this.tabVectors.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSetttings;
        private System.Windows.Forms.Button btnPort;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picDraw;
        private System.Windows.Forms.ListBox listBoxPoints;
        private System.Windows.Forms.Label labelOriginal;
        private System.Windows.Forms.Label labelDraw;
        private System.Windows.Forms.PictureBox picOpenPort;
        private System.Windows.Forms.OpenFileDialog dialogOpenFile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolWidth;
        private System.Windows.Forms.ToolStripStatusLabel toolHeight;
        private System.Windows.Forms.Button buttonDebug;
        public System.Windows.Forms.ToolStripStatusLabel toolPortStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolVectorCount;
        private System.Windows.Forms.Button buttonDrawVectors;
        private System.Windows.Forms.ListBox listBoxVectors;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.ListBox listBoxPointsDrill;
        private System.Windows.Forms.Button buttonDrill;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabRoutes;
        private System.Windows.Forms.TabPage tabDrill;
        private System.Windows.Forms.TabPage tabVectors;
        private System.Windows.Forms.Button buttonPrintAndDraw;
        private System.Windows.Forms.Timer timerPrinterCheck;
    }
}

