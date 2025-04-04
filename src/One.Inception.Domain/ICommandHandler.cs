using System.Threading.Tasks;

namespace One.Inception;

public interface ICommandHandler<in T>
    where T : ICommand
{
    Task HandleAsync(T command);
}
