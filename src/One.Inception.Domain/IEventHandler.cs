using System.Threading.Tasks;

namespace One.Inception;

public interface IEventHandler<in T>
    where T : IEvent
{
    Task HandleAsync(T @event);
}
