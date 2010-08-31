using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FuzzyProject.Subjective
{
    public partial class NameWindow : Form
    {
        public NameWindow()
        {
            InitializeComponent();
        }

        public string Name { get; set; }

        protected override void OnShown(EventArgs e)
        {
            this.textBox1.Text = Name;
        }

        private void OnButton1Click(object sender, EventArgs e)
        {
            this.Name = this.textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void OnButton2Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
