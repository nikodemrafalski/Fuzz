using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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