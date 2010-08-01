using System;
using System.Threading.Tasks;
using AForge.Imaging;

namespace Logic
{
    internal abstract class Algorithm : IAlgorithm
    {
        public event EventHandler<EventArgs> ExecutionCompleted = (s, a) => { };

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
                                      InvokeExecutionCompleted();
                                  });
        }

        private void InvokeExecutionCompleted()
        {
            EventHandler<EventArgs> handler = ExecutionCompleted;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}