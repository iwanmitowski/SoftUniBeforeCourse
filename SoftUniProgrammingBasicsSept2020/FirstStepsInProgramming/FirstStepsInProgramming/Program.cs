using System;

namespace FirstStepsInProgramming
{
    class Program
    {
        static void Main(string[] args)
        {


            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int ages = int.Parse(Console.ReadLine());
            string town = Console.ReadLine();
            Console.WriteLine($"You are {firstName} {lastName}, a {ages}-years old person from {town}. ");




        }
    }
}
