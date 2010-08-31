using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using AForge.Imaging;
using Autofac;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FuzzyProject.Properties;
using Logic;
using Logic.Subjective;
using Commons;

namespace FuzzyProject.Subjective
{
    public partial class TrainingWindow : Form
    {
        private TrainingData currentData;
        private int totalData;
        private int currentPosition;
        private IList<TrainingData> data;
        private Bitmap currentPicture;

        public TrainingWindow()
        {
            InitializeComponent();
        }

        public void AttachData(IList<TrainingData> trainingData)
        {
            this.data = trainingData;
            currentData = data.First(x => x.UserScore == null);
            currentPosition = data.IndexOf(currentData);
            totalData = data.Count;
            this.progressBar.Maximum = totalData;
            this.progressBar.Value = currentPosition;
            this.currentPicture = new Bitmap(this.currentData.ImagePath).ConvertToGrayScale();
        }

        protected override void OnShown(EventArgs e)
        {
            this.DisplayData();
        }

        private void SetScore(byte score)
        {
            this.currentData.UserScore = score;
        }

        private void DisplayData()
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Bitmap resizedSource = currentPicture.ResizeImage(this.sourcePicture.Width, this.sourcePicture.Height);
            this.sourcePicture.Image = resizedSource;
            var algorith = AppFacade.DI.Container.Resolve<IAlgorithm>(this.currentData.AlgorithmName);
            this.progressBar.Style = ProgressBarStyle.Marquee;
            algorith.Input = new AlgorithmInput(UnmanagedImage.FromManagedImage(resizedSource));
            algorith.ExecutionCompleted += OnAlgorithExecutionCompleted;
            algorith.ProcessDataAsync();
        }

        private void OnAlgorithExecutionCompleted(object sender, EventArgs e)
        {
            var algorithm = (IAlgorithm) sender;
            this.InvokeIfRequired(() =>
                {
                    this.processedImage.Image = algorithm.Output.Image.ToManagedImage();
                    this.progressBar.Value = currentPosition;
                    this.progressBar.Style = ProgressBarStyle.Continuous;
                    this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                });
        }

        private void OnScoreButtonClick(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            byte score = Convert.ToByte(button.Tag);
            this.SetScore(score);
            this.nextButton.Enabled = true;
        }

        private void OnNextClick(object sender, EventArgs e)
        {
            if (this.currentPosition == totalData - 1)
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
                return;
            }

            this.nextButton.Enabled = false;
            currentPosition++;
            if (currentPosition == totalData - 1)
            {
                this.nextButton.Text = Resources.FinishCaption;    
            }

            this.currentData = data[currentPosition];
            this.currentPicture = new Bitmap(this.currentData.ImagePath).ConvertToGrayScale();
            DisplayData();
        }

        private void OnTrainingWindowResizeEnd(object sender, EventArgs e)
        {
            this.DisplayData();
        }
    }
}
