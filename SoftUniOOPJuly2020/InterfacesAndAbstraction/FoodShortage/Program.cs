using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
            

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input.Split();

                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                
                if (inputArgs.Length == 4)
                {
                    string id = inputArgs[2];
                    string birthdate = inputArgs.Last();

                    buyers.Add(name, new Citizen(name, age, id, birthdate));

                }
                else
                {
                    string group = inputArgs[2];
                    buyers.Add(name, new Rebel(name, age, group));
                   
                }

            }
            string names = Console.ReadLine();

            while (names!="End")
            {
                if (buyers.ContainsKey(names))
                {
                    buyers[names].BuyFood();
                }

                names = Console.ReadLine();
            }

            int totalFood = buyers.Select(x => x.Value.Food).Sum() ;
            
            Console.WriteLine(totalFood);
        }




    }
}

