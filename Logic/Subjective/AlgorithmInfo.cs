using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
