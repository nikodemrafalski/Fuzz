namespace Logic.Subjective
{
    public class EvaluationResult
    {
        public EvaluationResult(string algorithm, double score)
        {
            this.AlgorithCustomName = algorithm;
            this.AlgorithScore = score;
        }

        public string AlgorithCustomName { get; private set; }
        public double AlgorithScore { get; private set; }
    }
}