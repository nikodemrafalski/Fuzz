using System;

namespace Logic.Algorithms
{
    internal class FuzzifierContrastEnhancer : Algorithm
    {
        private const double exponentialFuzzifier = 1;
        private const double denominationalFuzzifier = 1;
        private readonly int height;
        private readonly int width;

        private int maxGraylevel;
        private double[,] membershipValues;


        public override AlgorithmResult ProcessData()
        {
            throw new NotImplementedException();
        }

        private double MembershipFunction(int grayLevel)
        {
            return
                1d/
                Math.Pow(
                    1 + (maxGraylevel - grayLevel)/denominationalFuzzifier,
                    -exponentialFuzzifier);
        }
    }
}