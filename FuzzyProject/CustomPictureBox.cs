using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
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
            saveImageStripItem.Click += new EventHandler(OnSaveImageStripClick);

        }

        private void OnSaveImageStripClick(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "(*.bmp)|*.bmp|(*.png)|*.png";
                saveFileDialog.AddExtension = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat format = ImageFormat.Bmp;
                    if (saveFileDialog.FilterIndex == 1)
                    {
                       format = ImageFormat.Bmp;
                    }
                    if (saveFileDialog.FilterIndex == 2)
                    {
                        format = ImageFormat.Png;
                    }

                    this.Image.Save(saveFileDialog.FileName, format);
                }
            }
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