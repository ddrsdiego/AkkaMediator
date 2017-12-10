using ConsoleApp.Application.Common;
using MediatR;
using System;
using System.Threading.Tasks;

namespace ConsoleApp.Application.Messages
{
    public class MediatRActorMessage : IMediatRActorMessage
    {
        private readonly IMediator _mediator;
        private MediatorConfig _mediatorConfig;

        public MediatRActorMessage(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Response> ExecuteCommands()
        {
            var response = await _mediatorConfig.Exceute();

            return response;
        }

        public void ConfigureMediator(Action<IMediatorConfig> config)
        {
            _mediatorConfig = new MediatorConfig(_mediator);
            config.Invoke(_mediatorConfig);
        }
    }

    public class MediatorConfig : IMediatorConfig
    {
        private readonly IMediator _mediator;
        private IRequest<Response> _command;

        public MediatorConfig(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void AddCommand(IRequest<Response> command)
        {
            if (command != null)
            {
                _command = command;
            }
        }

        public async Task<Response> Exceute()
        {
            try
            {
                var response = await _mediator.Send(_command);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
