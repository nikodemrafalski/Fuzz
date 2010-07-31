using System.Drawing.Drawing2D;

namespace Commons
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public static class ImageHelpers
    {
        public static Bitmap ConvertToGrayScale(this Image sourceImage)
        {
            var result = new Bitmap(sourceImage.Width, sourceImage.Height);

            Graphics g = Graphics.FromImage(result);

            var colorMatrix = new ColorMatrix(new[]
            {
                new[] {.3f, .3f, .3f, 0f, 0f},
                new[] {.59f, .59f, .59f, 0f, 0f},
                new[] {.11f, .11f, .11f, 0f, 0f},
                new[] {0f, 0f, 0f, 1f, 0f},
                new[] {0f, 0f, 0f, 0f, 1f}
            });

            var attributes = new ImageAttributes();

            attributes.SetColorMatrix(colorMatrix);

            g.DrawImage(sourceImage, new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
               0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel, attributes);

            g.Dispose();
            return result;
        }

        public static Bitmap ResizeImage(this Image originalImage, int newWidth, int newHeight)
        {
            double aspectRatio;
            int calculatedWidth, calculatedHeight;

            if (originalImage.Width > originalImage.Height)
            {
                calculatedWidth = newWidth;
                aspectRatio = (float)newWidth / originalImage.Width;
                calculatedHeight = Convert.ToInt32(originalImage.Height * aspectRatio);
            }
            else
            {
                calculatedHeight = newHeight;
                aspectRatio = (float)newHeight / originalImage.Height;
                calculatedWidth = Convert.ToInt32(originalImage.Width * aspectRatio);
            }

            var result = new Bitmap(calculatedWidth, calculatedHeight, originalImage.PixelFormat);
            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(originalImage, 0, 0, calculatedWidth, calculatedHeight);
            }

            return result;
        }
    }
}

