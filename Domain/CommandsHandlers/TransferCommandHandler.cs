using Banking.Domain.Commands;
using Banking.Domain.Events;
using Domain.Core.Bus;
using MediatR;

namespace Banking.Domain.CommandsHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _eventBus;

        public TransferCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            //publish event to rabbit
            _eventBus.Publish(new TransferCreatedEvent(
                request.From,
                request.To,
                request.Amount));

            return Task.FromResult(true);
        }
    }
}
