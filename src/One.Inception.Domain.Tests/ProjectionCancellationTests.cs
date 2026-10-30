using One.Inception.Projections;

namespace One.Inception;

public class ProjectionCancellationTests
{
    [Test]
    public async Task PassesTheTokenToTheProjectionHandler()
    {
        using var source = new CancellationTokenSource();
        var projection = new CancellationProjection();
        await ((IHaveState)projection).ApplyAsync(new CancellationEvent(), source.Token);
        await Assert.That(projection.Token == source.Token).IsTrue();
    }

    [Test]
    public async Task DoesNotApplyAnEventWhenAlreadyCancelled()
    {
        using var source = new CancellationTokenSource();
        source.Cancel();
        var projection = new CancellationProjection();
        bool cancelled = false;
        try { await ((IHaveState)projection).ApplyAsync(new CancellationEvent(), source.Token); }
        catch (OperationCanceledException) { cancelled = true; }
        await Assert.That(cancelled).IsTrue();
        await Assert.That(projection.Calls).IsEqualTo(0);
    }
}

public class CancellationProjection : ProjectionDefinition<object, Urn>, IEventHandle<CancellationEvent>
{
    public CancellationToken Token;
    public int Calls;

    public Task HandleAsync(CancellationEvent message, CancellationToken cancellationToken)
    {
        Token = cancellationToken;
        Calls++;
        return Task.CompletedTask;
    }
}

public class CancellationEvent : IEvent
{
    public DateTimeOffset Timestamp => DateTimeOffset.UtcNow;
}
