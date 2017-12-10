using ConsoleApp.Application.Common;
using System;
using System.Threading.Tasks;

namespace ConsoleApp.Application.Messages
{
    public interface IMediatRActorMessage
    {
        void ConfigureMediator(Action<IMediatorConfig> config);
        Task<Response> ExecuteCommands();
    }
}