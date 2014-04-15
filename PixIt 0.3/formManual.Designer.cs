namespace PixIt_0._3
{
    partial class formManual
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
            this.buttonRIGHT = new System.Windows.Forms.Button();
            this.buttonUP = new System.Windows.Forms.Button();
            this.buttonDOWN = new System.Windows.Forms.Button();
            this.buttonLEFT = new System.Windows.Forms.Button();
            this.checkBoxFastMode = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRIGHT
            // 
            this.buttonRIGHT.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRIGHT.Location = new System.Drawing.Point(117, 63);
            this.buttonRIGHT.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRIGHT.Name = "buttonRIGHT";
            this.buttonRIGHT.Size = new System.Drawing.Size(45, 47);
            this.buttonRIGHT.TabIndex = 2;
            this.buttonRIGHT.Text = "⇨";
            this.buttonRIGHT.UseVisualStyleBackColor = true;
            // 
            // buttonUP
            // 
            this.buttonUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUP.Location = new System.Drawing.Point(64, 9);
            this.buttonUP.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUP.Name = "buttonUP";
            this.buttonUP.Size = new System.Drawing.Size(45, 47);
            this.buttonUP.TabIndex = 3;
            this.buttonUP.Text = "⇧";
            this.buttonUP.UseVisualStyleBackColor = true;
            this.buttonUP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonUP_MouseDown);
            // 
            // buttonDOWN
            // 
            this.buttonDOWN.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDOWN.Location = new System.Drawing.Point(64, 63);
            this.buttonDOWN.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDOWN.Name = "buttonDOWN";
            this.buttonDOWN.Size = new System.Drawing.Size(45, 47);
            this.buttonDOWN.TabIndex = 4;
            this.buttonDOWN.Text = "⇩";
            this.buttonDOWN.UseVisualStyleBackColor = true;
            // 
            // buttonLEFT
            // 
            this.buttonLEFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLEFT.Location = new System.Drawing.Point(11, 63);
            this.buttonLEFT.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLEFT.Name = "buttonLEFT";
            this.buttonLEFT.Size = new System.Drawing.Size(45, 47);
            this.buttonLEFT.TabIndex = 5;
            this.buttonLEFT.Text = "⇦";
            this.buttonLEFT.UseVisualStyleBackColor = true;
            // 
            // checkBoxFastMode
            // 
            this.checkBoxFastMode.AutoSize = true;
            this.checkBoxFastMode.Location = new System.Drawing.Point(177, 9);
            this.checkBoxFastMode.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxFastMode.Name = "checkBoxFastMode";
            this.checkBoxFastMode.Size = new System.Drawing.Size(103, 21);
            this.checkBoxFastMode.TabIndex = 6;
            this.checkBoxFastMode.Text = "Rychlý mód";
            this.checkBoxFastMode.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(195, 142);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(91, 22);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 172);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(294, 142);
            this.numericUpDown3.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(91, 22);
            this.numericUpDown3.TabIndex = 11;
            // 
            // formManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 297);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.checkBoxFastMode);
            this.Controls.Add(this.buttonLEFT);
            this.Controls.Add(this.buttonDOWN);
            this.Controls.Add(this.buttonUP);
            this.Controls.Add(this.buttonRIGHT);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formManual";
            this.Text = "Manuální ovládání";
            this.Load += new System.EventHandler(this.formManual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRIGHT;
        private System.Windows.Forms.Button buttonUP;
        private System.Windows.Forms.Button buttonDOWN;
        private System.Windows.Forms.Button buttonLEFT;
        private System.Windows.Forms.CheckBox checkBoxFastMode;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
    }
}