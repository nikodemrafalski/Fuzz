using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FuzzyProject.Subjective;
using Logic;
using Logic.Subjective;

namespace FuzzyProject
{
    public partial class MainForm : Form, IMainView
    {
        private readonly MainViewPresenter presenter;
        private long operatonStartedTicks;

        public MainForm()
        {
            InitializeComponent();
            presenter = new MainViewPresenter();
            presenter.AttachView(this);
            presenter.HandlePictureResized(sourcePictureBox.Width, sourcePictureBox.Height);
            sourcePictureBox.IsSource = true;
            processedPictureBox.ChangeSourceRequested += OnChangeSourceRequested;
            parametersGridView.DataError += OnParametersGridViewDataError;
        }

        private void OnChangeSourceRequested(object sender, EventArgs args)
        {
            presenter.SetProcessedAsSource();
        }

        #region IMainView implementation

        public void DisplaySourceImage(Image image)
        {
            sourcePictureBox.Image = image;
            tabContainer.SelectedTab = sourceImageTabPage;
        }

        public void DisplayProcessedImage(Image image)
        {
            processedPictureBox.Image = image;
            tabContainer.SelectedTab = processedImageTabPage;
        }

        public void UpdateAlgorithmsList(IEnumerable<string> algoritmsNames)
        {
            algoritmsListCombo.DataSource = algoritmsNames;
        }

        public void UpdateParametersList(IEnumerable<AlgorithmParameter> paramerers)
        {
            algorithmParametersBindingSource.DataSource = paramerers;
        }

        public void StartNotifyingProgress()
        {
            operatonStartedTicks = DateTime.Now.Ticks;
            operationProgressBar.Enabled = true;
            operationProgressBar.Style = ProgressBarStyle.Marquee;
        }

        public void StopNotifyingProgress()
        {
            this.InvokeIfRequired(() =>
                                      {
                                          operationProgressBar.Style = ProgressBarStyle.Continuous;
                                          operationProgressBar.Enabled = false;
                                          var span = new TimeSpan(DateTime.Now.Ticks - operatonStartedTicks);
                                          operationTimerLabel.Text = span.ToString("G");
                                      });
        }


        public void DisplayEvaluationScores(double sourceScore, double processedScore)
        {
            sourceImageEvaluationScore.Text = sourceScore.ToString();
            processedImageEvaluationScore.Text = processedScore.ToString();
        }

        public void DisplayMeasures(double sourceScore, double processedScore)
        {
            fuzzSourceScore.Text = sourceScore.ToString();
            fuzzProcessedScore.Text = processedScore.ToString();
        }

        #endregion

        #region EventHandlers

        private void OnLoadImageToolStripMenuItemClick(object sender, EventArgs e)
        {
            presenter.LoadImage();
        }

        private void OnQuitToolStripMenuItemClick(object sender, EventArgs e)
        {
            presenter.CloseApplication();
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            presenter.HandlePictureResized(sourcePictureBox.Width, sourcePictureBox.Height);
        }

        private void OnProcessImageClick(object sender, EventArgs e)
        {
            presenter.ProcessImage();
        }

        private void OnAlgoritmsListSelectionChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;

            if (combo == null || presenter == null)
            {
                return;
            }

            presenter.ChangeSelectedAlgorithm(combo.SelectedValue as string);
        }

        private void OnParametersGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2)
            {
                return;
            }

            var parameter = algorithmParametersBindingSource.Current as AlgorithmParameter;
            if (parameter != null)
            {
                parameter.Value = parameter.DefaultValue;
                algorithmParametersBindingSource.ResetCurrentItem();
            }
        }

        private void OnParametersGridViewDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var grid = sender as DataGridView;
            string value = grid.CurrentCell.GetEditedFormattedValue(e.RowIndex, e.Context).ToString();
            grid.CurrentCell.Value = Double.Parse(value.Replace('.', ','));
        }

        #endregion

        private void OnNewToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (var nameDialog = new NameWindow())
            {
                if (nameDialog.ShowDialog() == DialogResult.OK)
                {
                    var system = SubjectiveSystem.CreateNew(nameDialog.Name);
                    ShowSystem(system);
                }
            }
        }

        private void ShowSystem(SubjectiveSystem system)
        {
            var newTab = new TabPage();
            newTab.Text = system.SystemName;
            var control = new SubjectiveSystemControl { Dock = DockStyle.Fill };
            control.Setup(system);
            newTab.Controls.Add(control);
            this.tabContainer.TabPages.Add(newTab);
            this.tabContainer.SelectedTab = newTab;
        }

        private void OnSaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (this.tabContainer.SelectedTab.Controls.Count == 0)
            {
                return;
            }

            var systemControl = this.tabContainer.SelectedTab.Controls[0] as SubjectiveSystemControl;
            if (systemControl == null)
            {
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = @"Pliki stanu (*.state)|*.state";
                dialog.AddExtension = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SubjectiveSystem.SaveState(systemControl.SubjectiveSystem,dialog.FileName);
                    this.tabContainer.TabPages.Remove(tabContainer.SelectedTab);
                }
            }
        }

        private void OnLoadToolStripMenuItemClick(object sender, EventArgs e)
        {
            SubjectiveSystem system = null;
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = @"Pliki stanu (*.state)|*.state";
                dialog.AddExtension = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                system = SubjectiveSystem.LoadState(dialog.FileName);
            }

            if (system != null)
            {
                ShowSystem(system);
            }
        }
    }
}