using System;

namespace ProjectCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string Name = Console.ReadLine();
            int Projects = int.Parse(Console.ReadLine());
            int ProjectTime = Projects * 3;
            Console.WriteLine($"The architect {Name} will need {ProjectTime} hours to complete {Projects} project/s.");

        }
    }
}
