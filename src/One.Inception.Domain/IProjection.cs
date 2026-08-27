using System.Threading.Tasks;

namespace One.Inception;

/// <summary>
/// Projection tracks events and project their data for specific purposes.
/// </summary>
public interface IProjection : IMessageHandler
{
    /// <summary>
    /// Save, used by replay of non projection defintion projections
    /// </summary>
    /// <param name="event"></param>
    /// <returns></returns>
    Task ReplayEventAsync(IEvent @event) => Task.CompletedTask;

    /// <summary>
    /// Called after all replay of events are iterated. It allows you to clean up after the process is finished.
    /// </summary>
    /// <returns></returns>
    Task OnReplayCompletedAsync() => Task.CompletedTask;
}
