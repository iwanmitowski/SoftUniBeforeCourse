using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            int walkedSteps = 0;
            int steps = 0;


            while (true)
            {
                string imput = Console.ReadLine();
                if (imput == "Going home")
                {
                    imput = Console.ReadLine();
                    steps = int.Parse(imput);
                    walkedSteps += steps;
                    if (walkedSteps >= goal)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        Console.WriteLine($"{walkedSteps - goal} steps over the goal!");
                        break;
                    }
                    else if (walkedSteps < goal)
                    {
                        Console.WriteLine($"{goal - walkedSteps} more steps to reach goal.");
                        break;
                    }

                }

                steps = int.Parse(imput);
                walkedSteps += steps;

                if (walkedSteps >= goal)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{walkedSteps - goal} steps over the goal!");
                    break;
                }



            }

        }
    }
}

