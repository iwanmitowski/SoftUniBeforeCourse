using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, int> parser = num => int.Parse(num);


            int n = parser(Console.ReadLine());

            Dictionary<string, int> person = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] personDetails = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = personDetails[0];
                int age = parser(personDetails[1]);

                person.Add(name, age);
            }

            string condition = Console.ReadLine();
            int ageToCompare = parser(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, ageToCompare);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            foreach (var p in person)
            {
                if (tester(p.Value))
                {
                    printer(p);
                }
            }
        }
        public static Func<int, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return x => x < age;
                case "older":
                    return x => x >= age;
                default:
                    return null;
            }

        }
        public static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Key}");
                case "age":
                    return person => Console.WriteLine($"{person.Value}");
                case "name age":
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");
                default:
                    return null;
            }
        }
    }
}
