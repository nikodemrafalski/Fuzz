using System.Drawing;
using AForge.Imaging;
using Logic.Evalutation;
using Image = System.Drawing.Image;

namespace Logic
{
    public class Statistics
    {
        private UnmanagedImage image;
        private Statistics()
        {
        }

        public ImageStatistics ImageStatistics { get; private set; }

        public static Statistics FromUnmanagedImage(UnmanagedImage image)
        {
            var histogram = new Statistics();
            histogram.image = image;
            histogram.ImageStatistics = new ImageStatistics(image);
            return histogram;
        }

        public double GetContrastMeasure()
        {
            return ContrastMeasures.EvaluateW(this.image);
        }

        public static Statistics FromImage(Image image)
        {
            return FromUnmanagedImage(
                UnmanagedImage.FromManagedImage(
                    new Bitmap(image)));
        }
    }
}