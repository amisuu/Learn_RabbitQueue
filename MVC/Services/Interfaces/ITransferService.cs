using MVC.Models.Dto;

namespace MVC.Services.Interfaces
{
    public interface ITransferService
    {
        Task Transfer(TransferDto transferDto);
    }
}
