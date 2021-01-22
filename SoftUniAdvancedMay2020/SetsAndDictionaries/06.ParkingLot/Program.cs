using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            string[] input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);

            while (input[0]!="END")
            {
                string parameter = input[0];
                string car = input[1];

                if (parameter=="IN")
                {
                    parking.Add(car);
                }
                else if (parameter=="OUT")
                {
                    parking.Remove(car);
                }

                input = Console.ReadLine().Split(", ");
            }

            if (parking.Count>0)
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            
        }
    }
}
