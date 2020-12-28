using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            
            string[] person = Console.ReadLine().Split(new[] { " ", "=",";" }, StringSplitOptions.RemoveEmptyEntries);
            
            string[] food = Console.ReadLine().Split(new[] { " ", "=", ";" }, StringSplitOptions.RemoveEmptyEntries);
            

            for (int i = 0; i < person.Length; i+=2)
            {
                string name = person[i];
                int money = int.Parse(person[i + 1]);
                Person member = new Person(name, money);
                people.Add(member);

            }

            for (int i = 0; i < food.Length; i+=2)
            {
                string name = food[i];
                int cost = int.Parse(food[i + 1]);
                Product product = new Product(name, cost);
                products.Add(product);

            }

            string[] command = Console.ReadLine().Split();

            while (command[0]!="END")
            {
                string user = command[0];
                string product = command[1];

                List<Person> currPer = people.Where(x => x.Name == user).ToList();
                List<Product> currProd = products.Where(x => x.Name == product).ToList();

                int tempMoney = currPer[0].Money;
                int tempCost = currProd[0].Cost;

                int calculation = tempMoney -= tempCost;

                if (calculation >= 0)
                {
                    currPer[0].Money -= currProd[0].Cost;
                    currPer[0].Bag.Add(currProd[0].Name);
                    Console.WriteLine($"{currPer[0].Name} bought {currProd[0].Name}");
                }
                else
                {
                    Console.WriteLine($"{currPer[0].Name} can't afford {currProd[0].Name}");
                }

                command = Console.ReadLine().Split();
            }

            foreach (Person member in people)
            {
                Console.WriteLine(member);
            }

        }
    }
}
