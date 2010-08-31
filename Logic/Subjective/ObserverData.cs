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

        public bool FullyTrained { get; private set; }

        public string Status { get; private set; }

        public bool CanBeTrained { get; private set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void ResetTraining()
        {
            foreach (TrainingData data in TrainingData)
            {
                data.UserScore = null;
                data.SystemScore = null;
            }

            CheckTrainingStatus();
        }

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
        }

        private void InvokePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}