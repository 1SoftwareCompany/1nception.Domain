using System.Threading.Tasks;

namespace One.Inception;

public interface ISignalHandle<in T>
    where T : ISignal
{
    Task HandleAsync(T signal);
}
