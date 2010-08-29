using System;
using System.Collections.Generic;

namespace Logic
{
    public interface IAlgorithm
    {
        IList<AlgorithmParameter> Parameters { get; }

        AlgorithmInput Input { get; set; }

        AlgorithmResult Output { get; }
        event EventHandler<EventArgs> ExecutionCompleted;

        AlgorithmResult ProcessData();

        void ProcessDataAsync();
    }
}