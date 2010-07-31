using System.Drawing;
using AForge.Imaging;

namespace Logic
{
    public class Histogram
    {
        private UnmanagedImage unmanaged;
        public Histogram(Bitmap image)
        {
            unmanaged = UnmanagedImage.FromManagedImage(image);
        }
    }
}