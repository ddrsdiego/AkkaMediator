using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using ConsoleApp.Application.Handlers;

namespace ConsoleApp.IoC
{
    public static class HandlersResolver
    {
        public static void RegisterHandlers(this IKernel container)
        {
            container.Register(
                Classes.FromAssemblyContaining<CreateNewUserHandler>().Pick().WithServiceAllInterfaces().LifestyleSingleton()
                );
        }
    }
}
