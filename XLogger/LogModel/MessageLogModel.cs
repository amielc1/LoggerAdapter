namespace XLogger.LogModel
{
    public class MessageLogModel<T>
    {
        public int ServiceId { get; set; }
        public int MsgId { get; set; }
        public T? MessageObject { get; set; }
    }
}
