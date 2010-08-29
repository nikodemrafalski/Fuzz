using System;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Autofac;

namespace Commons
{
    public static class AppFacade
    {
        private static AggregateCatalog GetCatalog()
        {
            var catalog = new AggregateCatalog(new AssemblyCatalog(Assembly.GetEntryAssembly()));
            catalog.Catalogs.Add(new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory));
            return catalog;
        }

        #region Nested type: DI

        public static class DI
        {
            public static IContainer Container;

            public static ContainerBuilder Builder { get; private set; }

            public static void CreateBuilder()
            {
                var builder = new ContainerBuilder();
                var mefContainer = new CompositionContainer(GetCatalog());

                foreach (IModuleInitializer initializer in mefContainer.GetExportedValues<IModuleInitializer>())
                {
                    initializer.RegisterComponents(builder);
                }

                Builder = builder;
            }
        }

        #endregion
    }
}