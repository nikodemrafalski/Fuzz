using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AForge.Imaging;
using Autofac;
using Commons;
using Logic;
using Logic.Algorithms;
using Logic.Evalutation;
using IContainer = Autofac.IContainer;

namespace FuzzyProject
{
    public class MainViewPresenter
    {
        private readonly IContainer container;
        private Bitmap originalSizeSource;
        private int pictureHeight;
        private int pictureWidth;
        private Bitmap resizedProcessed;
        private Bitmap resizedSource;
        private IAlgorithm selectedAlgoritm;
        private IMainView view;


        public void AttachView(IMainView mainView)
        {
            view = mainView;
            view.UpdateAlgorithmsList(AlgorithmsNames.All);
        }

        public void ProcessImage()
        {
            if (resizedSource == null || selectedAlgoritm == null)
            {
                return;
            }

            view.StartNotifyingProgress();
            selectedAlgoritm.Input = new AlgorithmInput(resizedSource);
            selectedAlgoritm.ExecutionCompleted += OnAlgorithmExecutionCompleted;
            selectedAlgoritm.ProcessDataAsync();
        }

        private void OnAlgorithmExecutionCompleted(object sender, EventArgs e)
        {
            resizedProcessed = selectedAlgoritm.Output.Image.ToManagedImage();
            view.StopNotifyingProgress();
            view.DisplayProcessedImage(resizedProcessed);
            EvaluateScores();
        }

        private void EvaluateScores()
        {
            view.DisplayMeasures(selectedAlgoritm.Input.Measure, selectedAlgoritm.Output.Measure);
            double sourceScore = ContrastEvaluator.EvaluateC(UnmanagedImage.FromManagedImage(resizedSource));
            double processedScore = ContrastEvaluator.EvaluateC(UnmanagedImage.FromManagedImage(resizedProcessed));
            view.DisplayEvaluationScores(sourceScore, processedScore);
        }

        public void LoadImage()
        {
            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    originalSizeSource = new Bitmap(dialog.OpenFile()).ConvertToGrayScale();
                    ShowSourceImage();
                }
            }
        }

        private void ShowSourceImage()
        {
            if (originalSizeSource != null)
            {
                resizedSource = originalSizeSource.ResizeImage(pictureWidth, pictureHeight);
                view.DisplaySourceImage(resizedSource);
            }
        }

        public void CloseApplication()
        {
            var cancelEventArgs = new CancelEventArgs();
            Application.Exit(cancelEventArgs);
        }

        public void ChangeSelectedAlgorithm(string algorithmName)
        {
            if (AppFacade.DI.Container == null)
            {
                return;
            }

            selectedAlgoritm = AppFacade.DI.Container.Resolve<IAlgorithm>(algorithmName);
            view.UpdateParametersList(selectedAlgoritm.Parameters);
        }

        public void HandlePictureResized(int width, int height)
        {
            pictureWidth = width;
            pictureHeight = height;
            ShowSourceImage();
        }

        public void SetProcessedAsSource()
        {
            originalSizeSource = resizedProcessed;
            ShowSourceImage();
        }
    }
}