using System;
using System.ComponentModel.Composition;
using System.Xml.Linq;
using System.Linq;
using Autofac;
using Commons;
using Logic;

namespace FuzzyProject
{
    [Export(typeof(IModuleInitializer))]
    public class ModuleInitializer : IModuleInitializer
    {
        public void RegisterComponents(ContainerBuilder builder)
        {
            XDocument document = XDocument.Load("algorithms.xml");
            var root  =  document.Element("algorithms");
            foreach (var algorithmInfo in root.Elements("algorithm"))
            {
                string algorithmName = algorithmInfo.Attribute("name").Value;
                string algorithmType = algorithmInfo.Attribute("type").Value;
                Type algorithm = Type.GetType(algorithmType);
                builder.RegisterType(algorithm).Named<IAlgorithm>(algorithmName);
                Logic.Algorithms.AlgorithmsNames.All.Add(algorithmName);
            }
        }
    }
}