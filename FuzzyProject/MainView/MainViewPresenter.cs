using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FuzzyProject
{
    public class MainViewPresenter
    {
        private readonly IMainView view;
        private Bitmap originalSizeSource;
        private Bitmap originalSizeProcessed;

        public MainViewPresenter(IMainView view)
        {
            this.view = view;
        }

        public void LoadImage()
        {
            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.originalSizeSource = new Bitmap(dialog.OpenFile());
                    view.DisplaySourceImage(originalSizeSource);
                }
            }
        }

        public void HandleResize()
        {
            if (this.originalSizeSource != null)
            {
                view.DisplaySourceImage(this.originalSizeSource);
            }

            if (this.originalSizeProcessed != null)
            {
                //
            }
        }

        public void CloseApplication()
        {
            var cancelEventArgs = new CancelEventArgs();
            Application.Exit(cancelEventArgs);
        }
    }
}