using Akka.Actor;
using Akka.DI.Core;
using ConsoleApp.Application.Actors;
using ConsoleApp.Application.Commands;
using ConsoleApp.Application.Messages;
using ConsoleApp.IoC;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Aplicação iniciada com sucesso {DateTime.Now}!");

            var container = DependencyInjectionProxy.Container;
            var system = ActorSystem.Create("ActorSystemMain");

            container.AddActorsService(system);
            container.AddConsoleAppServices();

            var commands = new List<CreateNewUserCommand>();

            for (int i = 1; i <= 3; i++)
            {
                commands.Add(new CreateNewUserCommand { Name = $"Usuario {i.ToString("000")}", Email = $"emaildousuario{i.ToString("000")}@hotmail.com", Password = "1234mudar" });
            }

            var actor = system.ActorOf(system.DI().Props<MediatRActor>(), nameof(MediatRActor));

            foreach (var cmd in commands)
            {
                var actorMessage = new MediatRActorMessage(container.Resolve<IMediator>());
                actorMessage.ConfigureMediator(config => { config.AddCommand(cmd); });

                actor.Tell(actorMessage);
            }

            Console.WriteLine($"10 usuários criados com sucesso {DateTime.Now}!");

            Parallel.ForEach(commands, cmd =>
            {
                var actorMessage = new MediatRActorMessage(container.Resolve<IMediator>());
                actorMessage.ConfigureMediator(config => { config.AddCommand(cmd); });

                actor.Tell(actorMessage);
            });

            Console.WriteLine($"10 usuários criados com sucesso {DateTime.Now}!");

            Parallel.ForEach(commands, cmd =>
            {
                var actorMessage = new MediatRActorMessage(container.Resolve<IMediator>());
                actorMessage.ConfigureMediator(x => { x.AddCommand(cmd); });

                actor.Tell(actorMessage);
            });

            Console.WriteLine($"10 usuários criados com sucesso {DateTime.Now}!");

            Console.WriteLine($"Aplicação executada com sucesso {DateTime.Now}!");
            Console.Read();
        }
    }
}
