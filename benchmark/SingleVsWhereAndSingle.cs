using BenchmarkDotNet.Attributes;

namespace benchmark
{
    public class SingleVsWhereAndSingle
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
        public Person Form1()
        {
            return people.Where( a=>a.Id == 50000 ).Single();
        }

        [Benchmark]
        public Person Form2()
        {
            return people.Single(a => a.Id == 50000);
        }
    }
}
