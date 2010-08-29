using System;
using AForge.Fuzzy;
using AForge.Imaging;
using Commons;

namespace Logic.Algorithms
{
    public class RuleBasedContrastEnhancer : Algorithm
    {
        private int gMin = -1, gMean = -1, gMax = -1;

        public RuleBasedContrastEnhancer()
        {
            this.AddParameter(new AlgorithmParameter("GMin", -1));
            this.AddParameter(new AlgorithmParameter("GMean", -1));
            this.AddParameter(new AlgorithmParameter("GMax", -1));
        }

        public override AlgorithmResult ProcessData()
        {
            byte[,] pixels = this.Input.Image.GetPixels();
            if (gMin == -1 || gMean == -1 || gMax == -1)
            {
                var stats = new ImageStatistics(this.Input.Image);
                gMin = stats.Gray.Min;
                gMax = stats.Gray.Max;
                gMean = (byte)((gMax - gMin) / 2 + gMin);
            }

            InferenceSystem system = this.SetupInferenceSystem((byte)gMin, (byte)gMax, (byte)gMean);
            var result = new byte[pixels.GetLength(0), pixels.GetLength(1)];

            for (int i = 0; i < pixels.GetLength(0); i++)
            {
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    system.SetInput("LumaIn", pixels[i, j]);
                    double inferrenceResult = system.Evaluate("LumaOut");
                    result[i, j] = (byte)inferrenceResult;
                }
            }

            this.Input.Image.SetPixels(result);
            return new AlgorithmResult(this.Input.Image);
        }

        private InferenceSystem SetupInferenceSystem(byte minLuma, byte maxLuma, byte meanLuma)
        {
            var lumaIn = new LinguisticVariable("LumaIn", minLuma, maxLuma);
            var lumaOut = new LinguisticVariable("LumaOut", 0, 255);

            var darkFunction = new TrapezoidalFunction(minLuma, meanLuma, TrapezoidalFunction.EdgeType.Right);
            var darkSet = new FuzzySet("Dark", darkFunction);

            var mediumFunction = new TrapezoidalFunction(minLuma, meanLuma, maxLuma);
            var mediumSet = new FuzzySet("Medium", mediumFunction);

            var lightFunction = new TrapezoidalFunction(meanLuma, maxLuma, TrapezoidalFunction.EdgeType.Left);
            var lightSet = new FuzzySet("Light", lightFunction);

            lumaIn.AddLabel(darkSet);
            lumaIn.AddLabel(mediumSet);
            lumaIn.AddLabel(lightSet);

            var whiteFunction = new SingletonFunction(255);
            var whiteSet = new FuzzySet("White", whiteFunction);

            var blackFunction = new SingletonFunction(0);
            var blackSet = new FuzzySet("Black", blackFunction);

            var grayFunction = new SingletonFunction(128);
            var graySet = new FuzzySet("Gray", grayFunction);

            lumaOut.AddLabel(blackSet);
            lumaOut.AddLabel(graySet);
            lumaOut.AddLabel(whiteSet);

            var database = new Database();
            database.AddVariable(lumaIn);
            database.AddVariable(lumaOut);

            var inferenceSystem = new InferenceSystem(database, new CogDefuzzifier());
            inferenceSystem.NewRule("Rule 1", "IF LumaIn IS Dark THEN LumaOut is Black");
            inferenceSystem.NewRule("Rule 2", "IF LumaIn IS Medium THEN LumaOut is Gray");
            inferenceSystem.NewRule("Rule 3", "IF LumaIn IS Light THEN LumaOut is White");

            return inferenceSystem;
        }

        protected override void OnParameterChanged(AlgorithmParameter parameter)
        {
            if (parameter.Name.Equals("GMin"))
            {
                this.gMin = (int)parameter.Value;
            }
            else if (parameter.Name.Equals("GMean"))
            {
                this.gMean = (int)parameter.Value;
            }
            else if (parameter.Name.Equals("Gmax"))
            {
                this.gMax = (int)parameter.Value;
            }
        }
    }

    public class CogDefuzzifier : IDefuzzifier
    {
        public double Defuzzify(FuzzyOutput fuzzyOutput, INorm normOperator)
        {
            double blackMembership = 0;
            double grayMembership = 0;
            double whiteMembership = 0;

            foreach (FuzzyOutput.OutputConstraint constraint in fuzzyOutput.OutputList)
            {
                if (constraint.Label == "Gray")
                {
                    grayMembership = constraint.FiringStrength;
                }

                if (constraint.Label == "Black")
                {
                    blackMembership = constraint.FiringStrength;
                }

                if (constraint.Label == "White")
                {
                    whiteMembership = constraint.FiringStrength;
                }
            }

            return (128 * grayMembership + 255 * whiteMembership) /
                (blackMembership + grayMembership + whiteMembership);
        }
    }
}