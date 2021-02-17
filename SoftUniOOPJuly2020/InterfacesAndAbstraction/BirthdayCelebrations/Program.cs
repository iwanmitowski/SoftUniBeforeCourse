using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IBirthable> mammals = new List<IBirthable>();

            while (input!="End")
            {
                string[] inputArgs = input.Split();
                string type = inputArgs[0];
                string name = inputArgs[1];
                string birthdate = inputArgs.Last();
                if (type=="Citizen")
                {
                    int age = int.Parse(inputArgs[2]);
                    string id = inputArgs[3];
                    mammals.Add(new Citizen(name, age, id, birthdate));
                    
                }
                else if (type=="Pet")
                {
                    mammals.Add(new Pet(name, birthdate));
                }
                else if (type=="Robot")
                {
                    string id = inputArgs[2];

                    IIdentible robot = new Robot(name, id);
                }

                input = Console.ReadLine();
            }
            string birth = Console.ReadLine();

            mammals = mammals.Where(x => x.Birthdate.EndsWith(birth)).ToList();

            if (mammals.Count==0)
            {
                Console.WriteLine("<empty output>");
            }
            else
            {
                foreach (var birhtable in mammals)
                {
                    Console.WriteLine(birhtable.Birthdate);
                }
            }
            
        }
    }
}
