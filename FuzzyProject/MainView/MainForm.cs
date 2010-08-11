using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Commons;
using Logic;

namespace FuzzyProject
{
    public partial class MainForm : Form, IMainView
    {
        private readonly MainViewPresenter presenter;
        private long operatonStartedTicks;

        public MainForm()
        {
            InitializeComponent();
            this.presenter = new MainViewPresenter();
            this.presenter.AttachView(this);
            this.presenter.HandlePictureResized(this.sourcePictureBox.Width, this.sourcePictureBox.Height);
        }

        #region IMainView implementation

        public void DisplaySourceImage(Image image)
        {
            this.sourcePictureBox.Image = image;
        }

        public void DisplayProcessedImage(Image image)
        {
            this.processedPictureBox.Image = image;
            this.tabContainer.SelectedTab = this.processedImageTabPage;
        }

        public void UpdateAlgorithmsList(IEnumerable<string> algoritmsNames)
        {
            this.algoritmsListCombo.DataSource = algoritmsNames;
        }

        public void UpdateParametersList(IEnumerable<AlgorithmParameter> paramerers)
        {
            this.algorithmParametersBindingSource.DataSource = paramerers;
        }

        public void StartNotifyingProgress()
        {
            this.operatonStartedTicks = DateTime.Now.Ticks;
            this.operationProgressBar.Enabled = true;
            this.operationProgressBar.Style = ProgressBarStyle.Marquee;
        }

        public void StoptNotifyingProgress()
        {
            this.InvokeIfRequired(() =>
                                      {
                                          this.operationProgressBar.Style = ProgressBarStyle.Continuous;
                                          this.operationProgressBar.Enabled = false;
                                          var span = new TimeSpan(DateTime.Now.Ticks - this.operatonStartedTicks);
                                          this.operationTimerLabel.Text = span.ToString("G");
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
            this.presenter.HandlePictureResized(this.sourcePictureBox.Width, this.sourcePictureBox.Height);
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

        private void OnParametersGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var parameter = this.algorithmParametersBindingSource.Current as AlgorithmParameter;
            if (parameter != null)
            {
                parameter.Value = parameter.DefaultValue;
                this.algorithmParametersBindingSource.ResetCurrentItem();
            }
        }

        #endregion
    }
}
