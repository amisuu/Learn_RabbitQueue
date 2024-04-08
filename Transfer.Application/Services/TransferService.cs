using Domain.Core.Bus;
using Transfer.Application.Interfaces;
using Transfer.Domain.Interfaces;
using Transfer.Domain.Models;

namespace Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly IEventBus _eventBus;
        private readonly ITransferRepository _transferRepository;

        public TransferService(IEventBus eventBus,
                               ITransferRepository transferRepository)
        {
            _eventBus = eventBus;
            _transferRepository = transferRepository;
        }
        public IEnumerable<TransferLog> GetTransfersLogs()
        {
            return _transferRepository.GetTransfersLogs();
        }
    }
}
