using Castle.Core.Configuration;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using MediatR;
using System.Collections.Generic;

namespace ConsoleApp.IoC
{
    public class MediatorFacility : IFacility
    {
        public void Init(IKernel kernel, IConfiguration facilityConfig)
        {
            kernel.Resolver.AddSubResolver(new CollectionResolver(kernel));
            kernel.AddHandlersFilter(new ContravariantFilter());

            kernel.Register
            (
                Component.For<IMediator>().ImplementedBy<Mediator>().LifestyleSingleton(),
                Component.For<SingleInstanceFactory>().UsingFactoryMethod<SingleInstanceFactory>(k => t => k.Resolve(t)).LifestyleSingleton(),
                Component.For<MultiInstanceFactory>().UsingFactoryMethod<MultiInstanceFactory>(k => t => (IEnumerable<object>)k.ResolveAll(t)).LifestyleSingleton()
            );
        }

        public void Terminate()
        {
        }
    }
}
