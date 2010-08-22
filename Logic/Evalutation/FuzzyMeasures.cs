using System;

namespace Logic.Evalutation
{
    public static class FuzzyMeasures
    {
        public static double Fuzz(double[,] membershipValues)
        {
            double result = 0;
            int width = membershipValues.GetLength(0);
            int height = membershipValues.GetLength(1);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    result += Math.Min(membershipValues[i, j], 1 - membershipValues[i, j]);
                }
            }

            return result * 2 / (width * height);
        }
    }
}