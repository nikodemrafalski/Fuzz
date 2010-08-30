using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Commons;
using System.Linq;

namespace Logic.Subjective
{
    [Serializable]
    public class SubjectiveSystem
    {
        public SubjectiveSystem()
        {
            Algorithms = new BindingList<string>();
            Observers = new BindingList<string>();
            ImagesPaths = new BindingList<string>();
        }

        public string SystemName { get; private set; }

        public IList<string> Algorithms { get; private set; }

        public IList<string> Observers { get; private set; }

        public IList<string> ImagesPaths { get; private set; }

        public IList<TrainingData> PrepareTrainingData(string observerName)
        {
            var list = new List<TrainingData>();
            foreach (string path in ImagesPaths)
            {
                foreach (string algorithm in Algorithms)
                {
                    list.Add(new TrainingData
                    {
                        AlgorithmName = algorithm,
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
    }
}