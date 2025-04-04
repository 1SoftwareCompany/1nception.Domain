﻿//using BenchmarkDotNet.Attributes;

//namespace One.Inception.Domain.Benchmarks;

//[MemoryDiagnoser]
//public class AggregateRootBenchmarks
//{
//    public sealed class TestAggregateRoot : AggregateRoot<TestAggregateRootState>
//    {
//        public void DoStuff()
//        {
//            Apply(new DidStuff(new TestId("tenant", "id"), DateTimeOffset.UtcNow));
//        }
//    }

//    public sealed class TestAggregateRootState : AggregateRootState<TestAggregateRoot, TestId>
//    {
//        public override TestId Id { get; set; }
//        public DateTimeOffset Timestamp { get; set; }

//        public void When(DidStuff e)
//        {
//            Id = e.Id;
//            Timestamp = e.Timestamp;
//        }
//    }

//    public sealed class TestId : AggregateRootId<TestId>
//    {
//        public const string TestRootName = "test";

//        TestId() { }
//        public TestId(ReadOnlySpan<char> tenant, ReadOnlySpan<char> id) : base(tenant, id) { }

//        public override ReadOnlySpan<char> AggregateRootName => TestRootName;
//    }

//    public sealed class DidStuff : IEvent
//    {
//        public DidStuff(TestId id, DateTimeOffset timestamp)
//        {
//            Id = id;
//            Timestamp = timestamp;
//        }

//        public TestId Id { get; }
//        public DateTimeOffset Timestamp { get; }
//    }

//    private TestAggregateRoot[] roots;
//    private TestAggregateRoot[] roots_ApplyEvent;

//    [Params(1, 100, 1000)]
//    public int N;

//    [GlobalSetup]
//    public void Setup()
//    {
//        roots = new TestAggregateRoot[N];
//        roots_ApplyEvent = new TestAggregateRoot[N];
//        for (int i = 0; i < N; i++)
//        {
//            roots_ApplyEvent[i] = new TestAggregateRoot();
//        }
//    }

//    [Benchmark]
//    public void CreateNewAggregateRoot()
//    {
//        for (int i = 0; i < N; i++)
//        {
//            roots[i] = new TestAggregateRoot();
//        }
//    }

//    [Benchmark]
//    public void ApplyEvent()
//    {
//        for (int i = 0; i < N; i++)
//        {
//            roots_ApplyEvent[i].DoStuff();
//        }
//    }
//}
