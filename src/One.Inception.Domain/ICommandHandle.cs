using System.Threading.Tasks;

namespace One.Inception;

public interface ICommandHandle<in T>
    where T : ICommand
{
    Task HandleAsync(T command);
}
