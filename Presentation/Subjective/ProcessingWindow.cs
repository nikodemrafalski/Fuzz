using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commons;
using Logic.Subjective;

namespace Presentation.Subjective
{
    public partial class ProcessingWindow : Form
    {
        private readonly SubjectiveSystem system;
        private readonly ObserverData observerData;
        private readonly ProcessingMethod processingMethod;
        private Bitmap originalSizeSource;

        public ProcessingWindow(SubjectiveSystem system, ObserverData observerData, ProcessingMethod processingMethod)
        {
            this.system = system;
            this.observerData = observerData;
            this.processingMethod = processingMethod;
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    dialog.Filter = @"(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
                    originalSizeSource = new Bitmap(dialog.OpenFile()).ConvertToGrayScale();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
            }

            DisplayData();
        }

        private void DisplayData()
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Bitmap resizedSource = originalSizeSource.ResizeImage(sourcePicture.Width, sourcePicture.Height);
            sourcePicture.Image = resizedSource;
            processedImage.Image = null;
            progressBar.Style = ProgressBarStyle.Marquee;
            Task<Bitmap>.Factory.StartNew(() => this.system.ProcessImage(resizedSource, observerData, processingMethod))
                .ContinueWith(x => OnProcessingExecutionCompleted(x.Result),
                                   TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void OnProcessingExecutionCompleted(Bitmap result)
        {
            this.InvokeIfRequired(() =>
                {
                    processedImage.Image = result;
                    progressBar.Style = ProgressBarStyle.Continuous;
                    FormBorderStyle = FormBorderStyle.SizableToolWindow;
                });
        }


        private void OnProcessingWindowResizeEnd(object sender, EventArgs e)
        {
            DisplayData();
        }
    }
}