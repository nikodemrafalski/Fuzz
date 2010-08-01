using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Commons;
using Logic;
using Logic.Algorithms;
using Autofac;

namespace FuzzyProject
{
    public class MainViewPresenter
    {
        private Autofac.IContainer container;
        private IMainView view;
        private Bitmap originalSizeSource;
        private Bitmap originalSizeProcessed;
        private IAlgorithm selectedAlgoritm;

        public MainViewPresenter()
        {
            this.container = AppFacade.DI.Container;
        }

        public void AttachView(IMainView view)
        {
            this.view = view;
            this.view.UpdateAlgorithmsList(AlgorithmsNames.All);
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

        public void ChangeSelectedAlgorithm(string algorithmName)
        {
            this.selectedAlgoritm = container.Resolve<IAlgorithm>(algorithmName);
        }
    }
}