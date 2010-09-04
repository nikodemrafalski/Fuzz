using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AForge.Imaging;
using Autofac;
using Commons;
using Logic;
using Logic.Subjective;
using Presentation.Properties;

namespace Presentation.Subjective
{
    public partial class TrainingWindow : Form
    {
        private TrainingData currentData;
        private Bitmap currentPicture;
        private int currentPosition;
        private IList<TrainingData> data;
        private int totalData;

        public TrainingWindow()
        {
            InitializeComponent();
        }

        public void AttachData(IList<TrainingData> trainingData)
        {
            data = trainingData;
            currentData = data.First(x => x.UserScore == null);
            currentPosition = data.IndexOf(currentData);
            totalData = data.Count;
            progressBar.Maximum = totalData;
            progressBar.Value = currentPosition;
            currentPicture = new Bitmap(currentData.ImagePath).ConvertToGrayScale();
        }

        protected override void OnShown(EventArgs e)
        {
            DisplayData();
        }

        private void SetScore(byte score)
        {
            currentData.UserScore = score;
        }

        private void DisplayData()
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Bitmap resizedSource = currentPicture.ResizeImage(sourcePicture.Width, sourcePicture.Height);
            sourcePicture.Image = resizedSource;
            processedImage.Image = null;
            var algorithm = AppFacade.DI.Container.Resolve<IAlgorithm>(currentData.AlgorithmInfo.AlgorithName);
            algorithm.SetParameters(currentData.AlgorithmInfo.Parameters);
            progressBar.Style = ProgressBarStyle.Marquee;
            algorithm.Input = new AlgorithmInput(UnmanagedImage.FromManagedImage(resizedSource));
            algorithm.ExecutionCompleted += OnAlgorithExecutionCompleted;
            algorithm.ProcessDataAsync();
        }

        private double GetSystemScore(AlgorithmInput input, AlgorithmResult result)
        {
            var inputStatistics = Statistics.FromUnmanagedImage(input.Image);
            var outputStatistics = Statistics.FromUnmanagedImage(result.Image);

            double inputScore = inputStatistics.GetContrastMeasure();
            double resultScore = outputStatistics.GetContrastMeasure();

            double finalScore = resultScore/inputScore;
            return finalScore;
        }

        private void OnAlgorithExecutionCompleted(object sender, EventArgs e)
        {
            var algorithm = (IAlgorithm) sender;
            this.currentData.SystemScore = this.GetSystemScore(algorithm.Input, algorithm.Output);
            this.InvokeIfRequired(() =>
                {
                    processedImage.Image = algorithm.Output.Image.ToManagedImage();
                    progressBar.Value = currentPosition;
                    progressBar.Style = ProgressBarStyle.Continuous;
                    FormBorderStyle = FormBorderStyle.SizableToolWindow;
                });
        }

        private void OnScoreButtonClick(object sender, EventArgs eventArgs)
        {
            var button = (Button) sender;
            byte score = Convert.ToByte(button.Tag);
            SetScore(score);
            nextButton.Enabled = true;
        }

        private void OnNextClick(object sender, EventArgs e)
        {
            if (currentPosition == totalData - 1)
            {
                Close();
                DialogResult = DialogResult.OK;
                return;
            }

            nextButton.Enabled = false;
            currentPosition++;
            if (currentPosition == totalData - 1)
            {
                nextButton.Text = Resources.FinishCaption;
            }

            currentData = data[currentPosition];
            currentPicture = new Bitmap(currentData.ImagePath).ConvertToGrayScale();
            DisplayData();
        }

        private void OnTrainingWindowResizeEnd(object sender, EventArgs e)
        {
            DisplayData();
        }
    }
}