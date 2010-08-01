using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using Autofac;

namespace Commons
{
    public static class AppFacade
    {
        public static class DI
        {
            public static IContainer Container;

            public static ContainerBuilder Builder { get; private set; }

            public static void CreateBuilder()
            {
                var builder = new ContainerBuilder();
                var mefContainer = new CompositionContainer(GetApplicationRoot());

                foreach (var initializer in mefContainer.GetExportedValues<IModuleInitializer>())
                {
                    initializer.RegisterComponents(builder);
                }

                Builder = builder;
            }
        }

        private static DirectoryCatalog GetApplicationRoot()
        {
            return new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}