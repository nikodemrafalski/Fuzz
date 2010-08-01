using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Commons;

namespace FuzzyProject
{
    public partial class MainForm : Form, IMainView
    {
        private readonly MainViewPresenter presenter;

        public MainForm()
        {
            InitializeComponent();
            this.presenter = new MainViewPresenter();
            this.presenter.AttachView(this);
        }

        #region IMainView implementation

        public void DisplaySourceImage(Image image)
        {
            this.sourcePictureBox.Image = image.ResizeImage(
                this.sourcePictureBox.Width,
                this.sourcePictureBox.Height);
        }

        public void DisplayProcessedImage(Image image)
        {
            this.processedPictureBox.Image = image.ResizeImage(
                this.processedPictureBox.Width,
                this.processedPictureBox.Height);
        }

        public void UpdateAlgorithmsList(IEnumerable<string> algoritmsNames)
        {
            this.algoritmsListCombo.DataSource = algoritmsNames;
        }

        public void StartNotifyingProgress()
        {
            this.operationProgressBar.Enabled = true;
            this.operationProgressBar.Style = ProgressBarStyle.Marquee;
        }

        public void StoptNotifyingProgress()
        {
            this.InvokeIfRequired(() =>
                                      {
                                          this.operationProgressBar.Style = ProgressBarStyle.Continuous;
                                          this.operationProgressBar.Enabled = false;
                                      });
        }

        #endregion

        #region EventHandlers

        private void OnLoadImageToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.presenter.LoadImage();
        }

        private void OnQuitToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.presenter.CloseApplication();
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            this.presenter.HandleResize();
        }

        private void OnProcessImageClick(object sender, EventArgs e)
        {
            this.presenter.ProcessImage();
        }

        private void OnAlgoritmsListSelectionChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;

            if (combo == null || this.presenter == null)
            {
                return;
            }

            this.presenter.ChangeSelectedAlgorithm(combo.SelectedValue as string);
        }

        #endregion
    }
}
