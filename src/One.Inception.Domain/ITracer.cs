namespace One.Inception;

public interface ITracer
{
    void Record(string incomingMessageId, string correlationId = null);
    TraceInfo GenerateTrace(string messageId = null);
    TraceInfo GetTrace();
}

public record class TraceInfo
{
    public TraceInfo(string messageId, string causationId, string correlationId)
    {
        MessageId = messageId;
        CausationId = causationId;
        CorrelationId = correlationId;
    }

    public string MessageId { get; private set; }
    public string CausationId { get; private set; }
    public string CorrelationId { get; private set; }
}
