using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PixIt_0._3 {

    public partial class formImageInfo : Form {

        private string PictureName;
        private int PixureWidth;
        private int PixureHeight;
        private int RoutePointsCount;
        private int DrillPointsCount;
        private int VectorCount;

        public formImageInfo(string _PictureName, int _PixureWidth, int _PixureHeight, int _RoutePointsCount, int _DrillPointsCount, int _VectorCount) {
            InitializeComponent();
            PictureName = _PictureName;
            PixureWidth = _PixureWidth;
            PixureHeight = _PixureHeight;
            RoutePointsCount = _RoutePointsCount;
            DrillPointsCount = _DrillPointsCount;
            VectorCount = _VectorCount;
        }

        private void formImageInfo_Load(object sender, EventArgs e) {
            LabelPictureName.Text = LabelPictureName.Text + " " + PictureName;
            LabelWidth.Text = LabelWidth.Text + " " + PixureWidth + "px";
            LabelHeight.Text = LabelHeight.Text + " " + PixureHeight + "px";

            LabelRoutePoints.Text = LabelRoutePoints.Text + " " + RoutePointsCount;
            LabelDrillPoints.Text = LabelDrillPoints.Text + " " + DrillPointsCount;
            LabelVectorCount.Text = LabelVectorCount.Text + " " + VectorCount;
        }

    }

}
