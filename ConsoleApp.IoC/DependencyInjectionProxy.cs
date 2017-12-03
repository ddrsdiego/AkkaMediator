using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace ConsoleApp.IoC
{
    public static class DependencyInjectionProxy
    {
        public static IWindsorContainer Container { get; private set; }

        static DependencyInjectionProxy()
        {
            Container = new WindsorContainer();
        }

        public static void RegisterSingleton<TContract, TType>() where TType : class
        {
            if (!Container.Kernel.HasComponent(typeof(TContract)))
            {
                Container.Register(
                    Component.For(typeof(TContract)).ImplementedBy(typeof(TType))
                );
            }
        }

        public static void RegisterPerWebRequest<TContract, TType>() where TType : class
        {
            if (!Container.Kernel.HasComponent(typeof(TContract)))
            {
                Container.Register(
                     Component.For(typeof(TContract)).ImplementedBy(typeof(TType)).LifestylePerWebRequest()
                );
            }
        }

        public static TType Resolve<TType>()
        {
            return Container.Resolve<TType>();
        }
    }
}
