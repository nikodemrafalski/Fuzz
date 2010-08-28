using System.Collections.Generic;
using System.Drawing;
using Logic;

namespace FuzzyProject
{
    public interface IMainView
    {
        void DisplaySourceImage(Image image);
        void DisplayProcessedImage(Image image);
        void UpdateAlgorithmsList(IEnumerable<string> algoritmsNames);
        void UpdateParametersList(IEnumerable<AlgorithmParameter> paramerers);
        void StartNotifyingProgress();
        void StopNotifyingProgress();
        void DisplayEvaluationScores(double sourceScore, double processedScore);
        void DisplayMeasures(double sourceScore, double processedScore);
    }
}