using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace JsonParsing
{
    public class Program
    {
        public static void Main()
        {
            ManualConfig config = DefaultConfig.Instance.WithArtifactsPath("../../../Artifacts");
            BenchmarkRunner.Run<NewVsOld_LargeList>(config);
        }
    }
}


#region Json generation
/*
        private static readonly Random _random = new();

        [GlobalSetup]
        public void Setup()
        {
            List<Person> people = GetFakePeopleData();
            string data = JsonSerializer.Serialize(people);
            Console.WriteLine(data);
        }
        private static List<Person> GetFakePeopleData()
        {
            Faker<Person> personFaker = new Faker<Person>()
                                        .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                                        .RuleFor(p => p.LastName, f => f.Person.LastName)
                                        .RuleFor(p => p.PhoneNumber, f => f.Person.LastName)
                                        .RuleFor(p => p.EmailAddress, f => f.Person.LastName)
                                        .RuleFor(p => p.Gender, f => f.Person.Gender == Name.Gender.Male)
                                        .RuleFor(p => p.Age, f => (int)f.Finance.Amount(0, 100))
                                        .RuleFor(p => p.Addresses, f => f.Make(3, () => f.Person.Address.Street));
            
            List<Person> people = new();
            for (int i = 0; i < 10; i++)
            {
                Person person = personFaker.Generate();
                people.Add(person);
            }

            return people;
        }
        */
#endregion