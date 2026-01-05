using System;
using System.Threading.Tasks;

namespace One.Inception;

/// <summary>
/// When we have a workflow which involves several aggregates it is recommended to have the whole process described 
/// in a single place such as Saga/ProcessManager.
/// </summary>
public interface IProcessManager : IMessageHandler { }

/// <summary>
/// Message which will be published in the future.
/// </summary>
public interface IScheduledMessage : IMessage
{
    /// <summary>
    /// The date when this message will be published.
    /// </summary>
    DateTimeOffset PublishAt { get; }
}

public interface IProcessManagerTimeoutHandle<in T> where T : IScheduledMessage
{
    Task HandleAsync(T processManagerTimeout);
}

public abstract class ProcessManager : IProcessManager
{
    protected readonly IPublisher<ICommand> commandPublisher;
    protected readonly IPublisher<IScheduledMessage> timeoutRequestPublisher;

    public ProcessManager(IPublisher<ICommand> commandPublisher, IPublisher<IScheduledMessage> timeoutRequestPublisher)
    {
        this.commandPublisher = commandPublisher ?? throw new ArgumentNullException(nameof(commandPublisher));
        this.timeoutRequestPublisher = timeoutRequestPublisher ?? throw new ArgumentNullException(nameof(timeoutRequestPublisher));
    }

    public Task<bool> RequestTimeoutAsync<T>(T timeoutMessage) where T : IScheduledMessage
    {
        return timeoutRequestPublisher.PublishAsync(timeoutMessage, timeoutMessage.PublishAt);
    }
}
