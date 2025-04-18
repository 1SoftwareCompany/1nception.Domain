﻿//using BenchmarkDotNet.Attributes;

//namespace One.Inception.Domain.Benchmarks;

//[MemoryDiagnoser]
//public class AggregateRootIdBenchmarks
//{
//    public class TestId : AggregateRootId<TestId>
//    {
//        TestId() { }
//        public TestId(ReadOnlySpan<char> tenant, ReadOnlySpan<char> id) : base(tenant, id) { }

//        public override ReadOnlySpan<char> AggregateRootName => "test";
//    }

//    private static readonly TestId testId = new("tenant", "id");
//    private static readonly TestId equalTestId = new("tenant", "id");

//    private TestId[] ids;

//    [Params(1, 1000, 10_000, 100_000)]
//    public int N;

//    [GlobalSetup]
//    public void Setup()
//    {
//        ids = new TestId[N];
//    }


//    [Benchmark(Baseline = true)]
//    public TestId[] Create_N_Ids_From_Spans()
//    {
//        for (int i = 0; i < N; i++)
//        {
//            ids[i] = new TestId("tenant", "id");
//        }

//        return ids;
//    }

//    [Benchmark]
//    public TestId[] Create_N_Ids_From_Span_Using_Static_Parse()
//    {
//        for (int i = 0; i < N; i++)
//        {
//            ids[i] = TestId.Parse("urn:tenant:test:id");
//        }

//        return ids;
//    }

//    [Benchmark]
//    public bool Compare_Equal_Ids()
//    {
//        return testId.Equals(equalTestId);
//    }
//}
