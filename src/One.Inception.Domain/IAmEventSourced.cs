using System;
using System.Collections.Generic;

namespace One.Inception;

public interface IAmEventSourced
{
    void ReplayEvents(IEnumerable<IEvent> events, int currentRevision);
    void RegisterEventHandler(Type eventType, Action<IEvent> handleAction);
    void RegisterEventHandler(EntityId entityId, Type eventType, Action<IEvent> handleAction);
    IEnumerable<IEvent> UncommittedEvents { get; }
}
