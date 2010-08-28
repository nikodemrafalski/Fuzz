using System.Collections.Generic;

namespace Logic.Algorithms
{
    public static class AlgorithmsNames
    {
        public const string LocalyAdaptiveFuzzyHistogramHiberbolization = "LocalyAdaptiveFuzzyHistogramHiberbolization";
        public const string FuzzyClassifierEdgeDetector = "FuzzyClassifierEdgeDetector";
        public const string FuzzifierContrastEnhancer = "FuzzifierContrastEnhancer";
        public const string FuzzyHistogramHiberbolization = "FuzzyHistogramHiberbolization";
        public const string RuleBasedContrastEnhancer = "RuleBasedContrastEnhancer";

        public static IEnumerable<string> All
        {
            get;
            private set;
        }

        static AlgorithmsNames()
        {
            All = new List<string> { FuzzifierContrastEnhancer, RuleBasedContrastEnhancer, FuzzyHistogramHiberbolization, LocalyAdaptiveFuzzyHistogramHiberbolization, FuzzyClassifierEdgeDetector };
        }
    }
}