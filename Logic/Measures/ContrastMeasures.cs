using System;
using AForge.Imaging;

namespace Logic.Evalutation
{
    public static class ContrastMeasures
    {
        public static double EvaluateM(UnmanagedImage image)
        {
            byte[,] pixels = image.GetPixels();
            var stats = new ImageStatistics(image);
            var minGrayLevel = (byte)stats.Gray.Min;
            var maxGrayLevel = (byte)stats.Gray.Max;
            return (double)(maxGrayLevel - minGrayLevel) / (double)(maxGrayLevel + minGrayLevel);
        }

        public static double EvaluateS(UnmanagedImage image)
        {
            byte[,] pixels = image.GetPixels();
            var stats = new ImageStatistics(image);
            var minGrayLevel = (byte)stats.Gray.Min;
            var maxGrayLevel = (byte)stats.Gray.Max;
            double aggregate = 0;

            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    aggregate += pixels[i, j];
                }
            }

            aggregate = Math.Pow(width * height, -1) * aggregate;
            return (maxGrayLevel - minGrayLevel) / aggregate;
        }

        public static double EvaluateW(UnmanagedImage image)
        {
            byte[,] pixels = image.GetPixels();
            double aggregate = 0;

            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    aggregate += pixels[i, j];
                }
            }

            aggregate = Math.Pow(width * height, -1) * aggregate;

            double aggregate2 = 0;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    aggregate2 += Math.Pow((pixels[i, j] - aggregate), 2);
                }
            }


            return (4D / (width * height * Math.Pow(255, 2))) * aggregate2;
        }

        public static double EvaluateLocallyW(UnmanagedImage image)
        {
            byte[,] pixels = image.GetPixels();

            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);

            double aggregate = 0;

            for (int i = 0; i < width - 1; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    aggregate += Math.Pow((pixels[i, j] - pixels[i + 1, j]), 2);
                }
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height - 1; j++)
                {
                    aggregate += Math.Pow((pixels[i, j] - pixels[i, j + 1]), 2);
                }
            }

            for (int i = 0; i < width - 1; i++)
            {
                for (int j = 0; j < height - 1; j++)
                {
                    aggregate += Math.Pow((pixels[i, j] - pixels[i + 1, j + 1]), 2);
                }
            }

            for (int i = 0; i < width - 1; i++)
            {
                for (int j = 1; j < height; j++)
                {
                    aggregate += Math.Pow((pixels[i, j] - pixels[i + 1, j - 1]), 2);
                }
            }

            return (1D / (width * height * Math.Pow(255, 2))) * aggregate;
        }

        public static double EvaluateLocallyWAbs(UnmanagedImage image)
        {
            byte[,] pixels = image.GetPixels();

            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);

            double aggregate = 0;

            for (int i = 0; i < width - 1; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    aggregate += Math.Abs((pixels[i, j] - pixels[i + 1, j]));
                }
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height - 1; j++)
                {
                    aggregate += Math.Abs((pixels[i, j] - pixels[i, j + 1]));
                }
            }

            for (int i = 0; i < width - 1; i++)
            {
                for (int j = 0; j < height - 1; j++)
                {
                    aggregate += Math.Abs((pixels[i, j] - pixels[i + 1, j + 1]));
                }
            }

            for (int i = 0; i < width - 1; i++)
            {
                for (int j = 1; j < height; j++)
                {
                    aggregate += Math.Abs((pixels[i, j] - pixels[i + 1, j - 1]));
                }
            }

            return (1D / (width * height * Math.Pow(255, 2))) * aggregate;
        }

        public static double EvaluateWAbs(UnmanagedImage image)
        {
            byte[,] pixels = image.GetPixels();
            double aggregate = 0;

            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    aggregate += pixels[i, j];
                }
            }

            aggregate = Math.Pow(width * height, -1) * aggregate;

            double aggregate2 = 0;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    aggregate2 += Math.Abs((pixels[i, j] - aggregate));
                }
            }


            return (4D / (width * height * Math.Pow(255, 2))) * aggregate2;
        }
    }
}