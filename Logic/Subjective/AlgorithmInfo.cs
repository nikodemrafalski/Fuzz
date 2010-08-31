using System;
using System.Collections.Generic;

namespace Logic.Subjective
{
    [Serializable]
    public class AlgorithmInfo
    {
        public string AlgorithName { get; set; }
        public string CustomName { get; set; }
        public IList<AlgorithmParameter> Parameters { get; set; }
    }
}