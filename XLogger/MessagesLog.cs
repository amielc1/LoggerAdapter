using Microsoft.Extensions.Logging;
using System.Text.Json;
using XLogger.LogModel;

namespace XLogger
{
    public class MessagesLog : IMessagesLog
    {
        private readonly ILogger<MessagesLog> _logger;

        public MessagesLog(ILogger<MessagesLog> logger)
        {
            _logger = logger;
        }

        public void Debug<T>(MessageLogModel<T> messageLogModel, string msg)
        {
            Log(LogLevel.Debug, messageLogModel, msg);
        }

        public void Info<T>(MessageLogModel<T> messageLogModel, string msg)
        {
            Log(LogLevel.Information, messageLogModel, msg);
        }

        public void Error<T>(MessageLogModel<T> messageLogModel, string msg)
        {
            Log(LogLevel.Error, messageLogModel, msg);
        }

        private void Log<T>(LogLevel logLevel, MessageLogModel<T> messageLogModel, string msg)
        {
            string serializedMessage = JsonSerializer.Serialize(messageLogModel.MessageObject);
            _logger.Log(logLevel, "{ServiceId} {MsgId} {MessageObject} {MsgText}",
                messageLogModel.ServiceId, messageLogModel.MsgId, serializedMessage, msg);
        }
    }
}
