using System.Drawing;
using AForge.Imaging;
using Image = System.Drawing.Image;

namespace Logic
{
    public class HistogramData
    {
        private HistogramData()
        {
        }

        public ImageStatistics Statistics { get; private set; }

        public static HistogramData FromUnmanagedImage(UnmanagedImage image)
        {
            var histogram = new HistogramData();
            histogram.Statistics = new ImageStatistics(image);
            return histogram;
        }

        public static HistogramData FromImage(Image image)
        {
            return FromUnmanagedImage(
                UnmanagedImage.FromManagedImage(
                    new Bitmap(image)));
        }
    }
}