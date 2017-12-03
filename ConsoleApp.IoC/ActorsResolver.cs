using Akka.Actor;
using Akka.DI.CastleWindsor;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ConsoleApp.Application.Actors;

namespace ConsoleApp.IoC
{
    public static class ActorsResolver
    {
        public static void AddActorsService(this IWindsorContainer container, ActorSystem actorSystem)
        {
            container.Register(Component.For<MediatRActor>());
            var resolver = new WindsorDependencyResolver(container, actorSystem);
        }
    }
}
