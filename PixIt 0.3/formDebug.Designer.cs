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
            this.listBoxSerialPort = new System.Windows.Forms.ListBox();
            this.labelSerialPort = new System.Windows.Forms.Label();
            this.listBoxDebug = new System.Windows.Forms.ListBox();
            this.labelDebug = new System.Windows.Forms.Label();
            this.timerDebugResult = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listBoxSerialPort
            // 
            this.listBoxSerialPort.FormattingEnabled = true;
            this.listBoxSerialPort.Location = new System.Drawing.Point(372, 25);
            this.listBoxSerialPort.Name = "listBoxSerialPort";
            this.listBoxSerialPort.Size = new System.Drawing.Size(133, 251);
            this.listBoxSerialPort.TabIndex = 9;
            // 
            // labelSerialPort
            // 
            this.labelSerialPort.AutoSize = true;
            this.labelSerialPort.Location = new System.Drawing.Point(369, 9);
            this.labelSerialPort.Name = "labelSerialPort";
            this.labelSerialPort.Size = new System.Drawing.Size(120, 13);
            this.labelSerialPort.TabIndex = 14;
            this.labelSerialPort.Text = "Data ze sériového portu";
            // 
            // listBoxDebug
            // 
            this.listBoxDebug.BackColor = System.Drawing.Color.Black;
            this.listBoxDebug.ForeColor = System.Drawing.Color.White;
            this.listBoxDebug.FormattingEnabled = true;
            this.listBoxDebug.Location = new System.Drawing.Point(13, 26);
            this.listBoxDebug.Name = "listBoxDebug";
            this.listBoxDebug.Size = new System.Drawing.Size(353, 251);
            this.listBoxDebug.TabIndex = 15;
            // 
            // labelDebug
            // 
            this.labelDebug.AutoSize = true;
            this.labelDebug.Location = new System.Drawing.Point(12, 10);
            this.labelDebug.Name = "labelDebug";
            this.labelDebug.Size = new System.Drawing.Size(39, 13);
            this.labelDebug.TabIndex = 16;
            this.labelDebug.Text = "Debug";
            // 
            // timerDebugResult
            // 
            this.timerDebugResult.Interval = 1000;
            this.timerDebugResult.Tick += new System.EventHandler(this.timerDebugResult_Tick);
            // 
            // formDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 283);
            this.Controls.Add(this.labelDebug);
            this.Controls.Add(this.listBoxDebug);
            this.Controls.Add(this.labelSerialPort);
            this.Controls.Add(this.listBoxSerialPort);
            this.Name = "formDebug";
            this.Text = "Debug okno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSerialPort;
        private System.Windows.Forms.Label labelDebug;
        public System.Windows.Forms.ListBox listBoxSerialPort;
        public System.Windows.Forms.ListBox listBoxDebug;
        public System.Windows.Forms.Timer timerDebugResult;
    }
}