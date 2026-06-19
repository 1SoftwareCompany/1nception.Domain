using System.Threading.Tasks;

namespace One.Inception;

public interface IMessageTracer
{
    void Record(string incomingMessageId, string correlationId = null);
    MessageTraceInfo CreateTrace(string messageId = null);
}

public interface IMessageTraceWriter
{
    Task WriteAsync(MessageTraceInfo messageTraceInfo);
}

public record class MessageTraceInfo
{
    public MessageTraceInfo(string messageId, string causationId, string correlationId)
    {
        MessageId = messageId;
        CausationId = causationId;
        CorrelationId = correlationId;
    }

    public string MessageId { get; private set; }
    public string CausationId { get; private set; }
    public string CorrelationId { get; private set; }
}

