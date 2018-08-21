using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SelectVsSelectMany
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            var tup = ReturningStuffInAClearWay();

            var type = tup.GetType();
            Console.WriteLine(type);

            var people = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    Age = 23,
                    Name = "Collins"
                },
                new Person
                {
                    Id = 2,
                    Name = "Mugarura",
                    Age = 25,
                },
                new Person
                {
                    Id = 3,
                    Name = "Barx",
                    Age = 25
                },
                
                new Person
                {
                    Id = 2,
                    Name = "Test",
                    Age=0
                }
            };
            
            var dictionary= new Dictionary<int, Person>();

            foreach (var person in people)
            {
                if (dictionary.ContainsKey(person.Id))
                {
                    dictionary.Add(person.Id +5, person);
                    //continue;
                }
                else
                {
                    dictionary.Add(person.Id, person);
                }
                
                
            }

            dictionary.Keys.ToList().ForEach(Console.WriteLine);

            //var test = people.ToDictionary(x => x.Id, p => p);
                
                
            var testDictionary = new Dictionary<string, IDictionary<string, Person>>
            {
                
                
                {
                    "Uganda", new Dictionary<string, Person>
                    {
                        {
                            "Collins", new Person
                            {
                                Name = "Mugarura",
                                Age = 29,
                                Pets = new[] {"Simba", "Bobby"}
                            }
                        }
                    }
                },
                {
                    "England", new Dictionary<string, Person>
                    {
                        {
                            "Serena", new Person
                            {
                                Name = "Sienna",
                                Age = 8,
                                Pets = new[] {"Catty", "Rainbow", "OWen"}
                            }
                        }
                    }
                }
            };

            var name = GetPersonNameGivenOuterName("Serena", testDictionary);

            Assert.AreEqual("Sienna", name);

            Console.WriteLine(name);
            Console.ReadKey();


        }

        private static string GetPersonNameGivenOuterName(string outerKey, IDictionary<string, IDictionary<string, Person>> dictionary)
        {

            //var test = dictionary.Values.Select(b => b.Keys.FirstOrDefault(x => x == outerKey));
            var test = dictionary.SelectMany(x => x.Value).FirstOrDefault(c => c.Key == outerKey).Value.Name;

            var name = dictionary.Values.FirstOrDefault(d => d.ContainsKey(outerKey))?.Values.FirstOrDefault()?.Name;

            return name;
        }

        private static (string name, bool isCool) ReturningStuffInAClearWay()
        {
            return ("Collins,", true);
        }
    }
}