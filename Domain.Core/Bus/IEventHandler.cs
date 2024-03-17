using Domain.Core.Events;

namespace Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler //<in TEvent> takes any type of event
        where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
