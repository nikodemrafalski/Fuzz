using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Commons;

namespace FuzzyProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppFacade.DI.CreateBuilder();
            AppFacade.DI.Container = AppFacade.DI.Builder.Build();

            Application.Run(new MainForm());
        }
    }
}
