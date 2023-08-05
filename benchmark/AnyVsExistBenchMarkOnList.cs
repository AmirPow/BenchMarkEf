using BenchmarkDotNet.Attributes;

namespace benchmark
{
    public class AnyVsExistBenchMarkOnList
    {
        private List<Person> people;

        [Params(1000, 10000, 100000)]
        public int DataSize;

        [GlobalSetup]
        public void GlobalSetup()
        {
            // Prepare some sample data
            people = Enumerable.Range(1, DataSize)
                .Select(i => new Person { Id = i, Name = "Person" + i })
                .ToList();
        }

        [Benchmark]
        public bool AnyOnIQueryable()
        {
            return people.Any(a => a.Id == 500);
        }

        [Benchmark]
        public bool ExistsOnToList()
        {
            return people.ToList().Exists(a => a.Id == 500);
        }
    }
}
