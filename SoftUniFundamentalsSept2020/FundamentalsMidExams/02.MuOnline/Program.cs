using System;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine()
                .Split(new[] {" ","|"}, StringSplitOptions.RemoveEmptyEntries);

            int health = 100;
            int bitcoins = 0;
            int completedRooms = 1;
            bool isWinner = true;

            for (int i = 0; i < rooms.Length; i+=2)
            {
                
                string action = rooms[i]; //or monster 
                int value = int.Parse(rooms[i+1]);

                if (action == "potion")
                {
                    health += value;
                    if (health>100)
                    {
                        value = 100 - health + value ;
                        health = 100;

                    }
                    Console.WriteLine($"You healed for {value} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (action == "chest")
                {
                    bitcoins += value;
                    Console.WriteLine($"You found {value} bitcoins.");
                }
                else
                {
                    //monster
                    health -= value;
                    if (health>0)
                    {
                        Console.WriteLine($"You slayed {action}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {action}.");
                        Console.WriteLine($"Best room: {completedRooms}");
                        isWinner = false;
                        break;
                    }
                }
                completedRooms++;

            }
            if (isWinner)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
