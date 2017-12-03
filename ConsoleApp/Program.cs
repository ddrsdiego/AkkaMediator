using Akka.Actor;
using Akka.DI.Core;
using ConsoleApp.Application.Actors;
using ConsoleApp.Application.Commands;
using ConsoleApp.Application.Messages;
using ConsoleApp.IoC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = DependencyInjectionProxy.Container;
            var system = ActorSystem.Create("ActorSystemMain");

            container.AddActorsService(system);
            container.AddConsoleAppServices();

            var commands = new List<CreateNewUserCommand>();

            for (int i = 1; i <= 1000; i++)
            {
                commands.Add(new CreateNewUserCommand { Name = $"Usuario {i.ToString("000")}", Email = $"emaildousuario{i.ToString("000")}@hotmail.com", Password = "1234mudar" });
            }

            var actor = system.ActorOf(system.DI().Props<MediatRActor>(), nameof(MediatRActor));

            Parallel.ForEach(commands, cmd =>
            {
                var type = cmd.GetType().AssemblyQualifiedName;
                var message = JsonConvert.SerializeObject(cmd, cmd.GetType(), Formatting.Indented, new JsonSerializerSettings());

                actor.Tell(new MediatRActorMessage(type, message));
            });

            Parallel.ForEach(commands, cmd =>
            {
                var type = cmd.GetType().AssemblyQualifiedName;
                var message = JsonConvert.SerializeObject(cmd, cmd.GetType(), Formatting.Indented, new JsonSerializerSettings());

                actor.Tell(new MediatRActorMessage(type, message));
            });

            Console.WriteLine($"Aplicação executada com sucesso {DateTime.Now}!");
            Console.Read();
        }
    }
}
