using Microsoft.AspNetCore.Mvc;
using Transfer.Application.Interfaces;
using Transfer.Domain.Models;

namespace Transfer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            return Ok(_transferService.GetTransfersLogs());
        }

        /* [HttpPost]
         public IActionResult Post([FromBody] AccountTransfer accountTransfer)
         {
             //_transferService.Transfer(accountTransfer);

             //return Ok(accountTransfer);
         }*/
    }
}
