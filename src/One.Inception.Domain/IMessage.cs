using System;

namespace One.Inception;

public interface IMessage
{
    DateTimeOffset Timestamp { get; }
}
