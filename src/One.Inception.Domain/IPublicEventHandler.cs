using System.Threading.Tasks;

namespace One.Inception;

public interface IPublicEventHandler<in T>
    where T : IPublicEvent
{
    Task HandleAsync(T @event);
}
