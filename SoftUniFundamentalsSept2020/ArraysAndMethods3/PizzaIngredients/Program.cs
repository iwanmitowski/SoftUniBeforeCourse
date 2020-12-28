using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] ingredients = Console.ReadLine().Split(" ").ToArray();
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            
            string result = string.Empty;
            for (int i = 0; i < ingredients.Length && counter <10; i++)
            {
                
                if (ingredients[i].Length==n)
                {
                   
                    counter++;
                    Console.WriteLine($"Adding {ingredients[i]}.");
                    result += ingredients[i] + " ";

                }
               
            }
            string[] addedIngredients = result.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();


            Console.WriteLine($"Made pizza with total of {counter} ingredients.");
            Console.WriteLine($"The ingredients are: {string.Join(", ", addedIngredients)}.");
        }
    }
}
