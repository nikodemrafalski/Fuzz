using System;
using AForge.Fuzzy;
using AForge.Imaging;
using Commons;

namespace Logic.Algorithms
{
    public class RuleBasedContrastEnhancer : Algorithm
    {
        public override AlgorithmResult ProcessData()
        {
            byte[,] pixels = this.Input.Image.GetPixels();
            Tuple<byte, byte> minMax = pixels.GetMinAndMaxValues();
            InferenceSystem system = this.SetupInferenceSystem(minMax.Item1, minMax.Item2);
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

        private InferenceSystem SetupInferenceSystem(byte minLuma, byte maxLuma)
        {
            byte crossover = (byte)((maxLuma - minLuma) / 2 + minLuma);
            var lumaIn = new LinguisticVariable("LumaIn", 0, 255);
            var lumaOut = new LinguisticVariable("LumaOut", 0, 255);

            var darkFunction = new TrapezoidalFunction(minLuma, crossover, TrapezoidalFunction.EdgeType.Right);
            var darkSet = new FuzzySet("Dark", darkFunction);

            var mediumFunction = new TrapezoidalFunction(minLuma, crossover, maxLuma - 20);
            var mediumSet = new FuzzySet("Medium", mediumFunction);

            var lightFunction = new TrapezoidalFunction(crossover, maxLuma, TrapezoidalFunction.EdgeType.Left);
            var lightSet = new FuzzySet("Light", lightFunction);

            var lighterFunction = new SingletonFunction(255);
            var lighterSet = new FuzzySet("Lighter", lighterFunction);

            var darkerFunction = new SingletonFunction(0);
            var darkerSet = new FuzzySet("Darker", darkerFunction);

            var medium2Function = new SingletonFunction(128);
            var medium2Set = new FuzzySet("Medium2", medium2Function);

            lumaIn.AddLabel(darkSet);
            lumaIn.AddLabel(mediumSet);
            lumaIn.AddLabel(lightSet);
            lumaOut.AddLabel(darkerSet);
            lumaOut.AddLabel(medium2Set);
            lumaOut.AddLabel(lighterSet);

            var database = new Database();
            database.AddVariable(lumaIn);
            database.AddVariable(lumaOut);


            var inferenceSystem = new InferenceSystem(database, new MyDefuzzifier(0, 255, 128));
            inferenceSystem.NewRule("Rule 1", "IF LumaIn IS Dark THEN LumaOut is Darker");
            inferenceSystem.NewRule("Rule 2", "IF LumaIn IS Medium THEN LumaOut is Medium2");
            inferenceSystem.NewRule("Rule 3", "IF LumaIn IS Light THEN LumaOut is Lighter");

            return inferenceSystem;
        }
    }

    public class MyDefuzzifier : IDefuzzifier
    {
        private readonly byte min;
        private readonly byte max;
        private readonly byte crossOver;

        public MyDefuzzifier(byte min, byte max, byte crossOver)
        {
            this.min = min;
            this.max = max;
            this.crossOver = crossOver;
        }

        public double Defuzzify(FuzzyOutput fuzzyOutput, INorm normOperator)
        {
            double darkMembership = 0;
            double mediumMembership = 0;
            double lightMembership = 0;

            foreach (FuzzyOutput.OutputConstraint constraint in fuzzyOutput.OutputList)
            {
                if (constraint.Label == "Medium2")
                {
                    mediumMembership = constraint.FiringStrength;
                }

                if (constraint.Label == "Darker")
                {
                    darkMembership = constraint.FiringStrength;
                }

                if (constraint.Label == "Lighter")
                {
                    lightMembership = constraint.FiringStrength;
                }
            }

            return (128 * mediumMembership + 255 * lightMembership) /
                (darkMembership + mediumMembership + lightMembership);
        }
    }
}