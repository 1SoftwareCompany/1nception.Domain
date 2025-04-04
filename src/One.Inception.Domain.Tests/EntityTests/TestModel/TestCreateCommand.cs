namespace One.Inception.EntityTests.TestModel
{
    public class TestCreateCommand : ICommand
    {
        TestCreateCommand() { }

        public TestCreateCommand(TestAggregateId id)
        {
            Timestamp = DateTimeOffset.Now;
        }

        public TestAggregateId Id { get; set; }

        public DateTimeOffset Timestamp { get; set; }
    }
}
