using Microsoft.AspNetCore.Mvc;
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
                TrackStatusMsg trackStatusMsg = new TrackStatusMsg() { TrackId = airTrackMessage.TrackId, IsActive = true};

                var messageLogModel = new MessageLogModel<AirTrackMessage>
                {
                    ServiceId = 1,
                    MsgId = airTrackMessage.MsgId,
                    MessageObject = airTrackMessage
                };
 
                var trackStatusMessageLogModel = new MessageLogModel<TrackStatusMsg>
                {
                    ServiceId = 1,
                    MsgId = airTrackMessage.MsgId,
                    MessageObject = trackStatusMsg
                };

                _logger.Debug(messageLogModel, "This is a Debug messsage"); 
                _logger.Info(trackStatusMessageLogModel, "This is a Info messsage");
                _logger.Error(trackStatusMessageLogModel, "This is a Error messsage");
                _logger.Error(trackStatusMessageLogModel, "This is a Error messsage with exeption", new ArgumentException("Status QR"));

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  when log  message ", ex);
            }
        }
    }
}
