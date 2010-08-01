using Autofac;

namespace Commons
{
    public interface IModuleInitializer
    {
        void RegisterComponents(ContainerBuilder builder);
    }
}