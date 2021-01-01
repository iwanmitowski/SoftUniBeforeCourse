using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" -> ");

            while (input[0] != "End")
            {
                string companyName = input[0];
                string id = input[1];

                if (companies.ContainsKey(companyName) == false)
                {
                    companies.Add(companyName, new List<string> { id });
                }
                else
                {
                    if (companies[companyName].Contains(id) == false)
                    {
                        companies[companyName].Add(id);
                    }
                }

                input = Console.ReadLine().Split(" -> ");
            }

            foreach (var company in companies.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{company.Key}");

                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }

        }
    }
}
