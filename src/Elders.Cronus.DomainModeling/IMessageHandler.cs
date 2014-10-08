namespace Elders.Cronus.DomainModeling
{
    /// <summary>
    /// A markup interface telling that the implementing class will handle all messages of Type <typeparamref name="T"/>
    /// </summary>
    public interface IMessageHandler<in T>
        where T : IMessage
    {
        void Handle(T message);
    }

    public interface IProjection
    {

    }
}