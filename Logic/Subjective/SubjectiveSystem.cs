using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using AForge.Imaging;
using Commons;
using Autofac;

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

            return list.OrderBy(x => Guid.NewGuid()).OrderBy(x=>Guid.NewGuid()).ToList();
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
            IList<EvaluationResult> evaluationResults = evaluator.Evaluate(observerData.TrainingData);
            observerData.SetEvaluationResults(evaluationResults);
        }

        public Bitmap ProcessImage(Bitmap image, ObserverData observerData, ProcessingMethod processingMethod)
        {
            if (processingMethod == ProcessingMethod.UseAlgorithmWithHighestScore)
            {
                string bestAlgorithm =
                    observerData.EvaluationResults.OrderByDescending(x => x.AlgorithScore).First().AlgorithCustomName;
                AlgorithmInfo algorithmInfo = this.Algorithms.Where(x => x.CustomName == bestAlgorithm).Single();
                var algorithm = AppFacade.DI.Container.Resolve<IAlgorithm>(algorithmInfo.AlgorithName);
                algorithm.SetParameters(algorithmInfo.Parameters);
                return SimpleProcessing(image, algorithm);
            }
            if (processingMethod == ProcessingMethod.AlgorithmsFusion)
            {
                return FusionProcessing(image, this.Algorithms, observerData.EvaluationResults);
            }

            throw new NotSupportedException();
        }

        private static Bitmap SimpleProcessing(Bitmap image, IAlgorithm algorithm)
        {
            algorithm.Input = new AlgorithmInput(image);
            AlgorithmResult result = algorithm.ProcessData();
            return result.Image.ToManagedImage();
        }

        private static Bitmap FusionProcessing(Bitmap image,
            IEnumerable<AlgorithmInfo> algorithms,
            IEnumerable<EvaluationResult> algoritmsScores)
        {
            double totalScore = algoritmsScores.Sum(x => x.AlgorithScore);
            var results = new Dictionary<double, byte[,]>();
            foreach (var score in algoritmsScores)
            {
                AlgorithmInfo algorithmInfo = algorithms.Where(x => x.CustomName == score.AlgorithCustomName).Single();
                var algorithm = AppFacade.DI.Container.Resolve<IAlgorithm>(algorithmInfo.AlgorithName);
                algorithm.SetParameters(algorithmInfo.Parameters);
                algorithm.Input = new AlgorithmInput(image);
                UnmanagedImage result = algorithm.ProcessData().Image;
                results.Add(score.AlgorithScore / totalScore, result.GetPixels());
            }

            UnmanagedImage fusionImage =
                UnmanagedImage.FromManagedImage(new Bitmap(image.Width, image.Height, image.PixelFormat));

            var fusionBytes = new byte[image.Width, image.Height];
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    double level = results.Sum(keyValuePair => (keyValuePair.Key*keyValuePair.Value[i, j]));
                    fusionBytes[i, j] = (byte) level;
                }
            }

            fusionImage.SetPixels(fusionBytes);
            return fusionImage.ToManagedImage();
        }

        public void ResetData(ObserverData observerData)
        {
            foreach (TrainingData data in observerData.TrainingData)
            {
                data.UserScore = null;
                data.SystemScore = null;
            }

            observerData.EvaluationDone = false;
            observerData.CheckTrainingStatus();
            observerData.TrainingData = PrepareTrainingData();
        }
    }
}