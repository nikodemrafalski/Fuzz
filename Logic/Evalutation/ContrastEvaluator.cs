using System;
using AForge.Imaging;
using Commons;

namespace Logic.Evalutation
{
    public static class ContrastEvaluator
    {
        public static double Evaluate(UnmanagedImage image)
        {
            byte[,] pixels = image.GetPixels();
            Tuple<byte, byte> minMax = pixels.GetMinAndMaxValues();
            byte minGrayLevel = minMax.Item1;
            byte maxGrayLevel = minMax.Item2;
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
    }
}