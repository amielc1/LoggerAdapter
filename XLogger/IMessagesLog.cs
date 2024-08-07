using XLogger.LogModel;

namespace XLogger
{
    public interface IMessagesLog
    {
        void Debug<T>(MessageLogModel<T> messageLogModel, string msg);
        void Info<T>(MessageLogModel<T> messageLogModel, string msg);
        void Error<T>(MessageLogModel<T> messageLogModel, string msg);
    }
}
