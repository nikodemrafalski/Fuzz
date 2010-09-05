using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Logic.Properties;

namespace Logic.Subjective
{
    [Serializable]
    public class ObserverData : INotifyPropertyChanged
    {
        public string ObserverName { get; set; }
        public IList<TrainingData> TrainingData { get; set; }
        public IList<EvaluationResult> EvaluationResults { get; private set; }
        public bool FullyTrained { get; private set; }
        public string Status { get; private set; }
        public bool EvaluationDone { get; internal set; }
        public bool CanBeTrained { get; private set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void CheckTrainingStatus()
        {
            FullyTrained = TrainingData.Count > 0 && TrainingData.Count(x => x.UserScore == null) == 0;
            CanBeTrained = TrainingData.Count > 0;

            if (FullyTrained)
            {
                Status = Resources.StatusFinished;
            }
            else
            {
                Status = Resources.StatusUnfinished;
            }

            InvokePropertyChanged("Status");
            InvokePropertyChanged("CanBeTrained");
            InvokePropertyChanged("FullyTrained");
            InvokePropertyChanged("EvaluationDone");
        }

        private void InvokePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void SetEvaluationResults(IList<EvaluationResult> evaluationResults)
        {
            this.EvaluationResults = evaluationResults;
            this.EvaluationDone = true;
            this.InvokePropertyChanged("EvaluationDone");
        }
    }
}