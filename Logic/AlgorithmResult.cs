using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging;

namespace Logic
{
    public class AlgorithmResult
    {
        public AlgorithmResult(UnmanagedImage image)
        {
            Image = image;
        }

        public AlgorithmResult(byte[,] pixels)
        {
            var image = new Bitmap(pixels.GetLength(0), pixels.GetLength(1), PixelFormat.Format8bppIndexed);
            var unmanagedImage = UnmanagedImage.FromManagedImage(image);
            unmanagedImage.SetPixels(pixels);
            this.Image = unmanagedImage;
        }

        public UnmanagedImage Image { get; private set; }

        public double Measure { get; set; }
    }
}