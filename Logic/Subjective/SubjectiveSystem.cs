using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using AForge.Fuzzy;

namespace Logic.Subjective
{
    [Serializable]
    public class SubjectiveSystem
    {
        public SubjectiveSystem()
        {
            Algorithms = new BindingList<AlgorithmInfo>();
            ObserversData = new BindingList<ObserverData>();
            ImagesPaths = new BindingList<string>();
        }

        public string SystemName { get; private set; }

        public IList<AlgorithmInfo> Algorithms { get; private set; }

        public IList<ObserverData> ObserversData { get; private set; }

        public IList<string> ImagesPaths { get; private set; }

        public void AddObserver(string observerName)
        {
            var observerData = new ObserverData
                {
                    ObserverName = observerName,
                    TrainingData = PrepareTrainingData()
                };

            ObserversData.Add(observerData);
            observerData.CheckTrainingStatus();
        }

        private IList<TrainingData> PrepareTrainingData()
        {
            var list = new List<TrainingData>();
            foreach (string path in ImagesPaths)
            {
                foreach (AlgorithmInfo algorithm in Algorithms)
                {
                    list.Add(new TrainingData
                        {
                            AlgorithmInfo = algorithm,
                            ImagePath = path
                        });
                }
            }

            return list.OrderBy(x => Guid.NewGuid()).ToList();
        }

        public static SubjectiveSystem CreateNew(string systemName)
        {
            return new SubjectiveSystem { SystemName = systemName };
        }

        public static void SaveState(SubjectiveSystem system, string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, system);
            }
        }

        public static SubjectiveSystem LoadState(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var formatter = new BinaryFormatter();
                return (SubjectiveSystem)formatter.Deserialize(stream);
            }
        }

        public void Infere(ObserverData observerData)
        {
            var system = new EvaluationSystem();
        }
    }

    public class EvaluationSystem
    {
        private InferenceSystem inferenceSystem;

        public EvaluationSystem()
        {

        }

        private Dictionary<string, double> CalculateMos(IEnumerable<TrainingData> datas)
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

        private Dictionary<string, double> CalculateNormalizedMos(IEnumerable<TrainingData> datas)
        {
            return this.CalculateMos(datas).ToDictionary(pair => pair.Key, pair => (-pair.Value)*(1.25) + 1.25);
        }

        private void ConfigureInferenceSystem()
        {
            var subjectiveVariable = new LinguisticVariable("SUBJECTIVE", 0, 1);
            var objectiveVariable = new LinguisticVariable("OBJECTIVE", 0, 1);
            var resultVariable = new LinguisticVariable("RESULT", 0, 1);
            

            //var subHi = TrapezoidalFunction();
            // var subMedium = TrapezoidalFunction();
            // var subLow = TrapezoidalFunction();

            // var objHi = TrapezoidalFunction();
            //var objMedium = TrapezoidalFunction();
            // var objLow = TrapezoidalFunction();
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
                return obj.GetHashCode();
            }
        }
    }
}