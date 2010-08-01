using System.Collections.Generic;

namespace Logic.Algorithms
{
    public static class AlgorithmsNames
    {
        public const string FuzzifierContrastEnhancer = "FuzzifierContrastEnhancer";

        public static IEnumerable<string> All
        {
            get;
            private set;
        }

        static AlgorithmsNames()
        {
            All = new List<string> { FuzzifierContrastEnhancer };
        }
    }
}