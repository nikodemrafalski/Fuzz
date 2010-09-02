using System;
using AForge.Imaging;
using Commons;
using Logic.Evalutation;

namespace Logic.Algorithms
{
    public class FuzzyHistogramHiberbolization : AlgorithmBase
    {
        private double beta = 1;

        public FuzzyHistogramHiberbolization()
        {
            AddParameter(new AlgorithmParameter("Beta", 1));
        }

        public override AlgorithmResult ProcessData()
        {
            var stats = new ImageStatistics(Input.Image);
            int minGray = stats.Gray.Min;
            int maxGray = stats.Gray.Max;

            byte[,] pixels = Input.Image.GetPixels();
            double[,] memberships = pixels.ApplyTransform(x => MembershipFunction(x, minGray, maxGray));
            double[,] modifiedMembership = memberships.ApplyTransform(MembershipModification);
            byte[,] newValues = modifiedMembership.ApplyTransform(Defuzzyfication).NarrowToBytes();
            Input.Measure = FuzzyMeasures.Fuzz(memberships);
            return new AlgorithmResult(newValues)
                {
                    Measure = FuzzyMeasures.Fuzz(modifiedMembership)
                };
        }

        private double MembershipFunction(byte grayLevel, int minGrayLevel, int maxGrayLevel)
        {
            return (grayLevel - minGrayLevel)/(double) (maxGrayLevel - minGrayLevel);
        }

        private double MembershipModification(double memberhip)
        {
            return Math.Pow(memberhip, beta);
        }

        private double Defuzzyfication(double modifiedMembership)
        {
            return (255/(Math.Pow(Math.E, -1) - 1))*(Math.Pow(Math.E, -modifiedMembership) - 1);
        }

        protected override void OnParameterChanged(AlgorithmParameter parameter)
        {
            if (parameter.Name.Equals("Beta"))
            {
                beta = parameter.Value;
            }
        }
    }
}