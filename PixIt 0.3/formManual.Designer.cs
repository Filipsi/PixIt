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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonRIGHT
            // 
            this.buttonRIGHT.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRIGHT.Location = new System.Drawing.Point(88, 51);
            this.buttonRIGHT.Name = "buttonRIGHT";
            this.buttonRIGHT.Size = new System.Drawing.Size(34, 38);
            this.buttonRIGHT.TabIndex = 2;
            this.buttonRIGHT.Text = "⇨";
            this.buttonRIGHT.UseVisualStyleBackColor = true;
            // 
            // buttonUP
            // 
            this.buttonUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUP.Location = new System.Drawing.Point(48, 7);
            this.buttonUP.Name = "buttonUP";
            this.buttonUP.Size = new System.Drawing.Size(34, 38);
            this.buttonUP.TabIndex = 3;
            this.buttonUP.Text = "⇧";
            this.buttonUP.UseVisualStyleBackColor = true;
            this.buttonUP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonUP_MouseDown);
            // 
            // buttonDOWN
            // 
            this.buttonDOWN.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDOWN.Location = new System.Drawing.Point(48, 51);
            this.buttonDOWN.Name = "buttonDOWN";
            this.buttonDOWN.Size = new System.Drawing.Size(34, 38);
            this.buttonDOWN.TabIndex = 4;
            this.buttonDOWN.Text = "⇩";
            this.buttonDOWN.UseVisualStyleBackColor = true;
            // 
            // buttonLEFT
            // 
            this.buttonLEFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLEFT.Location = new System.Drawing.Point(8, 51);
            this.buttonLEFT.Name = "buttonLEFT";
            this.buttonLEFT.Size = new System.Drawing.Size(34, 38);
            this.buttonLEFT.TabIndex = 5;
            this.buttonLEFT.Text = "⇦";
            this.buttonLEFT.UseVisualStyleBackColor = true;
            // 
            // checkBoxFastMode
            // 
            this.checkBoxFastMode.AutoSize = true;
            this.checkBoxFastMode.Location = new System.Drawing.Point(133, 7);
            this.checkBoxFastMode.Name = "checkBoxFastMode";
            this.checkBoxFastMode.Size = new System.Drawing.Size(81, 17);
            this.checkBoxFastMode.TabIndex = 6;
            this.checkBoxFastMode.Text = "Rychlý mód";
            this.checkBoxFastMode.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            // 
            // formManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 100);
            this.Controls.Add(this.checkBoxFastMode);
            this.Controls.Add(this.buttonLEFT);
            this.Controls.Add(this.buttonDOWN);
            this.Controls.Add(this.buttonUP);
            this.Controls.Add(this.buttonRIGHT);
            this.Name = "formManual";
            this.Text = "Manuální ovládání";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRIGHT;
        private System.Windows.Forms.Button buttonUP;
        private System.Windows.Forms.Button buttonDOWN;
        private System.Windows.Forms.Button buttonLEFT;
        private System.Windows.Forms.CheckBox checkBoxFastMode;
        private System.Windows.Forms.Timer timer1;
    }
}