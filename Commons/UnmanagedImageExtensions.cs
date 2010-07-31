using System;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging;
using System.Runtime.InteropServices;

namespace Commons
{
    public static class UnmanagedImageExtensions
    {
        public static Color[,] GetImagePixels(this UnmanagedImage unmanagedImage)
        {
            int sourceBytes = unmanagedImage.Width * unmanagedImage.Height * 3;
            var rgbRawValues = new byte[sourceBytes];
            Marshal.Copy(unmanagedImage.ImageData, rgbRawValues, 0, sourceBytes);

            int x = 0, y = -1;
            var result = new Color[unmanagedImage.Width, unmanagedImage.Height];
            for (int i = 0; i < sourceBytes; i = i + 3)
            {
                if (i % unmanagedImage.Width == 0)
                {
                    x = 0;
                    y++;
                }

                result[x, y] = Color.FromArgb(rgbRawValues[i], rgbRawValues[i + 1], rgbRawValues[i + 2]);
            }

            return result;
        }
    }
}
