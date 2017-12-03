using Akka.DI.CastleWindsor;
using Castle.MicroKernel;
using Castle.Windsor;

namespace ConsoleApp.IoC
{
    public static class ConsoleAppContainers
    {
        public static void AddConsoleAppServices(this IWindsorContainer container)
        {
            container.Kernel.RegisterHandlers();
            container.Kernel.RegisterFrameworkContainer();
        }
    }
}
