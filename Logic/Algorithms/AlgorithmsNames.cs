using System.Collections.Generic;

namespace Logic.Algorithms
{
    public static class AlgorithmsNames
    {
        public static IList<string> All
        {
            get;
            private set;
        }

        static AlgorithmsNames()
        {
            All = new List<string>();
        }
    }
}