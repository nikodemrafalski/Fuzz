using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AForge.Imaging;
using Commons;
using Logic;
using Logic.Algorithms;
using Autofac;

namespace FuzzyProject
{
    public class MainViewPresenter
    {
        private Autofac.IContainer container;
        private IMainView view;
        private Bitmap originalSizeSource;
        private Bitmap resizedSource;
        private Bitmap resizedProcessed;
        private IAlgorithm selectedAlgoritm;
        private int pictureWidth;
        private int pictureHeight;

        public MainViewPresenter()
        {
            this.container = AppFacade.DI.Container;
        }

        public void AttachView(IMainView mainView)
        {
            this.view = mainView;
            this.view.UpdateAlgorithmsList(AlgorithmsNames.All);
        }

        public void ProcessImage()
        {
            if (this.resizedSource == null)
            {
                return;
            }

            this.view.StartNotifyingProgress();
            this.selectedAlgoritm.Input = new AlgorithmInput(this.resizedSource);
            this.selectedAlgoritm.ExecutionCompleted += OnAlgorithmExecutionCompleted;
            this.selectedAlgoritm.ProcessDataAsync();
        }

        private void OnAlgorithmExecutionCompleted(object sender, EventArgs e)
        {
            this.resizedProcessed = selectedAlgoritm.Output.Image.ToManagedImage();
            this.view.StoptNotifyingProgress();
            this.view.DisplayProcessedImage(this.resizedProcessed);
        }

        public void LoadImage()
        {
            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.originalSizeSource = new Bitmap(dialog.OpenFile()).ConvertToGrayScale();
                    this.ShowSourceImage();
                }
            }
        }

        private void ShowSourceImage()
        {
            if (this.originalSizeSource != null)
            {
                this.resizedSource = this.originalSizeSource.ResizeImage(this.pictureWidth, this.pictureHeight);
                view.DisplaySourceImage(this.resizedSource);
            }
        }

        public void CloseApplication()
        {
            var cancelEventArgs = new CancelEventArgs();
            Application.Exit(cancelEventArgs);
        }

        public void ChangeSelectedAlgorithm(string algorithmName)
        {
            this.selectedAlgoritm = container.Resolve<IAlgorithm>(algorithmName);
            this.view.UpdateParametersList(this.selectedAlgoritm.Parameters);
        }

        public void HandlePictureResized(int width, int height)
        {
            this.pictureWidth = width;
            this.pictureHeight = height;
            this.ShowSourceImage();
        }
    }
}