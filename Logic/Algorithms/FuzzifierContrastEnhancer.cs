using System;
using System.Linq;
using AForge.Imaging;

namespace Logic.Algorithms
{
    internal class FuzzifierContrastEnhancer : Algorithm
    {
        private const double exponentialFuzzifier = 1;
        private const double denominationalFuzzifier = 1;

        private int maxGraylevel;
        private double[,] membershipValues;
        private readonly int width;
        private readonly int height;


        public FuzzifierContrastEnhancer(UnmanagedImage imageToProcess)
            : base(imageToProcess)
        {
            this.width = imageToProcess.Width;
            this.height = imageToProcess.Height;
            this.membershipValues = new double[width, height];
          
        }

        public override AlgorithmResult ProcessData()
        {
            throw new System.NotImplementedException();
        }

        private double MembershipFunction(int grayLevel)
        {
            return
                1d /
                Math.Pow(
                    1 + (this.maxGraylevel - grayLevel) / denominationalFuzzifier,
                    -exponentialFuzzifier);
        }
    }
}