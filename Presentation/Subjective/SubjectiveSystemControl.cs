using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using Commons;
using Presentation.MainView;
using Presentation.Properties;
using Logic;
using Logic.Algorithms;
using Logic.Subjective;

namespace Presentation.Subjective
{
    public partial class SubjectiveSystemControl : UserControl
    {
        public SubjectiveSystemControl()
        {
            InitializeComponent();
            this.processingMethodCombo.DataSource = EnumHelper.ToList(typeof(ProcessingMethod));
            processingMethodCombo.ValueMember = "Key";
            processingMethodCombo.DisplayMember = "Value";
        }

        public SubjectiveSystem SystemInstance { get; private set; }

        public void Setup(SubjectiveSystem system)
        {
            bindingSource.DataSource = system;
            algorithmsBindingSource.DataSource = system.Algorithms;
            observersBindingSource.DataSource = system.ObserversData;
            algorithmsBindingSource.CurrentItemChanged += OnCurrentAlgorithmChanged;
            SystemInstance = system;
            sourceAlgos.Items.AddRange(AlgorithmsNames.All.ToArray());
            RefreshImages();
        }

        private void OnCurrentAlgorithmChanged(object sender, EventArgs e)
        {
            var algorithmInfo = algorithmsBindingSource.Current as AlgorithmInfo;
            var mainView = AppFacade.DI.Container.Resolve<IMainView>();
            if (algorithmInfo == null)
            {
                mainView.UpdateParametersList(new List<AlgorithmParameter>());
                return;
            }

            mainView.UpdateParametersList(algorithmInfo.Parameters);
        }

        private void OnAddAlgoButtonClick(object sender, EventArgs e)
        {
            var algo = sourceAlgos.SelectedItem as string;
            if (algo == null)
            {
                return;
            }

            using (var nameWindow = new NameWindow())
            {
                nameWindow.ObjectName = algo;
                if (nameWindow.ShowDialog() == DialogResult.OK)
                {
                    var algorithmInfo = new AlgorithmInfo
                        {
                            AlgorithName = algo,
                            CustomName = nameWindow.ObjectName
                        };
                    algorithmInfo.Parameters = new List<AlgorithmParameter>();
                    foreach (AlgorithmParameter parameter in AppFacade.DI.Container.Resolve<IAlgorithm>(algo).Parameters
                        )
                    {
                        algorithmInfo.Parameters.Add(
                            new AlgorithmParameter(parameter.Name, parameter.DefaultValue)
                                {
                                    Value = parameter.DefaultValue
                                });
                    }

                    SystemInstance.Algorithms.Add(algorithmInfo);
                }
            }
        }

        private void OnRemoveAlgoButtonClick(object sender, EventArgs e)
        {
            var algo = algorithmsBindingSource.Current as AlgorithmInfo;
            if (algo == null)
            {
                return;
            }

            SystemInstance.Algorithms.Remove(algo);
        }

        private void RefreshImages()
        {
            imagesListView.Clear();

            foreach (string path in SystemInstance.ImagesPaths)
            {
                var item = new ListViewItem(Path.GetFileName(path));
                item.Tag = path;

                imagesListView.Items.Add(item);
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
                    AddImages(dialog.FileNames);
                }
            }
        }

        private void AddImages(IEnumerable<string> paths)
        {
            foreach (string path in paths)
            {
                if (SystemInstance.ImagesPaths.Contains(path) == false)
                {
                    SystemInstance.ImagesPaths.Add(path);
                }
            }

            RefreshImages();
        }

        private void OnRemoveImageButtonClick(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in imagesListView.SelectedItems)
            {
                SystemInstance.ImagesPaths.Remove(selectedItem.Tag as string);
            }

            RefreshImages();
        }

        private void OnTrainButtonClick(object sender, EventArgs e)
        {
            var observerData = observersBindingSource.Current as ObserverData;
            if (observerData == null || observerData.TrainingData.Count == 0)
            {
                return;
            }

            if (observerData.FullyTrained)
            {
                if (MessageBox.Show(Resources.SubsequentTrainingQuestion,
                                    Resources.SubsequentTrainingCaption, MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.SystemInstance.ResetData(observerData);
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
                    SystemInstance.AddObserver(nameWindow.ObjectName);
                }
            }

            observersBindingSource.ResetBindings(false);
        }

        private void OnRemoveObserverClick(object sender, EventArgs e)
        {
            var current = observersBindingSource.Current as ObserverData;
            if (current != null)
            {
                SystemInstance.ObserversData.Remove(current);
            }
        }

        private void OnInferingButtonCLick(object sender, EventArgs e)
        {
            var observerData = this.observersBindingSource.Current as ObserverData;
            if (observerData == null)
            {
                return;
            }

            this.SystemInstance.Infere(observerData);
        }

        private void OnProcessImageClick(object sender, EventArgs e)
        {
            var observerData = (ObserverData)this.observersBindingSource.Current;
            using (var processingWindow = new ProcessingWindow(this.SystemInstance,
                observerData,
                (ProcessingMethod)this.processingMethodCombo.SelectedValue))
            {
                processingWindow.ShowDialog();
            }
        }
    }
}