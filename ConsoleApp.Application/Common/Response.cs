using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Application.Common
{
    public abstract class Response
    {
        private IList<ResponseMessage> _erros;

        protected Response()
        {
            _erros = new List<ResponseMessage>();
        }

        public bool HasError
        {
            get
            {
                return Errors.Any();
            }
        }

        private void AddInternalMessage(string message, ResponseType responseType)
        {
            if (_erros != null && _erros.Any(x => x.ResponseType == ResponseType.Sucess))
                _erros.Clear();

            switch (responseType)
            {
                case ResponseType.Warning:
                    _erros.Add(new ResponseMessage(message, responseType));
                    break;
                case ResponseType.Error:
                    _erros.Add(new ResponseMessage(message, responseType));
                    break;
                default:
                    break;
            }
        }

        public void AddMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
                AddInternalMessage(message, ResponseType.Warning);
        }

        public void AddMessageError(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
                AddInternalMessage(errorMessage, ResponseType.Error);
        }

        public IList<ResponseMessage> Errors
        {
            get { return _erros; }
            private set { _erros = new List<ResponseMessage>(value); }
        }
    }

    public sealed class ResponseMessage
    {
        public ResponseMessage(string message, ResponseType responseType)
        {
            Message = message;
            ResponseType = responseType;
        }

        public string Message { get; }
        public ResponseType ResponseType { get; }
    }

    public enum ResponseType
    {
        Sucess,
        Warning,
        Error
    }
}
