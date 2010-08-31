using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Commons;
using Autofac;
using FuzzyProject.Properties;
using FuzzyProject.Subjective;
using Logic;
using Logic.Algorithms;
using Logic.Subjective;

namespace FuzzyProject
{
    public partial class SubjectiveSystemControl : UserControl
    {
        public SubjectiveSystemControl()
        {
            InitializeComponent();
        }

        public SubjectiveSystem SubjectiveSystem { get; private set; }

        public void Setup(SubjectiveSystem system)
        {
            this.bindingSource.DataSource = system;
            this.observersBindingSource.DataSource = system.ObserversData;
            this.SubjectiveSystem = system;
            this.sourceAlgos.Items.AddRange(AlgorithmsNames.All.ToArray());
            this.RefreshImages();
        }

        private void OnAddAlgoButtonClick(object sender, EventArgs e)
        {
            string algo = this.sourceAlgos.SelectedItem as string;
            if (algo == null)
            {
                return;
            }

            using (var nameWindow = new NameWindow())
            {
                nameWindow.Name = algo;
                if (nameWindow.ShowDialog() == DialogResult.OK)
                {
                    var algorithmInfo = new AlgorithmInfo
                        {
                            AlgorithName = algo,
                            CustomName = nameWindow.Name,
                            Parameters = AppFacade.DI.Container.Resolve<IAlgorithm>(algo).Parameters
                        };

                    this.SubjectiveSystem.Algorithms.Add(algorithmInfo);
                }
            }
        }

        private void OnRemoveAlgoButtonClick(object sender, EventArgs e)
        {
            var algo = this.algorithmsBindingSource.Current as AlgorithmInfo;
            if (algo == null)
            {
                return;
            }

            this.SubjectiveSystem.Algorithms.Remove(algo);
        }

        private void RefreshImages()
        {
            this.imagesListView.Clear();

            foreach (string path in this.SubjectiveSystem.ImagesPaths)
            {
                var item = new ListViewItem(System.IO.Path.GetFileName(path));
                item.Tag = path;

                this.imagesListView.Items.Add(item);
            }
        }

        private void OnSelectImagesClick(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                dialog.Filter = @"(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.AddImages(dialog.FileNames);
                }
            }
        }

        private void AddImages(IEnumerable<string> paths)
        {
            foreach (string path in paths)
            {
                if (this.SubjectiveSystem.ImagesPaths.Contains(path) == false)
                {
                    this.SubjectiveSystem.ImagesPaths.Add(path);
                }
            }

            this.RefreshImages();
        }

        private void OnRemoveImageButtonClick(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in imagesListView.SelectedItems)
            {
                this.SubjectiveSystem.ImagesPaths.Remove(selectedItem.Tag as string);
            }

            this.RefreshImages();
        }

        private void OnTrainButtonClick(object sender, EventArgs e)
        {
            var observerData = this.observersBindingSource.Current as ObserverData;
            if (observerData == null || observerData.TrainingData.Count == 0)
            {
                return;
            }

            if (observerData.FullyTrained)
            {
                if (MessageBox.Show(Resources.SubsequentTrainingQuestion,
                                Resources.SubsequentTrainingCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    observerData.ResetTraining();
                }
                else
                {
                    return;
                }
            }

            var trainingWindow = new TrainingWindow();
            trainingWindow.AttachData(observerData.TrainingData);
            trainingWindow.ShowDialog();
            observerData.CheckTrainingStatus();
        }

        private void OnAddObserverClick(object sender, EventArgs e)
        {
            using (var nameWindow = new NameWindow())
            {
                if (nameWindow.ShowDialog() == DialogResult.OK)
                {
                    this.SubjectiveSystem.AddObserver(nameWindow.Name);
                }
            }

            this.observersBindingSource.ResetBindings(false);
        }

        private void OnRemoveObserverClick(object sender, EventArgs e)
        {
            var current = this.observersBindingSource.Current as ObserverData;
            if (current != null)
            {
                this.SubjectiveSystem.ObserversData.Remove(current);
            }
        }
    }
}
