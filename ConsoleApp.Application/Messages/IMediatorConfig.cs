using System.Threading.Tasks;
using ConsoleApp.Application.Common;
using MediatR;

namespace ConsoleApp.Application.Messages
{
    public interface IMediatorConfig
    {
        void AddCommand(IRequest<Response> command);
        Task<Response> Exceute();
    }
}