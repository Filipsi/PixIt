namespace PixIt_0._3 {
    partial class formImageInfo {
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
            this.LabelPictureName = new System.Windows.Forms.Label();
            this.LabelWidth = new System.Windows.Forms.Label();
            this.LabelHeight = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LabelRoutePoints = new System.Windows.Forms.Label();
            this.LabelDrillPoints = new System.Windows.Forms.Label();
            this.LabelVectorCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelPictureName
            // 
            this.LabelPictureName.AutoSize = true;
            this.LabelPictureName.ForeColor = System.Drawing.Color.White;
            this.LabelPictureName.Location = new System.Drawing.Point(118, 10);
            this.LabelPictureName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelPictureName.Name = "LabelPictureName";
            this.LabelPictureName.Size = new System.Drawing.Size(50, 13);
            this.LabelPictureName.TabIndex = 0;
            this.LabelPictureName.Text = "Obrázek:";
            // 
            // LabelWidth
            // 
            this.LabelWidth.AutoSize = true;
            this.LabelWidth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LabelWidth.Location = new System.Drawing.Point(118, 24);
            this.LabelWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelWidth.Name = "LabelWidth";
            this.LabelWidth.Size = new System.Drawing.Size(37, 13);
            this.LabelWidth.TabIndex = 1;
            this.LabelWidth.Text = "Šířka:";
            // 
            // LabelHeight
            // 
            this.LabelHeight.AutoSize = true;
            this.LabelHeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LabelHeight.Location = new System.Drawing.Point(118, 37);
            this.LabelHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelHeight.Name = "LabelHeight";
            this.LabelHeight.Size = new System.Drawing.Size(39, 13);
            this.LabelHeight.TabIndex = 2;
            this.LabelHeight.Text = "Výška:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PixIt_0._3.Properties.Resources.file_info;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 115);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // LabelRoutePoints
            // 
            this.LabelRoutePoints.AutoSize = true;
            this.LabelRoutePoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LabelRoutePoints.Location = new System.Drawing.Point(118, 106);
            this.LabelRoutePoints.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelRoutePoints.Name = "LabelRoutePoints";
            this.LabelRoutePoints.Size = new System.Drawing.Size(88, 13);
            this.LabelRoutePoints.TabIndex = 4;
            this.LabelRoutePoints.Text = "Počet bodů cest:";
            // 
            // LabelDrillPoints
            // 
            this.LabelDrillPoints.AutoSize = true;
            this.LabelDrillPoints.ForeColor = System.Drawing.Color.White;
            this.LabelDrillPoints.Location = new System.Drawing.Point(118, 89);
            this.LabelDrillPoints.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelDrillPoints.Name = "LabelDrillPoints";
            this.LabelDrillPoints.Size = new System.Drawing.Size(96, 13);
            this.LabelDrillPoints.TabIndex = 5;
            this.LabelDrillPoints.Text = "Počet bodů vrtání:";
            // 
            // LabelVectorCount
            // 
            this.LabelVectorCount.AutoSize = true;
            this.LabelVectorCount.ForeColor = System.Drawing.Color.White;
            this.LabelVectorCount.Location = new System.Drawing.Point(118, 72);
            this.LabelVectorCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelVectorCount.Name = "LabelVectorCount";
            this.LabelVectorCount.Size = new System.Drawing.Size(135, 13);
            this.LabelVectorCount.TabIndex = 6;
            this.LabelVectorCount.Text = "Počet vypočteých vektorů:";
            // 
            // formImageInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(338, 131);
            this.Controls.Add(this.LabelVectorCount);
            this.Controls.Add(this.LabelDrillPoints);
            this.Controls.Add(this.LabelRoutePoints);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LabelHeight);
            this.Controls.Add(this.LabelWidth);
            this.Controls.Add(this.LabelPictureName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "formImageInfo";
            this.Text = "Informace o souboru";
            this.Load += new System.EventHandler(this.formImageInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelPictureName;
        private System.Windows.Forms.Label LabelWidth;
        private System.Windows.Forms.Label LabelHeight;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LabelRoutePoints;
        private System.Windows.Forms.Label LabelDrillPoints;
        private System.Windows.Forms.Label LabelVectorCount;
    }
}