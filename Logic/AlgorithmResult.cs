using System.Drawing;
using AForge.Imaging;

namespace Logic
{
    public class AlgorithmResult
    {
        public AlgorithmResult(UnmanagedImage image)
        {
            this.Image = image;
        }

        public UnmanagedImage Image { get; private set; }

        public double Measure { get; set; }
    }
}