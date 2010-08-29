using System;
using System.Threading.Tasks;
using AForge.Imaging;
using Commons;
using Logic.Evalutation;

namespace Logic.Algorithms
{
    public class LocallyAdaptiveFuzzyHistogramHiberbolization : Algorithm
    {
        private double beta = 1;
        private int windowSize = 30;
        private Tuple<byte, byte>[,] localValues;

        public LocallyAdaptiveFuzzyHistogramHiberbolization()
        {
            this.AddParameter(new AlgorithmParameter("Beta", 1));
            this.AddParameter(new AlgorithmParameter("WindowSize", 30));
        }

        public override AlgorithmResult ProcessData()
        {
            byte[,] pixels = this.Input.Image.GetPixels();
            this.CalculateLocalValues(pixels);
            var memberships = new double[pixels.GetLength(0), pixels.GetLength(1)];
            Parallel.For(0, pixels.GetLength(0), i =>
                Parallel.For(0, pixels.GetLength(1), j =>
                    {
                        Tuple<byte, byte> minMax = this.localValues[i, j];
                        memberships[i, j] = this.MembershipFunction(pixels[i, j], minMax.Item1, minMax.Item2);
                    }
            ));

            double[,] modifiedMembership = memberships.ApplyTransform(MembershipModification);
            byte[,] newValues = modifiedMembership.ApplyTransform(Defuzzyfication).NarrowToBytes();
            this.Input.Image.SetPixels(newValues);
            this.Input.Measure = FuzzyMeasures.Fuzz(memberships);
            return new AlgorithmResult(this.Input.Image)
            {
                Measure = FuzzyMeasures.Fuzz(modifiedMembership)
            };
        }

        private void CalculateLocalValues(byte[,] pixels)
        {
            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);
            localValues = new Tuple<byte, byte>[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    this.localValues[i, j] =
                        this.MinMax(this.GetWindowPixels(pixels, i, j, windowSize, width, height));
                }
            }
        }

        private double MembershipFunction(byte grayLevel, int minGrayLevel, int maxGrayLevel)
        {
            return (double)(grayLevel - minGrayLevel) / (double)(maxGrayLevel - minGrayLevel);
        }

        private double MembershipModification(double memberhip)
        {
            return Math.Pow(memberhip, this.beta);
        }

        private double Defuzzyfication(double modifiedMembership)
        {
            return (255 / (Math.Pow(Math.E, -1) - 1)) * (Math.Pow(Math.E, -modifiedMembership) - 1);
        }

        protected override void OnParameterChanged(AlgorithmParameter parameter)
        {
            if (parameter.Name.Equals("Beta"))
            {
                this.beta = parameter.Value;
            }

            if (parameter.Name.Equals("WindowSize"))
            {
                this.windowSize = (int)parameter.Value;
            }
        }

        private byte[] GetWindowPixels(byte[,] pixels, int x, int y, int window, int width, int height)
        {
            if (window % 2 == 0) window--;
            int offset = window / 2;
            int left = x - offset;
            int right = x + offset;
            int up = y - offset;
            int down = y + offset;
            if (left < 0)
            {
                int pad = -left;
                left += pad;
                right += pad;
            }
            if (up < 0)
            {
                int pad = -up;
                up += pad;
                down += pad;
            }
            if (right >= width)
            {
                int pad = right - width + 1;
                left -= pad;
                right -= pad;
            }
            if (down >= height)
            {
                int pad = down - height + 1;
                up -= pad;
                down -= pad;
            }

            var result = new byte[window * window];
            int num = 0;
            for (int i = left; i <= right; i++)
            {
                for (int j = up; j <= down; j++)
                {
                    result[num] = pixels[i, j];
                    num++;
                }
            }

            return result;
        }

        private Tuple<byte, byte> MinMax(byte[] x)
        {
            byte min = 255, max = 0;
            byte current;
            for (int i = 0; i < x.GetLength(0); i++)
            {
                current = x[i];
                if (current > max)
                {
                    max = current;
                }

                if (current < min)
                {
                    min = current;
                }
            }

            return new Tuple<byte, byte>(min, max);
        }
    }
}