using System.Drawing;
using System.Threading.Tasks;
using AForge.Imaging;

namespace Logic
{
    public class HistogramData
    {
        private HistogramData()
        {
        }

        public ImageStatistics Statistics
        {
            get;
            private set;
        }

        public static HistogramData FromUnmanagedImage(UnmanagedImage image)
        {
            var histogram = new HistogramData();
            histogram.Statistics = new ImageStatistics(image);
            return histogram;
        }

        public static HistogramData FromImage(System.Drawing.Image image)
        {
            return FromUnmanagedImage(
                UnmanagedImage.FromManagedImage(
                new Bitmap(image)));
        }
    }
}