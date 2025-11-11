using System.Collections.Generic;

namespace One.Inception.Projections;

public interface IProjectionDefinition : IHaveState , IProjection
{
    /// <summary>
    /// Gets all projection identifiers based on an event.
    /// </summary>
    /// <param name="event"></param>
    /// <returns></returns>
    IEnumerable<IBlobId> GetProjectionIds(IEvent @event);
}
