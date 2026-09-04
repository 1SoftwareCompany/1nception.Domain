using System.Threading.Tasks;

namespace One.Inception;

public interface INodeBroadcastHandle<in T>
    where T : IBroadcast
{
    Task HandleAsync(T message);
}
