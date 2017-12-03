using ConsoleApp.Application.Responses;
using MediatR;
using System;

namespace ConsoleApp.Application.Commands
{
    public class CreateNewUserCommand : IRequest<CreateNewUserResponse>
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public CreateNewUserResponse Response { get; } = new CreateNewUserResponse();
    }
}
