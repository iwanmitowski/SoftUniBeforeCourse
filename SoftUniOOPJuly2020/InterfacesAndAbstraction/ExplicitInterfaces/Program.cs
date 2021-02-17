using System;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                string name = input[0];
                string country = input[1];
                int age = int.Parse(input[2]);

                Citizen citizen = new Citizen(name, country, age);

                Console.WriteLine(citizen.GetName());
                Console.WriteLine((citizen as IResident).GetName());//explicitly

                input = Console.ReadLine().Split();
            }
        }
    }
}
