using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Logic;

namespace FuzzyProject
{
    public partial class CustomPictureBox : PictureBox
    {
        public CustomPictureBox()
        {
            InitializeComponent();
            this.histogramStripItem.Click += OnHistogramStripClick;
        }

        private void OnHistogramStripClick(object sender, EventArgs e)
        {
            if (this.Image == null)
            {
                return;
            }

            HistogramData histogram = HistogramData.FromImage(this.Image);
            var histogramWindow = new HistogramWindow();
            histogramWindow.Histogram = histogram;
            histogramWindow.Show();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Right)
            {
               this.contextStrip.Show(this,new Point(e.X,e.Y),ToolStripDropDownDirection.BelowRight);;
            }
        }

        private void OnContextStripOpening(object sender, CancelEventArgs e)
        {
            this.histogramStripItem.Enabled = (this.Image != null);
        }
    }
}
