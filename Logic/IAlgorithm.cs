using System;
using System.Collections.Generic;
using AForge.Imaging;

namespace Logic
{
    public interface IAlgorithm
    {
        event EventHandler<EventArgs> ExecutionCompleted;

        IList<AlgorithmParameter> Parameters { get; }

        AlgorithmInput Input { get; set; }

        AlgorithmResult Output { get; }

        AlgorithmResult ProcessData();

        void ProcessDataAsync();
    }
}