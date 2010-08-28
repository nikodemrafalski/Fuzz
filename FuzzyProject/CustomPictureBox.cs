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
            foreach (ToolStripItem item in contextStrip.Items)
            {
                item.Enabled = (Image != null);
            }

            if (this.IsSource)
            {
                this.setAsSourceStripItem.Enabled = false;
            }

            histogramStripItem.Click += OnHistogramStripClick;
            setAsSourceStripItem.Click += (s, a) => this.InvokeChangeSourceRequested();
        }

        public bool IsSource { get; set; }

        public event EventHandler ChangeSourceRequested;

        public void InvokeChangeSourceRequested()
        {
            EventHandler handler = ChangeSourceRequested;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void OnHistogramStripClick(object sender, EventArgs e)
        {
            if (Image == null)
            {
                return;
            }

            HistogramData histogram = HistogramData.FromImage(Image);
            var histogramWindow = new HistogramWindow();
            histogramWindow.Histogram = histogram;
            histogramWindow.Show();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Right)
            {
                contextStrip.Show(this, new Point(e.X, e.Y), ToolStripDropDownDirection.BelowRight);
            }
        }

        private void OnContextStripOpening(object sender, CancelEventArgs e)
        {
            foreach (ToolStripItem item in contextStrip.Items)
            {
                item.Enabled = (Image != null);
            }

            if (this.IsSource)
            {
                this.setAsSourceStripItem.Enabled = false;
            }
        }
    }
}