using System.Windows.Forms;
using Logic;

namespace FuzzyProject
{
    public partial class HistogramWindow : Form
    {
        private Statistics histogram;

        public HistogramWindow()
        {
            InitializeComponent();
        }

        public Statistics Histogram
        {
            get { return histogram; }
            set
            {
                histogram = value;
                histogramControl.Values =
                    histogram.ImageStatistics.Blue.Values;

                label1.Text = histogram.ImageStatistics.Blue.Min.ToString();
                label2.Text = histogram.ImageStatistics.Blue.Max.ToString();
                label3.Text = histogram.ImageStatistics.Blue.Mean.ToString();
                label4.Text = histogram.ImageStatistics.Blue.Median.ToString();
            }
        }
    }
}