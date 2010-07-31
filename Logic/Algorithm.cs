using System;
using System.Threading.Tasks;
using AForge.Imaging;

namespace Logic
{
    internal abstract class Algorithm : IAlgorithm
    {
        public event EventHandler<EventArgs> ExecutionCompleted = (s, a) => { };

        protected Algorithm(UnmanagedImage input)
        {
            this.Input = input;
        }

        public UnmanagedImage Input { get; set; }
        public AlgorithmResult Output { get; protected set; }

        public abstract AlgorithmResult ProcessData();

        public void ProcessDataAsync()
        {
            Task<AlgorithmResult>.Factory
                .StartNew(ProcessData)
                .ContinueWith(t =>
                                  {
                                      Output = t.Result;
                                      this.InvokeExecutionCompleted();
                                  });
        }

        private void InvokeExecutionCompleted()
        {
            EventHandler<EventArgs> handler = this.ExecutionCompleted;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}