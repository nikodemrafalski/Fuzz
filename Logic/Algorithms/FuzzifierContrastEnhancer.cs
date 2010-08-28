using System;
using System.Threading;
using AForge.Imaging;
using Commons;
using Logic.Evalutation;

namespace Logic.Algorithms
{
    internal class FuzzifierContrastEnhancer : Algorithm
    {
        private double exponentialFuzzifier = 1;
        private double denominationalFuzzifier = -1;
        private double maxGrayLevel;
        private int iterations = 1;
        private double desiredFuzziness = 0;

        public FuzzifierContrastEnhancer()
        {
            this.AddParameter(new AlgorithmParameter("ExponentialFuzzifier", 1));
            this.AddParameter(new AlgorithmParameter("DenominationalFuzzifier", -1));
            this.AddParameter(new AlgorithmParameter("Iterations", 1));
            this.AddParameter(new AlgorithmParameter("DesiredFuzziness", -1));
        }

        public override AlgorithmResult ProcessData()
        {
            byte[,] pixels = this.Input.Image.GetPixels();
            double[,] membershipValues = this.Fuzzify(pixels);
            this.Input.Measure = FuzzyMeasures.Fuzz(membershipValues);
            double[,] modifiedMembershipValues = membershipValues;
            if (desiredFuzziness != 0)
            {
                this.iterations = 200;
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

            byte[,] defuzzifiedPixels = this.Defuzzfy(modifiedMembershipValues);
            this.Input.Image.SetPixels(defuzzifiedPixels);
            return new AlgorithmResult(this.Input.Image)
            {
                Measure = FuzzyMeasures.Fuzz(modifiedMembershipValues)
            };
        }

        private static double IntOperator(double membership)
        {
            if (membership <= 0.5)
            {
                return 2 * Math.Pow(membership, 2);
            }

            return 1 - 2 * Math.Pow(1 - membership, 2);
        }

        private double CalculateDenominationalFuzzifier(byte min, byte max)
        {
            return (max - (max - min) / 2 + min) / (Math.Pow(0.5, -1 / exponentialFuzzifier) - 1);
        }

        private byte[,] Defuzzfy(double[,] membershipValues)
        {
            double[,] defuzzifiedDoubles = membershipValues.ApplyTransform(this.InversedMembershipFunction);
            byte[,] defuzzifiedBytes = defuzzifiedDoubles.NarrowToBytes();
            return defuzzifiedBytes;
        }

        private double[,] Fuzzify(byte[,] input)
        {
            var stats = new ImageStatistics(this.Input.Image);
            int minGrayLevel = stats.Gray.Min;
            this.maxGrayLevel = stats.Gray.Max;
            if (this.denominationalFuzzifier == -1)
            {
                this.denominationalFuzzifier = this.CalculateDenominationalFuzzifier((byte)minGrayLevel, (byte)maxGrayLevel);
            }

            double[,] result = input.ApplyTransform((Func<byte, double>)this.MembershipFunction);
            return result;
        }

        private double MembershipFunction(byte grayLevel)
        {
            return
                Math.Pow(
                    1 + (maxGrayLevel - grayLevel) / denominationalFuzzifier,
                    -exponentialFuzzifier);
        }

        private double InversedMembershipFunction(double membership)
        {
            return this.maxGrayLevel + this.denominationalFuzzifier * (1 - 1 / Math.Pow(membership, 1 / exponentialFuzzifier));
        }

        protected override void OnParameterChanged(AlgorithmParameter parameter)
        {
            if (parameter.Name.Equals("ExponentialFuzzifier"))
            {
                this.exponentialFuzzifier = parameter.Value;
            }
            else if (parameter.Name.Equals("DenominationalFuzzifier"))
            {
                this.denominationalFuzzifier = parameter.Value;
            }
            else if (parameter.Name.Equals("Iterations"))
            {
                this.iterations = Convert.ToInt32(Math.Round(parameter.Value, MidpointRounding.AwayFromZero));
            }
            else if (parameter.Name.Equals("DesiredFuzziness"))
            {
                this.desiredFuzziness = parameter.Value;
            }
        }
    }
}