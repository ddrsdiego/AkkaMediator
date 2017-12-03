using Akka.Actor;
using ConsoleApp.Application.Common;
using ConsoleApp.Application.Messages;
using ConsoleApp.Application.Responses;
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

        public async void MediatRActorMessageHadler(MediatRActorMessage message)
        {
            try
            {
                var commanType = Type.GetType(message.Type);
                var responseType = Type.GetType(((System.Reflection.TypeInfo)commanType).DeclaredProperties.ToList().FirstOrDefault(p => p.Name.Contains("Response")).PropertyType.AssemblyQualifiedName);

                var command = (IRequest<Response>)JsonConvert.DeserializeObject(message.Message, commanType);
                var response = await _mediator.Send(command);

                if (!response.HasError)
                    Console.WriteLine($"Processando response {((CreateNewUserResponse)response).UserId} {((CreateNewUserResponse)response).UserName} - {DateTime.Now}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}