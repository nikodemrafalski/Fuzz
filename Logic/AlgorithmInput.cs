using System.Drawing;
using AForge.Imaging;

namespace Logic
{
    public class AlgorithmInput
    {
        public AlgorithmInput(Bitmap bitmap)
        {
            this.Image = UnmanagedImage.FromManagedImage(bitmap);
        }

        public AlgorithmInput(UnmanagedImage image)
        {
            this.Image = image;
        }

        public UnmanagedImage Image { get; private set; }

        public double Measure { get; set; }
    }
}