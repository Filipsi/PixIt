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
            this.dialogOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.buttonDebug = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonDrill = new System.Windows.Forms.Button();
            this.buttonPrintAndDraw = new System.Windows.Forms.Button();
            this.ButtonEthernet = new System.Windows.Forms.Button();
            this.tabVectors = new System.Windows.Forms.TabPage();
            this.listBoxVectors = new System.Windows.Forms.ListBox();
            this.buttonDrawVectors = new System.Windows.Forms.Button();
            this.tabDrill = new System.Windows.Forms.TabPage();
            this.listBoxPointsDrill = new System.Windows.Forms.ListBox();
            this.tabRoutes = new System.Windows.Forms.TabPage();
            this.listBoxPoints = new System.Windows.Forms.ListBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.GroupPixit = new System.Windows.Forms.GroupBox();
            this.ButtonPixtureInfo = new System.Windows.Forms.Button();
            this.GroupPrinter = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picEthernet = new System.Windows.Forms.PictureBox();
            this.picOpenPort = new System.Windows.Forms.PictureBox();
            this.GroupPoints = new System.Windows.Forms.GroupBox();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LinkPixItGitHubRepo = new System.Windows.Forms.LinkLabel();
            this.LinkPixItArduinoGitHubRepo = new System.Windows.Forms.LinkLabel();
            this.tabVectors.SuspendLayout();
            this.tabDrill.SuspendLayout();
            this.tabRoutes.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.GroupPixit.SuspendLayout();
            this.GroupPrinter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEthernet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpenPort)).BeginInit();
            this.GroupPoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Location = new System.Drawing.Point(5, 76);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(99, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Načíst obrázek";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSetttings
            // 
            this.btnSetttings.BackColor = System.Drawing.Color.White;
            this.btnSetttings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetttings.Location = new System.Drawing.Point(5, 18);
            this.btnSetttings.Name = "btnSetttings";
            this.btnSetttings.Size = new System.Drawing.Size(118, 23);
            this.btnSetttings.TabIndex = 1;
            this.btnSetttings.Text = "Nastavení";
            this.btnSetttings.UseVisualStyleBackColor = false;
            this.btnSetttings.Click += new System.EventHandler(this.btnSetttings_Click);
            // 
            // btnPort
            // 
            this.btnPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(238)))), ((int)(((byte)(253)))));
            this.btnPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPort.Location = new System.Drawing.Point(19, 46);
            this.btnPort.Name = "btnPort";
            this.btnPort.Size = new System.Drawing.Size(104, 24);
            this.btnPort.TabIndex = 2;
            this.btnPort.Text = "Sériový port";
            this.btnPort.UseVisualStyleBackColor = false;
            this.btnPort.Click += new System.EventHandler(this.btnPort_Click);
            // 
            // btnManual
            // 
            this.btnManual.BackColor = System.Drawing.Color.White;
            this.btnManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManual.Location = new System.Drawing.Point(5, 18);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(91, 50);
            this.btnManual.TabIndex = 3;
            this.btnManual.Text = "Manuální ovládání";
            this.btnManual.UseVisualStyleBackColor = false;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // dialogOpenFile
            // 
            this.dialogOpenFile.FileName = "openFileDialog1";
            // 
            // buttonDebug
            // 
            this.buttonDebug.BackColor = System.Drawing.Color.White;
            this.buttonDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDebug.Location = new System.Drawing.Point(5, 47);
            this.buttonDebug.Name = "buttonDebug";
            this.buttonDebug.Size = new System.Drawing.Size(118, 23);
            this.buttonDebug.TabIndex = 21;
            this.buttonDebug.Text = "Debug";
            this.buttonDebug.UseVisualStyleBackColor = false;
            this.buttonDebug.Click += new System.EventHandler(this.buttonDebug_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.buttonPrint.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPrint.Location = new System.Drawing.Point(5, 73);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(91, 23);
            this.buttonPrint.TabIndex = 30;
            this.buttonPrint.Text = "Tisk cest";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonDrill
            // 
            this.buttonDrill.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.buttonDrill.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonDrill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDrill.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDrill.Location = new System.Drawing.Point(5, 102);
            this.buttonDrill.Name = "buttonDrill";
            this.buttonDrill.Size = new System.Drawing.Size(91, 23);
            this.buttonDrill.TabIndex = 37;
            this.buttonDrill.Text = "Vrtatání děr";
            this.buttonDrill.UseVisualStyleBackColor = false;
            this.buttonDrill.Click += new System.EventHandler(this.buttonDrill_Click);
            // 
            // buttonPrintAndDraw
            // 
            this.buttonPrintAndDraw.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonPrintAndDraw.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonPrintAndDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrintAndDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPrintAndDraw.Location = new System.Drawing.Point(5, 131);
            this.buttonPrintAndDraw.Name = "buttonPrintAndDraw";
            this.buttonPrintAndDraw.Size = new System.Drawing.Size(91, 45);
            this.buttonPrintAndDraw.TabIndex = 39;
            this.buttonPrintAndDraw.Text = "Vytiskout a vyvrtat";
            this.buttonPrintAndDraw.UseVisualStyleBackColor = false;
            this.buttonPrintAndDraw.Click += new System.EventHandler(this.buttonPrintAndDraw_Click);
            // 
            // ButtonEthernet
            // 
            this.ButtonEthernet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(238)))), ((int)(((byte)(253)))));
            this.ButtonEthernet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEthernet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ButtonEthernet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonEthernet.Location = new System.Drawing.Point(19, 18);
            this.ButtonEthernet.Name = "ButtonEthernet";
            this.ButtonEthernet.Size = new System.Drawing.Size(104, 24);
            this.ButtonEthernet.TabIndex = 40;
            this.ButtonEthernet.Text = "Ethernet";
            this.ButtonEthernet.UseVisualStyleBackColor = false;
            this.ButtonEthernet.Click += new System.EventHandler(this.ButtonEthernet_Click);
            // 
            // tabVectors
            // 
            this.tabVectors.BackColor = System.Drawing.SystemColors.Control;
            this.tabVectors.Controls.Add(this.listBoxVectors);
            this.tabVectors.Location = new System.Drawing.Point(4, 24);
            this.tabVectors.Name = "tabVectors";
            this.tabVectors.Padding = new System.Windows.Forms.Padding(3);
            this.tabVectors.Size = new System.Drawing.Size(215, 148);
            this.tabVectors.TabIndex = 2;
            this.tabVectors.Text = "Vektory";
            // 
            // listBoxVectors
            // 
            this.listBoxVectors.FormattingEnabled = true;
            this.listBoxVectors.ItemHeight = 12;
            this.listBoxVectors.Location = new System.Drawing.Point(3, 3);
            this.listBoxVectors.Name = "listBoxVectors";
            this.listBoxVectors.Size = new System.Drawing.Size(211, 136);
            this.listBoxVectors.TabIndex = 25;
            this.listBoxVectors.SelectedIndexChanged += new System.EventHandler(this.listBoxVectors_SelectedIndexChanged_1);
            // 
            // buttonDrawVectors
            // 
            this.buttonDrawVectors.BackColor = System.Drawing.Color.Silver;
            this.buttonDrawVectors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDrawVectors.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDrawVectors.Location = new System.Drawing.Point(9, 18);
            this.buttonDrawVectors.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDrawVectors.Name = "buttonDrawVectors";
            this.buttonDrawVectors.Size = new System.Drawing.Size(217, 22);
            this.buttonDrawVectors.TabIndex = 23;
            this.buttonDrawVectors.Text = "Zobraz všechny vektory";
            this.buttonDrawVectors.UseVisualStyleBackColor = false;
            this.buttonDrawVectors.Click += new System.EventHandler(this.buttonDrawVectors_Click);
            // 
            // tabDrill
            // 
            this.tabDrill.Controls.Add(this.listBoxPointsDrill);
            this.tabDrill.Location = new System.Drawing.Point(4, 24);
            this.tabDrill.Name = "tabDrill";
            this.tabDrill.Padding = new System.Windows.Forms.Padding(3);
            this.tabDrill.Size = new System.Drawing.Size(215, 148);
            this.tabDrill.TabIndex = 1;
            this.tabDrill.Text = "Body vrtání";
            this.tabDrill.UseVisualStyleBackColor = true;
            // 
            // listBoxPointsDrill
            // 
            this.listBoxPointsDrill.FormattingEnabled = true;
            this.listBoxPointsDrill.ItemHeight = 12;
            this.listBoxPointsDrill.Location = new System.Drawing.Point(3, 3);
            this.listBoxPointsDrill.Name = "listBoxPointsDrill";
            this.listBoxPointsDrill.Size = new System.Drawing.Size(211, 136);
            this.listBoxPointsDrill.TabIndex = 34;
            this.listBoxPointsDrill.SelectedIndexChanged += new System.EventHandler(this.listBoxPointsDrill_SelectedIndexChanged);
            // 
            // tabRoutes
            // 
            this.tabRoutes.Controls.Add(this.listBoxPoints);
            this.tabRoutes.Location = new System.Drawing.Point(4, 24);
            this.tabRoutes.Name = "tabRoutes";
            this.tabRoutes.Padding = new System.Windows.Forms.Padding(3);
            this.tabRoutes.Size = new System.Drawing.Size(215, 148);
            this.tabRoutes.TabIndex = 0;
            this.tabRoutes.Text = "Body cest";
            this.tabRoutes.UseVisualStyleBackColor = true;
            // 
            // listBoxPoints
            // 
            this.listBoxPoints.FormattingEnabled = true;
            this.listBoxPoints.ItemHeight = 12;
            this.listBoxPoints.Location = new System.Drawing.Point(3, 3);
            this.listBoxPoints.Name = "listBoxPoints";
            this.listBoxPoints.Size = new System.Drawing.Size(211, 136);
            this.listBoxPoints.TabIndex = 7;
            this.listBoxPoints.SelectedIndexChanged += new System.EventHandler(this.listBoxVectors_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.tabRoutes);
            this.tabControl.Controls.Add(this.tabDrill);
            this.tabControl.Controls.Add(this.tabVectors);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl.Location = new System.Drawing.Point(5, 48);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(223, 176);
            this.tabControl.TabIndex = 38;
            // 
            // GroupPixit
            // 
            this.GroupPixit.Controls.Add(this.ButtonPixtureInfo);
            this.GroupPixit.Controls.Add(this.btnSetttings);
            this.GroupPixit.Controls.Add(this.buttonDebug);
            this.GroupPixit.Controls.Add(this.btnLoad);
            this.GroupPixit.Location = new System.Drawing.Point(10, 7);
            this.GroupPixit.Margin = new System.Windows.Forms.Padding(2);
            this.GroupPixit.Name = "GroupPixit";
            this.GroupPixit.Padding = new System.Windows.Forms.Padding(2);
            this.GroupPixit.Size = new System.Drawing.Size(128, 105);
            this.GroupPixit.TabIndex = 42;
            this.GroupPixit.TabStop = false;
            this.GroupPixit.Text = "PixIt";
            // 
            // ButtonPixtureInfo
            // 
            this.ButtonPixtureInfo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ButtonPixtureInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonPixtureInfo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonPixtureInfo.Location = new System.Drawing.Point(104, 76);
            this.ButtonPixtureInfo.Name = "ButtonPixtureInfo";
            this.ButtonPixtureInfo.Size = new System.Drawing.Size(20, 23);
            this.ButtonPixtureInfo.TabIndex = 46;
            this.ButtonPixtureInfo.Text = "?";
            this.ButtonPixtureInfo.UseVisualStyleBackColor = false;
            this.ButtonPixtureInfo.Click += new System.EventHandler(this.ButtonPixtureInfo_Click);
            // 
            // GroupPrinter
            // 
            this.GroupPrinter.Controls.Add(this.btnManual);
            this.GroupPrinter.Controls.Add(this.buttonPrint);
            this.GroupPrinter.Controls.Add(this.buttonDrill);
            this.GroupPrinter.Controls.Add(this.buttonPrintAndDraw);
            this.GroupPrinter.Location = new System.Drawing.Point(142, 10);
            this.GroupPrinter.Margin = new System.Windows.Forms.Padding(2);
            this.GroupPrinter.Name = "GroupPrinter";
            this.GroupPrinter.Padding = new System.Windows.Forms.Padding(2);
            this.GroupPrinter.Size = new System.Drawing.Size(101, 182);
            this.GroupPrinter.TabIndex = 43;
            this.GroupPrinter.TabStop = false;
            this.GroupPrinter.Text = "Tiskárna";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButtonEthernet);
            this.groupBox1.Controls.Add(this.picEthernet);
            this.groupBox1.Controls.Add(this.btnPort);
            this.groupBox1.Controls.Add(this.picOpenPort);
            this.groupBox1.Location = new System.Drawing.Point(10, 116);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(128, 75);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Připojení";
            // 
            // picEthernet
            // 
            this.picEthernet.BackColor = System.Drawing.Color.Maroon;
            this.picEthernet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picEthernet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEthernet.Location = new System.Drawing.Point(5, 18);
            this.picEthernet.Name = "picEthernet";
            this.picEthernet.Size = new System.Drawing.Size(11, 24);
            this.picEthernet.TabIndex = 41;
            this.picEthernet.TabStop = false;
            // 
            // picOpenPort
            // 
            this.picOpenPort.BackColor = System.Drawing.Color.Maroon;
            this.picOpenPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picOpenPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOpenPort.Location = new System.Drawing.Point(4, 46);
            this.picOpenPort.Name = "picOpenPort";
            this.picOpenPort.Size = new System.Drawing.Size(12, 24);
            this.picOpenPort.TabIndex = 14;
            this.picOpenPort.TabStop = false;
            // 
            // GroupPoints
            // 
            this.GroupPoints.Controls.Add(this.tabControl);
            this.GroupPoints.Controls.Add(this.buttonDrawVectors);
            this.GroupPoints.Location = new System.Drawing.Point(9, 196);
            this.GroupPoints.Margin = new System.Windows.Forms.Padding(2);
            this.GroupPoints.Name = "GroupPoints";
            this.GroupPoints.Padding = new System.Windows.Forms.Padding(2);
            this.GroupPoints.Size = new System.Drawing.Size(235, 229);
            this.GroupPoints.TabIndex = 45;
            this.GroupPoints.TabStop = false;
            this.GroupPoints.Text = "Data Bitmapy";
            // 
            // picOriginal
            // 
            this.picOriginal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.picOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOriginal.Location = new System.Drawing.Point(250, 15);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(376, 411);
            this.picOriginal.TabIndex = 5;
            this.picOriginal.TabStop = false;
            this.picOriginal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picOriginal_MouseClick);
            this.picOriginal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picOriginal_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PixIt_0._3.Properties.Resources.github;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 430);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 25);
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // LinkPixItGitHubRepo
            // 
            this.LinkPixItGitHubRepo.Location = new System.Drawing.Point(23, 429);
            this.LinkPixItGitHubRepo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LinkPixItGitHubRepo.Name = "LinkPixItGitHubRepo";
            this.LinkPixItGitHubRepo.Size = new System.Drawing.Size(91, 26);
            this.LinkPixItGitHubRepo.TabIndex = 50;
            this.LinkPixItGitHubRepo.TabStop = true;
            this.LinkPixItGitHubRepo.Text = "PixIt Repository";
            this.LinkPixItGitHubRepo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LinkPixItGitHubRepo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkGitHubRepo_LinkClicked);
            // 
            // LinkPixItArduinoGitHubRepo
            // 
            this.LinkPixItArduinoGitHubRepo.Location = new System.Drawing.Point(111, 429);
            this.LinkPixItArduinoGitHubRepo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LinkPixItArduinoGitHubRepo.Name = "LinkPixItArduinoGitHubRepo";
            this.LinkPixItArduinoGitHubRepo.Size = new System.Drawing.Size(133, 26);
            this.LinkPixItArduinoGitHubRepo.TabIndex = 51;
            this.LinkPixItArduinoGitHubRepo.TabStop = true;
            this.LinkPixItArduinoGitHubRepo.Text = "PixIt-Arduino Repository";
            this.LinkPixItArduinoGitHubRepo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LinkPixItArduinoGitHubRepo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkPixItArduinoGitHubRepo_LinkClicked);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 455);
            this.Controls.Add(this.LinkPixItArduinoGitHubRepo);
            this.Controls.Add(this.LinkPixItGitHubRepo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.GroupPoints);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupPrinter);
            this.Controls.Add(this.GroupPixit);
            this.Controls.Add(this.picOriginal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "formMain";
            this.Text = "PixIt";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabVectors.ResumeLayout(false);
            this.tabDrill.ResumeLayout(false);
            this.tabRoutes.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.GroupPixit.ResumeLayout(false);
            this.GroupPrinter.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEthernet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpenPort)).EndInit();
            this.GroupPoints.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSetttings;
        private System.Windows.Forms.Button btnPort;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.PictureBox picOpenPort;
        private System.Windows.Forms.OpenFileDialog dialogOpenFile;
        private System.Windows.Forms.Button buttonDebug;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonDrill;
        private System.Windows.Forms.Button buttonPrintAndDraw;
        private System.Windows.Forms.Button ButtonEthernet;
        public System.Windows.Forms.PictureBox picEthernet;
        private System.Windows.Forms.TabPage tabVectors;
        private System.Windows.Forms.TabPage tabDrill;
        private System.Windows.Forms.TabPage tabRoutes;
        public System.Windows.Forms.TabControl tabControl;
        public System.Windows.Forms.ListBox listBoxVectors;
        public System.Windows.Forms.ListBox listBoxPointsDrill;
        public System.Windows.Forms.ListBox listBoxPoints;
        public System.Windows.Forms.Button buttonDrawVectors;
        public System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.GroupBox GroupPixit;
        private System.Windows.Forms.GroupBox GroupPrinter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox GroupPoints;
        private System.Windows.Forms.Button ButtonPixtureInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel LinkPixItGitHubRepo;
        private System.Windows.Forms.LinkLabel LinkPixItArduinoGitHubRepo;
    }
}

