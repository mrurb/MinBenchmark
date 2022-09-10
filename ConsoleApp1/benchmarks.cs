using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60)]
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net70)]
    [MemoryDiagnoser(false)]
    public class Benchmarks
    {
        [Params(100)]
        public int Size { get; set; }
        private IEnumerable<Person> _items;

        [GlobalSetup]
        public void setup()
        {
            var ages = Enumerable.Range(1,Size).ToArray();
            _items = ages.Select(c => new Person { Age = c, Name = "" });
        }


        [Benchmark]
        public int Min() => _items.Min(c => c.Age);

        [Benchmark]
        public Person? MinBy() => _items.MinBy(c => c.Age);

        [Benchmark]
        public Person MinFirst()
        {
            int[] ages = _items.Select(c => c.Age).ToArray();
            int v = ages.Min();
            return _items.First(c => c.Age == v);
        }
        
        [Benchmark]
        public Person[] MinWhere()
        {
            int[] ages = _items.Select(c => c.Age).ToArray();
            int v = ages.Min();
            return _items.Where(c => c.Age == v).ToArray();
        }
        
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
