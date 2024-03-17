using Domain.Core.Events;

namespace Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime TimeStamp { get; protected set; } //only class which inherit can set this property
        protected Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
