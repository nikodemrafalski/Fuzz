using System.Windows.Forms;
using Logic;

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
                histogramControl.Values =
                    histogram.Statistics.Blue.Values;

                label1.Text = histogram.Statistics.Blue.Min.ToString();
                label2.Text = histogram.Statistics.Blue.Max.ToString();
                label3.Text = histogram.Statistics.Blue.Mean.ToString();
                label4.Text = histogram.Statistics.Blue.Median.ToString();
            }
        }
    }
}