using System;
using System.Threading;
using Commons;


namespace Logic.Algorithms
{
    internal class FuzzifierContrastEnhancer : Algorithm
    {
        private double exponentialFuzzifier = 1;
        private double denominationalFuzzifier = 16;

        private int height;
        private int width;
        private double maxGrayLevel;
        private double minGrayLevel;

        public FuzzifierContrastEnhancer()
        {
            this.AddParameter(new AlgorithmParameter("ExponentialFuzzifier", 1));
            this.AddParameter(new AlgorithmParameter("DenominationalFuzzifier", 16));
        }

        public override AlgorithmResult ProcessData()
        {
            this.width = this.Input.Image.Width;
            this.height = this.Input.Image.Height;

            byte[,] pixels = this.Input.Image.GetPixels();
            double[,] membershipValues = this.Fuzzify(pixels);
            double[,] modifiedMembershipValues = membershipValues.ApplyTransform(IntOperator);
            byte[,] defuzzifiedPixels = this.Defuzzfy(modifiedMembershipValues);
            this.Input.Image.SetPixels(defuzzifiedPixels);
            return new AlgorithmResult(this.Input.Image);
        }

        private static double IntOperator(double membership)
        {
            if (membership <= 0.5)
            {
                return 2 * Math.Pow(membership, 2);
            }

            return 1 - 2 * Math.Pow(1 - membership, 2);
        }

        private byte[,] Defuzzfy(double[,] membershipValues)
        {
            double[,] defuzzifiedDoubles = membershipValues.ApplyTransform(this.InversedMembershipFunction);
            byte[,] defuzzifiedBytes = defuzzifiedDoubles.NarrowToBytes();
            return defuzzifiedBytes;
        }

        private double[,] Fuzzify(byte[,] input)
        {
            Tuple<byte, byte> minMax = input.GetMinAndMaxValues();
            this.minGrayLevel = minMax.Item1;
            this.maxGrayLevel = minMax.Item2;
            double[,] result = input.ApplyTransform(this.MembershipFunction);
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

        public event EventHandler<EventArgs> SomeEvent;

        // Version 4 
        protected void OnSomeEvent(EventArgs e)
        {
            EventHandler<EventArgs> temp =
               Interlocked.CompareExchange(ref SomeEvent, null, null);

            if (temp != null)
            {
                temp(this, e);
            }
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
        }
    }
}