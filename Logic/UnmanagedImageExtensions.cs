using System;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging;
using System.Runtime.InteropServices;

namespace Logic
{
    public static class UnmanagedImageExtensions
    {
        public static byte[,] GetPixels(this UnmanagedImage unmanagedImage)
        {
            int sourceBytes = unmanagedImage.Width * unmanagedImage.Height;
            var rgbRawValues = new byte[sourceBytes];
            Marshal.Copy(unmanagedImage.ImageData, rgbRawValues, 0, sourceBytes);

            int x = 0, y = -1;
            var result = new byte[unmanagedImage.Width, unmanagedImage.Height];
            for (int i = 0; i < sourceBytes; i++)
            {
                if (x % unmanagedImage.Width == 0)
                {
                    x = 0;
                    y++;
                }

                result[x, y] = rgbRawValues[i];
                x++;
            }

            return result;
        }

        public static void SetPixels(this UnmanagedImage unmanagedImage, byte[,] pixels)
        {
            int bytesCount = unmanagedImage.Width * unmanagedImage.Height;
            byte[] imageBytes = new byte[bytesCount];
            int offset = 0;
            for (int y = 0; y < pixels.GetLength(1); y++)
            {
                for (int x = 0; x < pixels.GetLength(0); x++)
                {
                    imageBytes[offset] = pixels[x, y];
                    offset++;
                }
            }

            Marshal.Copy(imageBytes, 0, unmanagedImage.ImageData, bytesCount);
        }
    }
}
