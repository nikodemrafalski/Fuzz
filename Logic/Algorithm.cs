using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AForge.Imaging;

namespace Logic
{
    internal abstract class Algorithm : IAlgorithm
    {
        public event EventHandler<EventArgs> ExecutionCompleted;
        private readonly IList<AlgorithmParameter> parameters = new List<AlgorithmParameter>();

        protected void AddParameter(AlgorithmParameter parameter)
        {
            this.parameters.Add(parameter);
            parameter.PropertyChanged += this.OnParameterValueChanged;
        }

        public IList<AlgorithmParameter> Parameters
        {
            get { return this.parameters; }
        }

        public AlgorithmInput Input { get; set; }

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
            this.OnParameterChanged((AlgorithmParameter)sender);
        }
    }
}