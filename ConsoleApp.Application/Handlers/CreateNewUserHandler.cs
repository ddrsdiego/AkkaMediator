using ConsoleApp.Application.Commands;
using ConsoleApp.Application.Common;
using MediatR;
using System;
using System.Threading;

namespace ConsoleApp.Application.Handlers
{
    public class CreateNewUserHandler : IRequestHandler<CreateNewUserCommand, Response>
    {
        public CreateNewUserHandler()
        {
        }

        public Response Handle(CreateNewUserCommand message)
        {
            var response = message.Response;

            response.UserId = Guid.NewGuid();
            response.UserName = message.Name;

            Console.WriteLine($"Registrando Usuario {message.Name}");

            Thread.Sleep(2000);

            return response;
        }
    }
}