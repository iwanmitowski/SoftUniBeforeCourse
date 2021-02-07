using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> liquidsArr = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> ingridientsArr = Console.ReadLine().Split().Select(int.Parse).ToList();

            Queue<int> liquids = new Queue<int>(liquidsArr);
            Stack<int> ingredients = new Stack<int>(ingridientsArr);


            Dictionary<int, Dictionary<string, int>> foods = new Dictionary<int, Dictionary<string, int>>();

            foods.Add(25, new Dictionary<string, int>());
            foods.Add(50, new Dictionary<string, int>());
            foods.Add(100, new Dictionary<string, int>());
            foods.Add(75, new Dictionary<string, int>());

            foods[25].Add("Bread", 0);
            foods[50].Add("Cake", 0);
            foods[100].Add("Fruit Pie", 0);
            foods[75].Add("Pastry", 0);

            int currentLiquid = liquids.Peek();
            int currentIngredient = ingredients.Peek();
            int mixed = currentLiquid + currentIngredient;

            while (liquids.Count != 0 && ingredients.Count != 0)
            {


                if (foods.ContainsKey(mixed))
                {
                    string searched = string.Empty;

                    switch (mixed)
                    {
                        case 25:
                            searched = "Bread";
                            break;
                        case 50:
                            searched = "Cake";
                            break;
                        case 75:
                            searched = "Pastry";
                            break;
                        case 100:
                            searched = "Fruit Pie";
                            break;
                        default:
                            break;
                    }

                    foods[mixed][searched]++;
                    liquids.Dequeue();
                    ingredients.Pop();

                    if (liquids.Count == 0 || ingredients.Count == 0)
                    {
                        
                        break;

                    }

                    currentLiquid = liquids.Peek();
                    currentIngredient = ingredients.Peek();

                    mixed = currentLiquid + currentIngredient;
                }
                else
                    
                {
                    liquids.Dequeue();
                    currentIngredient += 3;

                    if (liquids.Count == 0 || ingredients.Count == 0)
                    {
                        ingredients.Pop();
                        ingredients.Push(currentIngredient);
                     
                        break;

                    }

                    currentLiquid = liquids.Peek();
                }


            }
            int noFoodCounter = 0;

            foreach ((int quantity, Dictionary<string, int> foodQuantity) in foods)
            {
                foreach ((string food, int num) in foodQuantity)
                {
                    if (num == 0)
                    {
                        noFoodCounter++;
                    }
                }
            }

            if (noFoodCounter == 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");

            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");

            }



            foreach ((int quantity, Dictionary<string, int> foodQuantity) in foods)
            {
                foreach ((string food, int num) in foodQuantity)
                {
                    Console.WriteLine($"{food}: {num}");
                }
            }
        }
    }
}
