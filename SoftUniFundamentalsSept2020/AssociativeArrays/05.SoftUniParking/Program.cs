using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> parking = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string userName = input[1];

                if (input.Length == 3)
                {
                    string licensePlate = input[2];

                    if (parking.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parking[userName]}");
                    }
                    else
                    {
                        parking.Add(userName, licensePlate);
                        Console.WriteLine($"{userName} registered {licensePlate} successfully");
                    }
                }
                else
                {
                    if (parking.ContainsKey(userName)==false)
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                    else
                    {
                        parking.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                    
                }
            }

            foreach (var car in parking)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
    }
}
