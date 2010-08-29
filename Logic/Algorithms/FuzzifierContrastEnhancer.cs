using System;
using AForge.Imaging;
using Commons;
using Logic.Evalutation;

namespace Logic.Algorithms
{
    internal class FuzzifierContrastEnhancer : Algorithm
    {
        private int crossoverPoint = -1;
        private double denominationalFuzzifier;
        private double desiredFuzziness;
        private double exponentialFuzzifier = 1;
        private int iterations = 1;
        private double maxGrayLevel;

        public FuzzifierContrastEnhancer()
        {
            AddParameter(new AlgorithmParameter("ExponentialFuzzifier", 1));
            AddParameter(new AlgorithmParameter("Crossover", -1));
            AddParameter(new AlgorithmParameter("Iterations", 1));
            AddParameter(new AlgorithmParameter("DesiredFuzziness", -1));
        }

        public override AlgorithmResult ProcessData()
        {
            byte[,] pixels = Input.Image.GetPixels();
            double[,] membershipValues = Fuzzify(pixels);
            Input.Measure = FuzzyMeasures.Fuzz(membershipValues);
            double[,] modifiedMembershipValues = membershipValues;
            if (desiredFuzziness != 0)
            {
                iterations = 200;
            }

            for (int i = 0; i < iterations; i++)
            {
                modifiedMembershipValues = modifiedMembershipValues.ApplyTransform(IntOperator);
                if (desiredFuzziness != -1)
                {
                    double measure = FuzzyMeasures.Fuzz(modifiedMembershipValues);
                    if (measure <= desiredFuzziness)
                    {
                        break;
                    }
                }
            }

            byte[,] defuzzifiedPixels = Defuzzfy(modifiedMembershipValues);
            Input.Image.SetPixels(defuzzifiedPixels);
            return new AlgorithmResult(Input.Image)
                       {
                           Measure = FuzzyMeasures.Fuzz(modifiedMembershipValues)
                       };
        }

        private static double IntOperator(double membership)
        {
            if (membership <= 0.5)
            {
                return 2*Math.Pow(membership, 2);
            }

            return 1 - 2*Math.Pow(1 - membership, 2);
        }

        private double CalculateDenominationalFuzzifier(int crossover, byte max)
        {
            return (max - crossover)/(Math.Pow(0.5, -1/exponentialFuzzifier) - 1);
        }

        private byte[,] Defuzzfy(double[,] membershipValues)
        {
            double[,] defuzzifiedDoubles = membershipValues.ApplyTransform(InversedMembershipFunction);
            byte[,] defuzzifiedBytes = defuzzifiedDoubles.NarrowToBytes();
            return defuzzifiedBytes;
        }

        private double[,] Fuzzify(byte[,] input)
        {
            var stats = new ImageStatistics(Input.Image);
            int minGrayLevel = stats.Gray.Min;
            maxGrayLevel = stats.Gray.Max;
            if (crossoverPoint == -1)
            {
                crossoverPoint = (byte) (maxGrayLevel - minGrayLevel)/2 + minGrayLevel;
            }

            denominationalFuzzifier = CalculateDenominationalFuzzifier(crossoverPoint, (byte) maxGrayLevel);

            double[,] result = input.ApplyTransform((Func<byte, double>) MembershipFunction);
            return result;
        }

        private double MembershipFunction(byte grayLevel)
        {
            return
                Math.Pow(
                    1 + (maxGrayLevel - grayLevel)/denominationalFuzzifier,
                    -exponentialFuzzifier);
        }

        private double InversedMembershipFunction(double membership)
        {
            double result = maxGrayLevel + denominationalFuzzifier*(1 - 1/Math.Pow(membership, 1/exponentialFuzzifier));
            if (result < 0)
            {
                return 0;
            }

            if (result > 255)
            {
                return 255;
            }

            return result;
        }

        protected override void OnParameterChanged(AlgorithmParameter parameter)
        {
            if (parameter.Name.Equals("ExponentialFuzzifier"))
            {
                exponentialFuzzifier = parameter.Value;
            }
            else if (parameter.Name.Equals("Crossover"))
            {
                crossoverPoint = (int) parameter.Value;
            }
            else if (parameter.Name.Equals("Iterations"))
            {
                iterations = Convert.ToInt32(Math.Round(parameter.Value, MidpointRounding.AwayFromZero));
            }
            else if (parameter.Name.Equals("DesiredFuzziness"))
            {
                desiredFuzziness = parameter.Value;
            }
        }
    }
}