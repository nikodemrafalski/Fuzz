using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Imaging;
using Logic;
using Image = System.Drawing.Image;

namespace FuzzyProject
{
    public partial class HistogramWindow : Form
    {
        private HistogramData histogram;

        public HistogramWindow()
        {
            InitializeComponent();
        }

        public HistogramData Histogram
        {
            get { return histogram; }
            set
            {
                histogram = value;
                this.histogramControl.Values =
                    this.histogram.Statistics.Blue.Values;

                this.label1.Text = this.histogram.Statistics.Blue.Min.ToString();
                this.label2.Text = this.histogram.Statistics.Blue.Max.ToString();
                this.label3.Text = this.histogram.Statistics.Blue.Mean.ToString();
                this.label4.Text = this.histogram.Statistics.Blue.Median.ToString();
            }
        }
    }
}
