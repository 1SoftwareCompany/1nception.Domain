using System.Threading.Tasks;

namespace One.Inception.Projections;

public interface IHaveState
{
    /// <summary>
    /// The ID of the specific projection instance.
    /// </summary>
    IBlobId Id { get; set; }

    /// <summary>
    /// The state/snapshot of the specific projection instance.
    /// </summary>
    object State { get; set; }

    /// <summary>
    /// Initializes the projection.
    /// </summary>
    /// <param name="id">The ID of the specific projection instance.</param>
    /// <param name="state">The state/snapshot of the specific projection instance.</param>
    Task InitializeStateAsync(IBlobId id, object state);

    /// <summary>
    /// GET build the state of a projection
    /// </summary>
    /// <param name="event"></param>
    /// <returns></returns>
    Task ApplyAsync(IEvent @event) => Task.CompletedTask;
}
