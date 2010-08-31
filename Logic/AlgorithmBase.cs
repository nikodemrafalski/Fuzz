using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Logic
{
    [Serializable]
    public abstract class AlgorithmBase : IAlgorithm
    {
        private IList<AlgorithmParameter> parameters = new List<AlgorithmParameter>();

        #region IAlgorithm Members

        public event EventHandler<EventArgs> ExecutionCompleted;

        public string AlgorithmName
        {
            get;
            set;
        }

        public IList<AlgorithmParameter> Parameters
        {
            get { return parameters; }
        }

        public AlgorithmInput Input { get; set; }

        public void SetParameters(IEnumerable<AlgorithmParameter> algorithmParameters)
        {
            this.parameters = new List<AlgorithmParameter>(algorithmParameters);
            foreach (AlgorithmParameter parameter in parameters)
            {
                this.OnParameterChanged(parameter);
            }
        }

        public AlgorithmResult Output { get; protected set; }

        public abstract AlgorithmResult ProcessData();

        public void ProcessDataAsync()
        {
            Task<AlgorithmResult>.Factory
                .StartNew(ProcessData)
                .ContinueWith(t =>
                                  {
                                      Output = t.Result;
                                      InvokeExecutionCompleted();
                                  }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion

        protected void AddParameter(AlgorithmParameter parameter)
        {
            parameters.Add(parameter);
            parameter.PropertyChanged += OnParameterValueChanged;
        }

        protected virtual void OnParameterChanged(AlgorithmParameter parameter)
        {
        }

        private void InvokeExecutionCompleted()
        {
            EventHandler<EventArgs> handler = ExecutionCompleted;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void OnParameterValueChanged(object sender, PropertyChangingEventArgs e)
        {
            OnParameterChanged((AlgorithmParameter) sender);
        }
    }
}