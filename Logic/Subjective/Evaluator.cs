using System.Collections.Generic;
using System.Linq;
using AForge.Fuzzy;
using Logic.MembershipFunctions;

namespace Logic.Subjective
{
    public class Evaluator
    {
        private InferenceSystem inferenceSystem;

        public void Evaluate(IEnumerable<TrainingData> datas)
        {
            var userMeans = CalculateMos(datas);
            var normalizedUserMeans = CalculateNormalizedMos(datas);
            var systemMeans = CalculateSystemMeans(datas);
            var systemNormalizedMeans = CalculateNormalizedSystemMeans(datas);
        }

        private static Dictionary<string, double> CalculateSystemMeans(IEnumerable<TrainingData> datas)
        {
            var algorithms = datas.Distinct(new TrainingDataComparer()).Select(x => x.AlgorithmInfo.CustomName);
            var meanValues = new Dictionary<string, double>();

            foreach (string algorithm in algorithms)
            {
                var algorithScores = datas.Where(x => x.AlgorithmInfo.AlgorithName == algorithm);
                double sumOfScores = algorithScores.Sum(x => x.SystemScore.Value);
                double mean = (double)sumOfScores / (double)algorithScores.Count();
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
            var algorithms = datas.Distinct(new TrainingDataComparer()).Select(x => x.AlgorithmInfo.CustomName);
            var mosValues = new Dictionary<string, double>();
            foreach (string algorithm in algorithms)
            {
                var algorithScores = datas.Where(x => x.AlgorithmInfo.AlgorithName == algorithm);
                int sumOfScores = algorithScores.Sum(x => x.UserScore.Value);
                double mos = (double)sumOfScores / (double)algorithScores.Count();
                mosValues.Add(algorithm, mos);
            }

            return mosValues;
        }

        private static Dictionary<string, double> CalculateNormalizedMos(IEnumerable<TrainingData> datas)
        {
            return CalculateMos(datas).ToDictionary(pair => pair.Key, pair => -(pair.Value) * (0.25) + 1.25);
        }

        private void ConfigureInferenceSystem()
        {
            var objectiveVariable = new LinguisticVariable("OBJECTIVE", 0, 1);
            var subjectiveVariable = new LinguisticVariable("SUBJECTIVE", 0, 1);
            var resultVariable = new LinguisticVariable("RESULT", 0, 1);

            var objectiveLow = new ZTypeMembership(0, 0.5);
            var objectiveMedium = new PITypeMembership(0, 0.5, 0.75);
            var objectiveHigh = new STypeMembership(0.25, 1);
            var subjectiveLow = new ZTypeMembership(0, 0.5);
            var subjectiveMedium = new PITypeMembership(0.25, 0.5, 0.75);
            var subjectiveHigh = new STypeMembership(0.5, 1);
            var resultLow = new ZTypeMembership(0, 0.5);
            var resultMedium = new PITypeMembership(0.25, 0.5, 0.75);
            var resultHigh = new STypeMembership(0.5, 1);

            var objectiveLowSet = new FuzzySet("LOW", objectiveLow);
            var objectiveMediumSet = new FuzzySet("MEDIUM", objectiveMedium);
            var objectiveHighSet = new FuzzySet("HIGH", objectiveHigh);
            var subjectiveLowSet = new FuzzySet("LOW", subjectiveLow);
            var subjectiveMediumSet = new FuzzySet("MEDIUM", subjectiveMedium);
            var subjectiveHighSet = new FuzzySet("HIGH", subjectiveHigh);
            var resultLowSet = new FuzzySet("LOW", resultLow);
            var resultMediumSet = new FuzzySet("MEDIUM", resultMedium);
            var resultHighSet = new FuzzySet("HIGH", resultHigh);

            objectiveVariable.AddLabel(objectiveLowSet);
            objectiveVariable.AddLabel(objectiveMediumSet);
            objectiveVariable.AddLabel(objectiveHighSet);
            subjectiveVariable.AddLabel(subjectiveLowSet);
            subjectiveVariable.AddLabel(subjectiveMediumSet);
            subjectiveVariable.AddLabel(subjectiveHighSet);
            resultVariable.AddLabel(resultLowSet);
            resultVariable.AddLabel(resultMediumSet);
            resultVariable.AddLabel(resultHighSet);

            var rulebase = new Database();
            rulebase.AddVariable(objectiveVariable);
            rulebase.AddVariable(subjectiveVariable);
            rulebase.AddVariable(resultVariable);



        }

        private class TrainingDataComparer : IEqualityComparer<TrainingData>
        {
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
        }
    }
}