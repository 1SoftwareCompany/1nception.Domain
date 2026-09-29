using System;

namespace One.Inception;

public interface IMessage
{
    DateTimeOffset Timestamp { get; }

    string MessageId => MessageIds.Get(this);
}
