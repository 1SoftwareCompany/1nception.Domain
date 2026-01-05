using System.Threading.Tasks;

namespace One.Inception;

public interface IPublicEventHandle<in T>
    where T : IPublicEvent
{
    Task HandleAsync(T @event);
}
