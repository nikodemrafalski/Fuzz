using System.Collections.Generic;
using System.Linq;
using AForge.Fuzzy;
using Logic.MembershipFunctions;

namespace Logic.Subjective
{
    public class Evaluator
    {
        private readonly InferenceSystem inferenceSystem;

        public Evaluator()
        {
            inferenceSystem = CreateInferenceSystem();
        }

        public IList<EvaluationResult> Evaluate(IEnumerable<TrainingData> datas)
        {
            IEnumerable<string> algorithms =
                datas.Distinct(new TrainingDataComparer()).Select(x => x.AlgorithmInfo.CustomName);

            Dictionary<string, double> userMeans = CalculateMos(datas);
            Dictionary<string, double> normalizedUserMeans = CalculateNormalizedMos(datas);
            Dictionary<string, double> systemMeans = CalculateSystemMeans(datas);
            Dictionary<string, double> systemNormalizedMeans = CalculateNormalizedSystemMeans(datas);

            var result = new List<EvaluationResult>();
            foreach (string algorithm in algorithms)
            {
                inferenceSystem.SetInput("OBJECTIVE", systemNormalizedMeans[algorithm]);
                inferenceSystem.SetInput("SUBJECTIVE", systemNormalizedMeans[algorithm]);
                double finalScore = inferenceSystem.Evaluate("ALGORITHM_SCORE");
                result.Add(new EvaluationResult(algorithm,finalScore));
            }

            return result;
        }

        private static Dictionary<string, double> CalculateSystemMeans(IEnumerable<TrainingData> datas)
        {
            IEnumerable<string> algorithms =
                datas.Distinct(new TrainingDataComparer()).Select(x => x.AlgorithmInfo.CustomName);
            var meanValues = new Dictionary<string, double>();

            foreach (string algorithm in algorithms)
            {
                IEnumerable<TrainingData> algorithScores = datas.Where(x => x.AlgorithmInfo.AlgorithName == algorithm);
                double sumOfScores = algorithScores.Sum(x => x.SystemScore.Value);
                double mean = sumOfScores / algorithScores.Count();
                meanValues.Add(algorithm, mean);
            }

            return meanValues;
        }

        private static Dictionary<string, double> CalculateNormalizedSystemMeans(IEnumerable<TrainingData> datas)
        {
            double maxScore = datas.Max(x => x.SystemScore.Value);
            return CalculateSystemMeans(datas).ToDictionary(pair => pair.Key, pair => pair.Value / maxScore);
        }

        private static Dictionary<string, double> CalculateMos(IEnumerable<TrainingData> datas)
        {
            IEnumerable<string> algorithms =
                datas.Distinct(new TrainingDataComparer()).Select(x => x.AlgorithmInfo.CustomName);
            var mosValues = new Dictionary<string, double>();
            foreach (string algorithm in algorithms)
            {
                IEnumerable<TrainingData> algorithScores = datas.Where(x => x.AlgorithmInfo.AlgorithName == algorithm);
                int sumOfScores = algorithScores.Sum(x => x.UserScore.Value);
                double mos = sumOfScores / (double)algorithScores.Count();
                mosValues.Add(algorithm, mos);
            }

            return mosValues;
        }

        private static Dictionary<string, double> CalculateNormalizedMos(IEnumerable<TrainingData> datas)
        {
            return CalculateMos(datas).ToDictionary(pair => pair.Key, pair => -(pair.Value) * (0.25) + 1.25);
        }

        private static InferenceSystem CreateInferenceSystem()
        {
            var objectiveVariable = new LinguisticVariable("OBJECTIVE", 0, 1);
            var subjectiveVariable = new LinguisticVariable("SUBJECTIVE", 0, 1);
            var algorithmScoreVariable = new LinguisticVariable("ALGORITHM_SCORE", 0, 1);


            var objectiveLow = new ZTypeMembership(0, 0.5);
            var objectiveMedium = new PITypeMembership(0, 0.5, 0.75);
            var objectiveHigh = new STypeMembership(0.25, 1);

            var subjectiveLow = new ZTypeMembership(0, 0.5);
            var subjectiveMedium = new PITypeMembership(0.25, 0.5, 0.75);
            var subjectiveHigh = new STypeMembership(0.5, 1);

            var algorithmScoreVeryLow = new VeryHedge(new ZTypeMembership(0, 0.5));
            var algorithmScoreLow = new ZTypeMembership(0, 0.5);
            var algorithmScoreMedium = new PITypeMembership(0.25, 0.5, 0.75);
            var algorithmScoreHigh = new STypeMembership(0.5, 1);
            var algorithmScoreVeryHigh = new VeryHedge(new STypeMembership(0.5, 1));


            var objectiveLowSet = new FuzzySet("LOW", objectiveLow);
            var objectiveMediumSet = new FuzzySet("MEDIUM", objectiveMedium);
            var objectiveHighSet = new FuzzySet("HIGH", objectiveHigh);

            var subjectiveLowSet = new FuzzySet("LOW", subjectiveLow);
            var subjectiveMediumSet = new FuzzySet("MEDIUM", subjectiveMedium);
            var subjectiveHighSet = new FuzzySet("HIGH", subjectiveHigh);

            var resultVeryLowSet = new FuzzySet("VERY_LOW", algorithmScoreVeryLow);
            var resultLowSet = new FuzzySet("LOW", algorithmScoreLow);
            var resultMediumSet = new FuzzySet("MEDIUM", algorithmScoreMedium);
            var resultHighSet = new FuzzySet("HIGH", algorithmScoreHigh);
            var resultVeryHighSet = new FuzzySet("VERY_HIGH", algorithmScoreVeryHigh);


            objectiveVariable.AddLabel(objectiveLowSet);
            objectiveVariable.AddLabel(objectiveMediumSet);
            objectiveVariable.AddLabel(objectiveHighSet);
            subjectiveVariable.AddLabel(subjectiveLowSet);
            subjectiveVariable.AddLabel(subjectiveMediumSet);
            subjectiveVariable.AddLabel(subjectiveHighSet);
            algorithmScoreVariable.AddLabel(resultVeryLowSet);
            algorithmScoreVariable.AddLabel(resultLowSet);
            algorithmScoreVariable.AddLabel(resultMediumSet);
            algorithmScoreVariable.AddLabel(resultHighSet);
            algorithmScoreVariable.AddLabel(resultVeryHighSet);

            var rulebase = new Database();
            rulebase.AddVariable(objectiveVariable);
            rulebase.AddVariable(subjectiveVariable);
            rulebase.AddVariable(algorithmScoreVariable);

            var inferenceSystem = new InferenceSystem(rulebase, new CentroidDefuzzifier(30));
            inferenceSystem.NewRule("Rule1", "if OBJECTIVE is LOW and SUBJECTIVE is LOW then ALGORITHM_SCORE is VERY_LOW ");
            inferenceSystem.NewRule("Rule2", "if OBJECTIVE is LOW and SUBJECTIVE is MEDIUM then ALGORITHM_SCORE is LOW");
            inferenceSystem.NewRule("Rule3", "if OBJECTIVE is LOW and SUBJECTIVE is HIGH then ALGORITHM_SCORE is MEDIUM");
            inferenceSystem.NewRule("Rule4", "if OBJECTIVE is MEDIUM and SUBJECTIVE is LOW then ALGORITHM_SCORE is LOW");
            inferenceSystem.NewRule("Rule5", "if OBJECTIVE is MEDIUM and SUBJECTIVE is MEDIUM then ALGORITHM_SCORE is MEDIUM");
            inferenceSystem.NewRule("Rule6", "if OBJECTIVE is MEDIUM and SUBJECTIVE is HIGH then ALGORITHM_SCORE is HIGH");
            inferenceSystem.NewRule("Rule7", "if OBJECTIVE is HIGH and SUBJECTIVE is LOW then ALGORITHM_SCORE is MEDIUM");
            inferenceSystem.NewRule("Rule8", "if OBJECTIVE is HIGH and SUBJECTIVE is MEDIUM then ALGORITHM_SCORE is HIGH");
            inferenceSystem.NewRule("Rule9", "if OBJECTIVE is HIGH and SUBJECTIVE is HIGH then ALGORITHM_SCORE is VERY_HIGH");

            return inferenceSystem;
        }

        #region Nested type: TrainingDataComparer

        private class TrainingDataComparer : IEqualityComparer<TrainingData>
        {
            #region IEqualityComparer<TrainingData> Members

            public bool Equals(TrainingData x, TrainingData y)
            {
                if (x == null || y == null)
                {
                    return false;
                }

                return x.AlgorithmInfo.CustomName == y.AlgorithmInfo.CustomName;
            }

            public int GetHashCode(TrainingData obj)
            {
                return obj.AlgorithmInfo.CustomName.GetHashCode();
            }

            #endregion
        }

        #endregion
    }
}