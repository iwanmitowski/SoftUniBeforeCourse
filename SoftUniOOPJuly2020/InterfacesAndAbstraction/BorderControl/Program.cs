using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IIdentible> passangers = new List<IIdentible>();

            while (input!="End")
            {
                string[] inputArgs = input.Split();
                string name = inputArgs[0];
                string id = inputArgs.Last();
                if (inputArgs.Length==3)
                {
                    int age = int.Parse(inputArgs[1]);

                    IIdentible citizen = new Citizen(name, age, id);
                    passangers.Add(citizen);
                }
                else
                {
                    IIdentible robot = new Robot(name, id);
                    passangers.Add(robot);
                }


                input = Console.ReadLine();
            }
            string digitsToSearchFor = Console.ReadLine();
            passangers = passangers.Where(x => x.Id.EndsWith(digitsToSearchFor)).ToList();

            foreach (var pass in passangers)
            {
                Console.WriteLine(pass.Id);
            }
        }
    }
}
