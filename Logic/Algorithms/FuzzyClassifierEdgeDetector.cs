using System;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.Algorithms
{
    internal class FuzzyClassifierEdgeDetector : AlgorithmBase
    {
        private double h = 15;
        private double l = 6;
        private double omega = 80000;

        public FuzzyClassifierEdgeDetector()
        {
            AddParameter(new AlgorithmParameter("L", 6));
            AddParameter(new AlgorithmParameter("H", 15));
            AddParameter(new AlgorithmParameter("Omega", 80000));
        }

        public override AlgorithmResult ProcessData()
        {
            byte[,] pixels = Input.Image.GetPixels();
            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);
            var result = new byte[Input.Image.Width,Input.Image.Height];
            Parallel.For(1, width - 1, i =>
                                       Parallel.For(1, height - 1, j =>
                                           {
                                               int[] featureVector =
                                                   CalculateFeatureVector(i, j, pixels);
                                               double edgeMemberhip =
                                                   EdgedMembership(featureVector);
                                               double backgroundMembership =
                                                   BackgroundMembership(featureVector);
                                               if (backgroundMembership >= edgeMemberhip)
                                               {
                                                   result[i, j] = 255;
                                               }
                                               else
                                               {
                                                   result[i, j] = 0;
                                               }
                                           }));

            for (int i = 0; i < width; i++)
            {
                result[i, 0] = 255;
                result[i, height - 1] = 255;
            }

            for (int i = 0; i < height; i++)
            {
                result[0, i] = 255;
                result[width - 1, i] = 255;
            }

            return new AlgorithmResult(result);
        }

        private int[] CalculateFeatureVector(int x, int y, byte[,] pixels)
        {
            var vector = new int[8];
            int center = pixels[x, y];
            vector[0] = pixels[x - 1, y - 1] - center;
            vector[1] = pixels[x, y - 1] - center;
            vector[2] = pixels[x + 1, y - 1] - center;
            vector[3] = pixels[x - 1, y] - center;
            vector[4] = pixels[x + 1, y] - center;
            vector[5] = pixels[x - 1, y + 1] - center;
            vector[6] = pixels[x, y + 1] - center;
            vector[7] = pixels[x + 1, y + 1] - center;

            return vector;
        }

        private double EdgedMembership(int[] featureVector)
        {
            if (featureVector[0] >= h && featureVector[1] >= h && featureVector[2] >= h &&
                featureVector[3] >= h && featureVector[4] >= h && featureVector[5] >= h &&
                featureVector[6] >= h && featureVector[7] >= h)
            {
                return 1;
            }

            var tempVector = new int[8];
            for (int i = 0; i < 8; i++)
            {
                featureVector[i] = Math.Abs(featureVector[i]);
                tempVector[i] = (int) Math.Abs(featureVector[i] - h);
            }

            double vec = tempVector.Sum(x => (int) Math.Pow(x, 2));
            return Math.Max(0, 1 - vec/omega);
        }

        private double BackgroundMembership(int[] featureVector)
        {
            if (featureVector[0] <= l && featureVector[1] <= l && featureVector[2] <= l &&
                featureVector[3] <= l && featureVector[4] <= l && featureVector[5] <= l &&
                featureVector[6] <= l && featureVector[7] <= l)
            {
                return 1;
            }

            var tempVector = new int[8];
            for (int i = 0; i < 8; i++)
            {
                featureVector[i] = Math.Abs(featureVector[i]);
                tempVector[i] = (int) Math.Abs(featureVector[i] - l);
            }

            double vec = tempVector.Sum(x => (int) Math.Pow(x, 2));
            return Math.Max(0, 1 - vec/omega);
        }

        protected override void OnParameterChanged(AlgorithmParameter parameter)
        {
            if (parameter.Name.Equals("L"))
            {
                l = parameter.Value;
            }
            else if (parameter.Name.Equals("H"))
            {
                h = parameter.Value;
            }
            else if (parameter.Name.Equals("Omega"))
            {
                omega = parameter.Value;
            }
        }
    }
}