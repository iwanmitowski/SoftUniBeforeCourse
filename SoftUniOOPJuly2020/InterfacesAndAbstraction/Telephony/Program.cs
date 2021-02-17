using System;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            Smartphone smarthpone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (string number in numbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        stationaryPhone.Call(number);
                    }
                    else if (number.Length == 10)
                    {
                        smarthpone.Call(number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid number!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

            }

            foreach (string url in urls)
            {
                try
                {

                    smarthpone.Browse(url);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }
    }
}
