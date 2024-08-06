using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplicationLogger.Model;
using XLogger;
using XLogger.LogModel;

namespace WebApplicationLogger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebLoggerController : ControllerBase
    {
          
        private readonly  IMessagesLog _logger;

        public WebLoggerController(IMessagesLog logger)
        {
            _logger = logger;
        }

        [HttpPost(nameof(LogMessage))]
        public async Task<IActionResult> LogMessage([FromBody] AirTrackMessage airTrackMessage)
        {
            try
            {
                _logger.Debug(new MessageLogModel() { ServiceId = 1, MsgId = airTrackMessage.MsgId, MessageObject = JsonSerializer.Serialize(airTrackMessage) }, "This is a first messsage");

                _logger.Error(new MessageLogModel() { ServiceId = 1, MsgId = airTrackMessage.MsgId, MessageObject = JsonSerializer.Serialize(airTrackMessage) }, "This is a first messsage");

                _logger.Info(new MessageLogModel() { ServiceId = 1, MsgId = airTrackMessage.MsgId, MessageObject = JsonSerializer.Serialize(airTrackMessage) }, "This is a first messsage");

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  when log  message ", ex);
            }
        }
    }
}
