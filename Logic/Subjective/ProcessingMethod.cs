using System.ComponentModel;

namespace Logic.Subjective
{
    public enum ProcessingMethod
    {
        [Description("Algorytm o najlepszym wyniku")]
        UseAlgorithmWithHighestScore = 0,
        [Description("Fuzja algorytmów")]
        AlgorithmsFusion = 1
    }
}