using System;
using System.Windows.Forms;

namespace FuzzyProject.Subjective
{
    public partial class NameWindow : Form
    {
        public NameWindow()
        {
            InitializeComponent();
        }

        public string ObjectName { get; set; }

        protected override void OnShown(EventArgs e)
        {
            textBox1.Text = ObjectName;
        }

        private void OnButton1Click(object sender, EventArgs e)
        {
            ObjectName = textBox1.Text;
            DialogResult = DialogResult.OK;
        }

        private void OnButton2Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}