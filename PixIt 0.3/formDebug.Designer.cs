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
            this.listBoxDebug = new System.Windows.Forms.ListBox();
            this.labelDebug = new System.Windows.Forms.Label();
            this.TextBoxCommandLine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxDebug
            // 
            this.listBoxDebug.BackColor = System.Drawing.Color.Black;
            this.listBoxDebug.ForeColor = System.Drawing.Color.White;
            this.listBoxDebug.FormattingEnabled = true;
            this.listBoxDebug.ItemHeight = 16;
            this.listBoxDebug.Location = new System.Drawing.Point(20, 32);
            this.listBoxDebug.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxDebug.Name = "listBoxDebug";
            this.listBoxDebug.Size = new System.Drawing.Size(652, 308);
            this.listBoxDebug.TabIndex = 15;
            // 
            // labelDebug
            // 
            this.labelDebug.AutoSize = true;
            this.labelDebug.Location = new System.Drawing.Point(18, 11);
            this.labelDebug.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDebug.Name = "labelDebug";
            this.labelDebug.Size = new System.Drawing.Size(50, 17);
            this.labelDebug.TabIndex = 16;
            this.labelDebug.Text = "Debug";
            // 
            // TextBoxCommandLine
            // 
            this.TextBoxCommandLine.Location = new System.Drawing.Point(21, 364);
            this.TextBoxCommandLine.Name = "TextBoxCommandLine";
            this.TextBoxCommandLine.Size = new System.Drawing.Size(651, 22);
            this.TextBoxCommandLine.TabIndex = 17;
            this.TextBoxCommandLine.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBoxCommandLine_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 344);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Příkazová řádka";
            // 
            // formDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 401);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxCommandLine);
            this.Controls.Add(this.labelDebug);
            this.Controls.Add(this.listBoxDebug);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formDebug";
            this.Text = "Debug okno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDebug;
        public System.Windows.Forms.ListBox listBoxDebug;
        private System.Windows.Forms.TextBox TextBoxCommandLine;
        private System.Windows.Forms.Label label1;
    }
}