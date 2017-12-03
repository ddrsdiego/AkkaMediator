using ConsoleApp.Application.Common;
using System;

namespace ConsoleApp.Application.Responses
{
    public class CreateNewUserResponse : Response
    {
        public Guid UserId { get; set; }
    }
}