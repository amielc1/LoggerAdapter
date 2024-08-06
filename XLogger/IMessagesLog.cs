using XLogger.LogModel;

namespace XLogger;

public interface IMessagesLog
{
    void Debug(MessageLogModel messageLogModel, string msg);
    void Info(MessageLogModel messageLogModel, string msg);
    void Error(MessageLogModel messageLogModel, string msg);
}
