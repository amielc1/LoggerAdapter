using Microsoft.Extensions.Logging;
using XLogger.LogModel;

namespace XLogger;

public class MessagesLog : IMessagesLog
{
    private readonly ILogger<MessagesLog> _logger;

    public MessagesLog(ILogger<MessagesLog> logger)
    {
        _logger = logger;
    }

    public void Debug(MessageLogModel messageLogModel, string msg)
    {
        Log(LogLevel.Debug, messageLogModel, msg);
    }

    public void Info(MessageLogModel messageLogModel, string msg)
    {
        Log(LogLevel.Information, messageLogModel, msg);
    }

    public void Error(MessageLogModel messageLogModel, string msg)
    {
        Log(LogLevel.Error, messageLogModel, msg);
    }

    private void Log(LogLevel logLevel, MessageLogModel messageLogModel, string msg)
    {
        _logger.Log(logLevel, "{ServiceId} {MsgId} {MessageObject} {MsgText}",
            messageLogModel.ServiceId, messageLogModel.MsgId, messageLogModel.MessageObject, msg);
    } 
} 
