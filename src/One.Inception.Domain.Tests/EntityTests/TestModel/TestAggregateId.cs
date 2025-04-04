using System.Runtime.Serialization;

namespace One.Inception.EntityTests.TestModel
{
    [DataContract(Name = "9bc4ea72-575d-4577-9440-63f867f0e415")]
    public class TestAggregateId : AggregateRootId
    {
        public TestAggregateId(Guid id)
            : base("artest", "TestAggregateId", id.ToString())
        {

        }

        public TestAggregateId()
            : base("artest", "TestAggregateId", Guid.NewGuid().ToString())
        {

        }
    }
}
