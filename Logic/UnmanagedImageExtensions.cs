using AForge.Imaging;

namespace Logic
{
    public static class UnmanagedImageExtensions
    {
        public static byte[,] GetPixels(this UnmanagedImage unmanagedImage)
        {
            var pixelValues = new byte[unmanagedImage.Width,unmanagedImage.Height];
            unsafe
            {
                var basePtr = (byte*) unmanagedImage.ImageData.ToPointer();
                byte* ptr;

                int i = 0;
                for (int x = 0; x < unmanagedImage.Width; x++)
                {
                    for (int y = 0; y < unmanagedImage.Height; y++)
                    {
                        ptr = basePtr + unmanagedImage.Stride*y + x;
                        pixelValues[x, y] = *ptr;
                    }
                }
            }

            return pixelValues;
        }

        public static void SetPixels(this UnmanagedImage unmanagedImage, byte[,] pixels)
        {
            int bytesCount = unmanagedImage.Stride*unmanagedImage.Height;
            unsafe
            {
                var basePtr = (byte*) unmanagedImage.ImageData.ToPointer();
                byte* ptr;

                int i = 0;
                for (int x = 0; x < unmanagedImage.Width; x++)
                {
                    for (int y = 0; y < unmanagedImage.Height; y++)
                    {
                        ptr = basePtr + unmanagedImage.Stride*y + x;
                        *ptr = pixels[x, y];
                    }
                }
            }
        }
    }
}