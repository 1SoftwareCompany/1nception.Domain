namespace One.Inception;

public class TestEntityUrnId : EntityId<AggregateRootId>
{
    public TestEntityUrnId(string idBase, AggregateRootId rootId) : base(idBase, rootId) { }

    protected override ReadOnlySpan<char> EntityName { get => "Entity"; }
}
