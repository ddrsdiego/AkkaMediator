namespace ConsoleApp.Application.Messages
{
    public class MediatRActorMessage
    {
        public MediatRActorMessage(string type, string message)
        {
            Type = type;
            Message = message;
        }

        public string Type { get; }
        public string Message { get; }
    }
}
