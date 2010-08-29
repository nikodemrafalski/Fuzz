using System.Drawing;
using AForge.Imaging;

namespace Logic
{
    public class AlgorithmInput
    {
        public AlgorithmInput(Bitmap bitmap)
        {
            Image = UnmanagedImage.FromManagedImage(bitmap);
        }

        public AlgorithmInput(UnmanagedImage image)
        {
            Image = image;
        }

        public UnmanagedImage Image { get; private set; }

        public double Measure { get; set; }
    }
}