using System.Drawing.Drawing2D;
using AForge.Imaging.Filters;

namespace Commons
{
    using System;
    using System.Drawing;

    public static class ImageHelpers
    {
        public static Bitmap ConvertToGrayScale(this Bitmap sourceImage)
        {
            var filter = new Grayscale(0.2125, 0.7154, 0.0721);
            if (AForge.Imaging.Image.IsGrayscale(sourceImage))
            {
                return sourceImage;
            }

            Bitmap converted = filter.Apply(sourceImage);
            return converted;
        }

        public static Bitmap ResizeImage(this Bitmap originalImage, int newWidth, int newHeight)
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

            if (originalImage.Width <= calculatedWidth || originalImage.Height <= calculatedHeight)
            {
                calculatedHeight = originalImage.Height;
                calculatedWidth = originalImage.Width;
            }

            var resizeFilter = new ResizeBicubic(calculatedWidth, calculatedHeight);
            Bitmap result = resizeFilter.Apply(originalImage);
            return result;
        }
    }
}

