using System;
using AForge.Fuzzy;

namespace Logic.Algorithms
{
    public class FuzzySmoother : AlgorithmBase
    {
        private int centerPoint = 30;
        private InferenceSystem inferenceSystem;
        private int widthParam = 10;
        private int windowSize = 3;

        public FuzzySmoother()
        {
            AddParameter(new AlgorithmParameter("Width", 10));
            AddParameter(new AlgorithmParameter("WindowSize", 3));
            AddParameter(new AlgorithmParameter("Center", 30));
        }

        public override AlgorithmResult ProcessData()
        {
            InferenceSystem system = SetupInferenceSystem(windowSize);
            byte[,] pixels = Input.Image.GetPixels();
            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);

            var result = new byte[width,height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int[] windowData = GetNeighboursData(pixels, i, j, windowSize, width, height);
                    result[i, j] = Modify(system, windowData, pixels[i, j]);
                }
            }

            Input.Image.SetPixels(result);
            return new AlgorithmResult(Input.Image);
        }

        private byte Modify(InferenceSystem system, int[] windowData, byte center)
        {
            for (int i = 0; i < windowSize*windowSize - 1; i++)
            {
                system.SetInput(String.Format("IN{0}", i), windowData[i]);
            }

            int x = center + (byte) system.Evaluate("OUT");
            if (x < 0)
            {
                return 0;
            }

            if (x > 255)
            {
                return 255;
            }

            return (byte) x;
        }

        public InferenceSystem SetupInferenceSystem(int width)
        {
            var mp = new TrapezoidalFunction(centerPoint - width/2, centerPoint, centerPoint + width/2);
            var mn = new TrapezoidalFunction(-centerPoint - width/2, -centerPoint, -centerPoint + width/2);
            var sp = new TrapezoidalFunction(centerPoint/2 - width/3, (double) centerPoint/2, centerPoint/2 + width/3);
            var sn = new TrapezoidalFunction(-centerPoint/2 - width/3, (double) -centerPoint/2, -centerPoint/2 + width/3);
            var ze = new TrapezoidalFunction(-3, 0, 3);

            var mpSet = new FuzzySet("MP", mp);
            var mnSet = new FuzzySet("MN", mn);
            var spSet = new FuzzySet("SP", sp);
            var snSet = new FuzzySet("SN", sn);
            var zeSet = new FuzzySet("ZE", ze);

            var ruleDatabase = new Database();

            for (int i = 0; i < windowSize*windowSize - 1; i++)
            {
                var variable = new LinguisticVariable(String.Format("IN{0}", i), -255, 255);
                variable.AddLabel(mpSet);
                variable.AddLabel(mnSet);
                ruleDatabase.AddVariable(variable);
            }

            var outVariable = new LinguisticVariable("OUT", -centerPoint - width/2, centerPoint + width/2);
            outVariable.AddLabel(spSet);
            outVariable.AddLabel(snSet);
            outVariable.AddLabel(zeSet);
            ruleDatabase.AddVariable(outVariable);
            var inferenceSystem = new InferenceSystem(ruleDatabase, new COG(100));
            string rule1 = "IF ";
            string rule2 = "IF ";
            string rule3 = "IF ";
            for (int i = 0; i < windowSize*windowSize - 1; i++)
            {
                rule1 += String.Format("IN{0} is MP and ", i);
                rule2 += String.Format("IN{0} is MN and ", i);
                rule3 += String.Format("IN{0} is not MP and IN{0} is not MN AND ", i);
            }

            rule1 = rule1.Remove(rule1.Length - 4, 4);
            rule2 = rule2.Remove(rule2.Length - 4, 4);
            rule3 = "IF NOT (" + rule1.Replace("IF", "") + ") AND NOT(" + rule2.Replace("IF", "") + ")";

            rule1 += " then OUT is SN";
            rule2 += " then OUT is SP";
            rule3 += " then OUT is ZE";

            inferenceSystem.NewRule("Rule1", rule1);
            inferenceSystem.NewRule("Rule2", rule2);
            inferenceSystem.NewRule("Rule3", rule3);

            return inferenceSystem;
        }

        protected override void OnParameterChanged(AlgorithmParameter parameter)
        {
            if (parameter.Name.Equals("Width"))
            {
                widthParam = (int) parameter.Value;
            }

            if (parameter.Name.Equals("WindowSize"))
            {
                windowSize = (int) parameter.Value;
            }

            if (parameter.Name.Equals("Center"))
            {
                centerPoint = (int) parameter.Value;
            }
        }

        private int[] GetNeighboursData(byte[,] pixels, int x, int y, int window, int width, int height)
        {
            if (window%2 == 0) window--;
            int offset = window/2;
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

            var result = new int[(window*window) - 1];
            int num = 0;
            byte center = pixels[x, y];
            for (int i = left; i <= right; i++)
            {
                for (int j = up; j <= down; j++)
                {
                    if (i == x && j == y)
                    {
                        continue;
                    }

                    result[num] = pixels[i, j] - center;
                    num++;
                }
            }

            return result;
        }

        #region Nested type: COG

        private class COG : IDefuzzifier
        {
            private readonly int intervals;

            public COG(int intervals)
            {
                this.intervals = intervals;
            }

            #region IDefuzzifier Members

            public double Defuzzify(FuzzyOutput fuzzyOutput, INorm normOperator)
            {
                // results and accumulators
                double weightSum = 0, membershipSum = 0;
                // speech universe
                double start = fuzzyOutput.OutputVariable.Start;
                double end = fuzzyOutput.OutputVariable.End;

                // increment
                double increment = (end - start)/intervals;
                // running through the speech universe and evaluating the labels at each point
                for (double x = start; x < end; x += increment)
                {
                    // we must evaluate x membership to each one of the output labels
                    foreach (FuzzyOutput.OutputConstraint oc in fuzzyOutput.OutputList)
                    {
                        // getting the membership for X and constraining it with the firing strength
                        double membership = fuzzyOutput.OutputVariable.GetLabelMembership(oc.Label, x);
                        double constrainedMembership = normOperator.Evaluate(membership, oc.FiringStrength);


                        weightSum += x*constrainedMembership;
                        membershipSum += constrainedMembership;
                    }
                }
                // if no membership was found, then the membershipSum is zero and the numerical output is unknown.
                if (membershipSum == 0)
                    return 0;
                return weightSum/membershipSum;
            }

            #endregion
        }

        #endregion
    }
}