using System.Collections.Generic;

namespace SelectVsSelectMany
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public IEnumerable<string> Pets { get; set; }

        public int Id { get; set; }
    }
}