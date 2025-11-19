using System;
using System.Runtime.Serialization;

namespace One.Inception.Projections;

[DataContract]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class ProjectionAttribute : Attribute
{
    public ProjectionAttribute(ProjectionEventsPersistenceSetting persistence, ProjectionReplaySetting order, string fromIsoDate = null)
    {
        Persistence = persistence;
        Order = order;
        Timestamp = TryGetFormattedDate(fromIsoDate);
    }

    public ProjectionEventsPersistenceSetting Persistence { get; }

    public ProjectionReplaySetting Order { get; }

    /// <summary>
    /// This timestamp will be used for replay purposes. You can always override this in the inception dashboard, but it will be prefilled.
    /// The initial version of the projection will become live using this option.
    /// </summary>
    public DateTimeOffset? Timestamp { get; }


    DateTimeOffset? TryGetFormattedDate(string fromIsoDate)
    {
        if (string.IsNullOrEmpty(fromIsoDate))
            return null;

        bool canParse = DateTimeOffset.TryParse(fromIsoDate, out var result);
        if (canParse == false)
            throw new ArgumentException($"The date {fromIsoDate} is not in correct iso format");

        return result;
    }
}

[Flags]
public enum ProjectionEventsPersistenceSetting
{
    /// <summary>
    /// The events will not be persistent in the projection event store
    /// </summary>
    NotPersistent = 0x0000,

    /// <summary>
    /// The events will be persistent in the projection event store
    /// </summary>
    Persistent = 0x0001,
}

[Flags]
public enum ProjectionReplaySetting
{
    /// <summary>
    /// Unordered means that during replay only the interested event types are loaded and passed directly to the projection handler
    /// </summary>
    Unordered = 0x0000,

    /// <summary>
    /// Ordedred means that when we load the events, before passing them to the handler, the entire aggregate stream will be loaded
    /// and only the interested event types from that AR will be passed to the projection handler.
    /// </summary>
    Ordered = 0x0001,
}
