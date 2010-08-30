using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
            this.SubjectiveSystem = system;
            var freeAlgos = AlgorithmsNames.All.Where(x => !system.Algorithms.Contains(x));
            this.sourceAlgos.Items.AddRange(freeAlgos.ToArray());
        }

        private void OnAddAlgoButtonClick(object sender, EventArgs e)
        {
            string algo = this.sourceAlgos.SelectedItem as string;
            if (algo == null)
            {
                return;
            }

            this.sourceAlgos.Items.Remove(algo);
            this.SubjectiveSystem.Algorithms.Add(algo);
        }

        private void OnRemoveAlgoButtonClick(object sender, EventArgs e)
        {
            string algo = this.algorithmsBindingSource.Current as string;
            if (algo == null)
            {
                return;
            }

            this.sourceAlgos.Items.Add(algo);
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
            var x = this.SubjectiveSystem.PrepareTrainingData("");
        }
    }
}
