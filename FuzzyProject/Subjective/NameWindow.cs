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

        public string ObjectName { get; set; }

        protected override void OnShown(EventArgs e)
        {
            this.textBox1.Text = ObjectName;
        }

        private void OnButton1Click(object sender, EventArgs e)
        {
            this.ObjectName = this.textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void OnButton2Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
