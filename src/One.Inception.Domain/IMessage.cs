using System;

namespace One.Inception;

public interface IMessage
{
    DateTimeOffset Timestamp { get; }
    
    sealed string MessageId => MessageIds.Get(this); // sealed, so we are not allowing overriding of this propoerty
}
