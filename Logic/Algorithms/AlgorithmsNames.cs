using System.Collections.Generic;

namespace Logic.Algorithms
{
    public static class AlgorithmsNames
    {
        static AlgorithmsNames()
        {
            All = new List<string>();
        }

        public static IList<string> All { get; private set; }
    }
}