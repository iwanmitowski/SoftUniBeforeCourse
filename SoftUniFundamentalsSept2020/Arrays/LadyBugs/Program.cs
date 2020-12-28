using System;
using System.Linq;
using System.Transactions;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize];
            int[] ladybugsPositions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int ladybugIndex = 0;
            string direction = string.Empty;
            int flyLength = 0;

            //LadyBugPositioning - working
            for (int i = 0; i < ladybugsPositions.Length; i++)
            {

                field[ladybugsPositions[i]] = 1;

            }


            while (true)
            {

                string[] input = Console.ReadLine().Split().ToArray();
                if (input[0] == "end")
                {
                    break;
                }

                // separating the input - working

                ladybugIndex = int.Parse(input[0]);
                direction = input[1];
                flyLength = int.Parse(input[2]);

                //Rotations - WIP АКО КАЛИНКАТА Е ВКРАЙНИТЕ СЛУЧАЙ ДА СЕ ДОВЪРШИ

                //Rotation right - working 50/50
                int movingLadybug = field[ladybugIndex];
                if (direction == "right")
                {


                    for (int j = ladybugIndex; j < field.Length; j += flyLength)
                    {

                        if (field[j] == 0)
                        {
                            field[j] = movingLadybug;
                            field[ladybugIndex] = 0;
                            break;

                        }
                        
                        else if (field[j] == 1)
                        {
                            if (j+flyLength>field.Length-1)
                            {
                                field[j] = 0;
                            }
                            
                        }
                    }
                }
                //Rotation left - working 50/50 КРАЙНИТЕ СЛУЧАЙ ДА СЕ ДОВЪРШАТ!
                else if (direction == "left")
                {
                    for (int j = ladybugIndex; j >=0; j += flyLength)
                    {

                        if (field[j] == 0)
                        {
                            field[j] = movingLadybug;
                            field[ladybugIndex] = 0;
                            break;

                        }
                        else if (j + flyLength == 0 && field[0] == 1 && direction == "left")
                        {
                            while (true)
                            {
                                int counter = 0;
                                if (field[counter] == 0)
                                {
                                    field[counter] = 1;
                                    field[ladybugIndex] = 0;
                                    break;
                                }
                                else
                                {
                                    counter = 0;

                                    field[counter] = 1;

                                    counter++;
                                }


                            }

                        }
                        else if (field[j] == 1)
                        {

                            continue;
                        }
                    }
                }


            }

            Console.WriteLine(string.Join(" ", field));


        }
    }
}
