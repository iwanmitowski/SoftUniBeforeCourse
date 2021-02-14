using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInput = Console.ReadLine().Split();
                string pizzaName = pizzaInput[1];

                string[] doughInput = Console.ReadLine().Split();
                string flourType = doughInput[1];
                string bakingTechnique = doughInput[2];
                int weight = int.Parse(doughInput[3]);

                Dough dough = new Dough(flourType, bakingTechnique, weight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string toppingInput = Console.ReadLine();

                while (toppingInput!="END")
                {
                    string[] toppingArgs = toppingInput.Split();

                    string toppingName = toppingArgs[1];
                    int toppingWeight = int.Parse(toppingArgs[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);
                    pizza.AddTopping(topping);

                    toppingInput = Console.ReadLine();
                }
                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
