using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int freeSpaceWidth = int.Parse(Console.ReadLine());
            int freeSpaceLength = int.Parse(Console.ReadLine());
            int freeSpaceHeigth = int.Parse(Console.ReadLine());
            int totalRoomSpace = freeSpaceWidth * freeSpaceLength * freeSpaceHeigth;
            int totalBoxes = 0;


            while (totalBoxes<=totalRoomSpace)
            {
                string imput = Console.ReadLine();

                if (imput == "Done")
                {
                    
                    break;
                }
                
                
                int boxes = int.Parse(imput);
                
                totalBoxes += boxes;
               
            }
            if (totalBoxes > totalRoomSpace)
            {
                Console.WriteLine($"No more free space! You need {totalBoxes - totalRoomSpace} Cubic meters more.");
               

            }
            if (totalBoxes <= totalRoomSpace)
            {
                Console.WriteLine($"{totalRoomSpace - totalBoxes} Cubic meters left.");
                
            }


        }

    }
}
