using System;
using AForge.Imaging;

namespace Logic
{
    public interface IAlgorithm
    {
        event EventHandler<EventArgs> ExecutionCompleted;
        UnmanagedImage Input { get; set; }
        AlgorithmResult Output { get; }
        AlgorithmResult ProcessData();
        void ProcessDataAsync();
    }
}