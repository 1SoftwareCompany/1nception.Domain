namespace One.Inception;

public class ResolvingBoundedContextFromAMessageWithoutDataContractAttribute
{
    static string result;

    [Before(Class)]
    public static void Setup()
    {
        result = typeof(IPublicEvent).GetBoundedContext("inception");
    }

    [Test]
    public async Task ShouldResolveTheDefaultBoundedContext()
    {
        await Assert.That(result).IsEqualTo("inception");
    }
}
