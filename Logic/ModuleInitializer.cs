using System;
using System.ComponentModel.Composition;
using Autofac;
using Commons;
using Logic.Algorithms;

namespace Logic
{
    [Export(typeof(IModuleInitializer))]
    public class ModuleInitializer : IModuleInitializer
    {
        public void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterType<FuzzyClassifierEdgeDetector>().Named<IAlgorithm>("FuzzyClassifierEdgeDetector");
            AlgorithmsNames.All.Add("FuzzyClassifierEdgeDetector");
        }
    }
}