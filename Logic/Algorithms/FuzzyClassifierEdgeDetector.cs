using System;
using System.Threading.Tasks;

namespace Logic.Algorithms
{
    using System.Linq;

    internal class FuzzyClassifierEdgeDetector : Algorithm
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
            var result = new byte[this.Input.Image.Width, this.Input.Image.Height];
            Parallel.For(1, pixels.GetLength(0) - 1, i =>
                Parallel.For(1, pixels.GetLength(1) - 1, j =>
                {
                    int[] featureVector = CalculateFeatureVector(i, j, pixels);
                    double edgeMemberhip = EdgedMembership(featureVector);
                    double backgroundMembership = BackgroundMembership(featureVector);
                    if (backgroundMembership >= edgeMemberhip)
                    {
                        result[i, j] = 255;
                    }
                    else
                    {
                        result[i, j] = 0;
                    }
                }));


            Input.Image.SetPixels(result);
            return new AlgorithmResult(Input.Image);
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
            vector[7] = pixels[x - 1, y + 1] - center;

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
                tempVector[i] = (int)Math.Abs(featureVector[i] - h);
            }

            double vec = tempVector.Sum(x => (int)Math.Pow(x, 2));
            return Math.Max(0, 1 - vec / omega);
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
                tempVector[i] = (int)Math.Abs(featureVector[i] - l);
            }

            double vec = tempVector.Sum(x => (int)Math.Pow(x, 2));
            return Math.Max(0, 1 - vec / omega);
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