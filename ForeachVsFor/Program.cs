using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ForeachVsFor
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<WhenIteratingObjects>();
        }
    }
    [MemoryDiagnoser]
    public class WhenCounting
    {
        private readonly int[] _intSeedData = new int[1_000_000];
        private int Counter { get; set; }

        public void SetupIntSeedData()
        {
            for (int i = 0; i < _intSeedData.Length; i++)
            {
                _intSeedData[i] = new Random().Next(0, int.MaxValue);
            }
        }
        
        [Benchmark]
        public void ForeachOnlyCounting()
        {
            foreach (int i in _intSeedData)
            {
                Counter++;
            }
        }
        [Benchmark]
        public void ForOnlyCounting()
        {
            for (int i = 0; i < _intSeedData.Length; i++)
            {
                Counter++;
            }
        }
    }
    [MemoryDiagnoser]
    public class WhenIteratingObjects
    {
        private Person Person { get; set; }
        private readonly Person[] _personSeedData = new Person[1_000_000];

        [GlobalSetup]
        public void SetupPersonSeedData()
        {
            for (int i = 0; i < _personSeedData.Length; i++)
            {
                _personSeedData[i] = new Person()
                {
                    FirstName = $"First name: {i}",
                    LastName = $"Last name: {i}",
                };
            }
        }
        
        [Benchmark]
        public void ForeachLoopIteratingObjects()
        {
            foreach (Person person in _personSeedData)
            {
                Person = person;
            }
        }
        [Benchmark]
        public void ForLoopIteratingObjects()
        {
            for (int i = 0; i < _personSeedData.Length; i++)
            {
                Person = _personSeedData[i];
            }
        }
    }
    
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}