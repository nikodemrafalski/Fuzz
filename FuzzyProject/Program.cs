using System;
using System.Windows.Forms;
using Commons;

namespace FuzzyProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppFacade.DI.CreateBuilder();
            AppFacade.DI.Container = AppFacade.DI.Builder.Build();

            Application.Run(new MainForm());
        }
    }
}