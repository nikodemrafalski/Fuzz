using AForge.Imaging;

namespace Logic
{
    public class AlgorithmResult
    {
        public AlgorithmResult(UnmanagedImage image)
        {
            Image = image;
        }

        public UnmanagedImage Image { get; private set; }

        public double Measure { get; set; }
    }
}