namespace PixIt_2._0
{
    partial class ManualControl
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
            this.buttonXp = new System.Windows.Forms.Button();
            this.buttonXm = new System.Windows.Forms.Button();
            this.buttonYp = new System.Windows.Forms.Button();
            this.buttonYm = new System.Windows.Forms.Button();
            this.checkBox_QuickMode = new System.Windows.Forms.CheckBox();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonXp
            // 
            this.buttonXp.Location = new System.Drawing.Point(95, 106);
            this.buttonXp.Name = "buttonXp";
            this.buttonXp.Size = new System.Drawing.Size(42, 23);
            this.buttonXp.TabIndex = 0;
            this.buttonXp.Text = "<";
            this.buttonXp.UseVisualStyleBackColor = true;
            // 
            // buttonXm
            // 
            this.buttonXm.Location = new System.Drawing.Point(143, 106);
            this.buttonXm.Name = "buttonXm";
            this.buttonXm.Size = new System.Drawing.Size(42, 23);
            this.buttonXm.TabIndex = 1;
            this.buttonXm.Text = ">";
            this.buttonXm.UseVisualStyleBackColor = true;
            // 
            // buttonYp
            // 
            this.buttonYp.Location = new System.Drawing.Point(95, 135);
            this.buttonYp.Name = "buttonYp";
            this.buttonYp.Size = new System.Drawing.Size(90, 23);
            this.buttonYp.TabIndex = 2;
            this.buttonYp.Text = "\\/";
            this.buttonYp.UseVisualStyleBackColor = true;
            // 
            // buttonYm
            // 
            this.buttonYm.Location = new System.Drawing.Point(95, 77);
            this.buttonYm.Name = "buttonYm";
            this.buttonYm.Size = new System.Drawing.Size(90, 23);
            this.buttonYm.TabIndex = 3;
            this.buttonYm.Text = "/\\";
            this.buttonYm.UseVisualStyleBackColor = true;
            this.buttonYm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonYm_MouseDown);
            // 
            // checkBox_QuickMode
            // 
            this.checkBox_QuickMode.AutoSize = true;
            this.checkBox_QuickMode.Location = new System.Drawing.Point(119, 192);
            this.checkBox_QuickMode.Name = "checkBox_QuickMode";
            this.checkBox_QuickMode.Size = new System.Drawing.Size(103, 21);
            this.checkBox_QuickMode.TabIndex = 4;
            this.checkBox_QuickMode.Text = "Rychlý mod";
            this.checkBox_QuickMode.UseVisualStyleBackColor = true;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(299, 121);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(78, 22);
            this.numericUpDown.TabIndex = 5;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ManualControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 255);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.checkBox_QuickMode);
            this.Controls.Add(this.buttonYm);
            this.Controls.Add(this.buttonYp);
            this.Controls.Add(this.buttonXm);
            this.Controls.Add(this.buttonXp);
            this.Name = "ManualControl";
            this.ShowIcon = false;
            this.Text = "ManualControl";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonXp;
        private System.Windows.Forms.Button buttonXm;
        private System.Windows.Forms.Button buttonYp;
        private System.Windows.Forms.Button buttonYm;
        private System.Windows.Forms.CheckBox checkBox_QuickMode;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}