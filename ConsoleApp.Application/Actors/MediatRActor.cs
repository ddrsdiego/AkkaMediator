using Akka.Actor;
using ConsoleApp.Application.Common;
using ConsoleApp.Application.Messages;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace ConsoleApp.Application.Actors
{
    public class MediatRActor : ReceiveActor
    {
        private readonly IMediator _mediator;

        public MediatRActor(IMediator mediator)
        {
            _mediator = mediator;

            Console.WriteLine($"{_mediator.GetType()} registrado com sucesso.");
            Receive<MediatRActorMessage>(message => MediatRActorMessageHadler(message));
        }

        public static Props CreateProps() => Props.Create<MediatRActor>();

        public async void MediatRActorMessageHadler(MediatRActorMessage message)
        {
            var commanType = Type.GetType(message.Type);
            var responseType = Type.GetType(((System.Reflection.TypeInfo)commanType).DeclaredProperties.ToList().FirstOrDefault(p => p.Name.Contains("Response")).PropertyType.AssemblyQualifiedName);

            var command = (IRequest<Response>)JsonConvert.DeserializeObject(message.Message, commanType);
            var response = await _mediator.Send(command);

            Console.WriteLine($"Processando response {response.HasError} - {DateTime.Now}");
        }
    }
}