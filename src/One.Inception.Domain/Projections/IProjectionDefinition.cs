using System.Collections.Generic;
using System.Threading.Tasks;

namespace One.Inception.Projections;

public interface IProjectionDefinition : IHaveState
{
    /// <summary>
    /// Gets all projection identifiers based on an event.
    /// </summary>
    /// <param name="event"></param>
    /// <returns></returns>
    IEnumerable<IBlobId> GetProjectionIds(IEvent @event);
    Task ApplyAsync(IEvent @event);
}
