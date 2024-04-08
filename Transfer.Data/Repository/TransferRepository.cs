using Microsoft.EntityFrameworkCore;
using Transfer.Data.Context;
using Transfer.Domain.Interfaces;
using Transfer.Domain.Models;

namespace Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _transferDbContext;

        public TransferRepository(TransferDbContext transferDbContext)
        {
            _transferDbContext = transferDbContext;
        }

        public IEnumerable<TransferLog> GetTransfersLogs()
        {
            return _transferDbContext.TransferLogs;
        }

        public void Add(TransferLog transferLog)
        {
            _transferDbContext.TransferLogs.Add(transferLog);
            _transferDbContext.SaveChanges();
        }
    }
}
