using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Dogs, Animals
            // dogFood=Dogs*2.5 animalsFood=Animals*4
            // total= dogFood+ animalsFood
            int dogs = int.Parse(Console.ReadLine());
            int animals = int.Parse(Console.ReadLine());
            double dogFood = dogs * 2.5;
            double animalsFood = animals * 4;
            Console.WriteLine($"{dogFood+animalsFood} lv.");
            
            
        }
    }
}
