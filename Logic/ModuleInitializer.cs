using System.ComponentModel.Composition;
using Autofac;
using Commons;
using Logic.Algorithms;

namespace Logic
{
    [Export(typeof (IModuleInitializer))]
    public class ModuleInitializer : IModuleInitializer
    {
        #region IModuleInitializer Members

        public void RegisterComponents(ContainerBuilder builder)
        {
        }

        #endregion
    }
}