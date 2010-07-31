using System;
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
            this.presenter = new MainViewPresenter(this);
        }

        #region IMainView implementation

        public void DisplaySourceImage(Image image)
        {
            this.sourcePictureBox.Image = image.ResizeImage(
                this.sourcePictureBox.Width,
                this.sourcePictureBox.Height).ConvertToGrayScale();
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

        #endregion
    }
}
