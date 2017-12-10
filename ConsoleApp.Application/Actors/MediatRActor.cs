using Akka.Actor;
using ConsoleApp.Application.Messages;
using ConsoleApp.Application.Responses;
using MediatR;
using System;

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
                var response = await message.ExecuteCommands();

                if (response is CreateNewUserResponse)
                {
                    var createNewUserResponse = (CreateNewUserResponse)response;
                    Console.WriteLine($"{createNewUserResponse.UserName} - {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}