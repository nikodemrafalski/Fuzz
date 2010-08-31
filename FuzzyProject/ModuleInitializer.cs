using System;
using System.ComponentModel.Composition;
using System.Xml.Linq;
using Autofac;
using Commons;
using Logic;
using Logic.Algorithms;

namespace FuzzyProject
{
    [Export(typeof (IModuleInitializer))]
    public class ModuleInitializer : IModuleInitializer
    {
        #region IModuleInitializer Members

        public void RegisterComponents(ContainerBuilder builder)
        {
            XDocument document = XDocument.Load("algorithms.xml");
            XElement root = document.Element("algorithms");
            foreach (XElement algorithmInfo in root.Elements("algorithm"))
            {
                string algorithmName = algorithmInfo.Attribute("name").Value;
                string algorithmType = algorithmInfo.Attribute("type").Value;
                Type algorithm = Type.GetType(algorithmType);
                builder.RegisterType(algorithm).Named<IAlgorithm>(algorithmName);
                AlgorithmsNames.All.Add(algorithmName);
            }

            builder.RegisterInstance(new MainForm()).As<IMainView>();
        }

        #endregion
    }
}