using System;
using System.Collections.Generic;

namespace Logic
{
    public interface IAlgorithm
    {
        string AlgorithmName { get; set; }

        IList<AlgorithmParameter> Parameters { get; }

        AlgorithmInput Input { get; set; }

        void SetParameters(IEnumerable<AlgorithmParameter> parameters);

        AlgorithmResult Output { get; }
        event EventHandler<EventArgs> ExecutionCompleted;

        AlgorithmResult ProcessData();

        void ProcessDataAsync();
    }
}