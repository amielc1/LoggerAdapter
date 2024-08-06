using Microsoft.AspNetCore.Mvc;
using WebApplication.Model;

namespace WebApplication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        public MessageController()
        {
                
        }

        [HttpPost(nameof(Transfer))]
        public async Task<IActionResult> Transfer([FromBody] AirTrackMessage message)
        {
            try
            {
                _appTransaction.TransferFunds(request.FromAccountId, request.ToAccountId, request.Amount);

                return Ok();
            }
            catch (Exception ex)
            {
                // Handle exception and rollback changes if needed
                // Since we are not using a database transaction, ensure atomicity at the application level
                // You may need to implement compensation logic here
                // For example, if updating accountA succeeds but updating accountB fails, revert changes to accountA
                throw new Exception("Transaction failed. Rolling back changes.", ex);
            }
        }
    }
}
