using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

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
            var evaluator = new Evaluator();
            evaluator.Evaluate(observerData.TrainingData);
        }
    }
}