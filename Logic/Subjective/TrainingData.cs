using System;

namespace Logic.Subjective
{
    [Serializable]
    public class TrainingData
    {
        public string ImagePath { get; set; }
        public byte? UserScore { get; set; }
        public double? SystemScore { get; set; }
        public AlgorithmInfo AlgorithmInfo { get; set; }
    }
}