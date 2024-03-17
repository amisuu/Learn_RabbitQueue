using MediatR;
using System.Net.WebSockets;

namespace Domain.Core.Events
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }
        public string MessageDescription { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
