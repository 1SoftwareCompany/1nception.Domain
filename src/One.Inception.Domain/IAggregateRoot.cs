namespace One.Inception;

public interface IAggregateRoot : IAmEventSourced, IHaveState<IAggregateRootState>, IUnderstandPublishedLanguage
{
    int Revision { get; }
}
