using System;
using AForge.Imaging;

namespace Logic
{
    public interface IAlgorithm
    {
        event EventHandler<EventArgs> ExecutionCompleted;
        AlgorithmInput Input { get; set; }
        AlgorithmResult Output { get; }
        AlgorithmResult ProcessData();
        void ProcessDataAsync();
    }
}