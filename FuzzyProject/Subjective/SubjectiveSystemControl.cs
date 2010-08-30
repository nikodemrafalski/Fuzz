using System;
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
    }
}
