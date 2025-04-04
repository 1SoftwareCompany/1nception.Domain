namespace One.Inception;

public interface IHaveState<out TState>
{
    TState State { get; }
}
