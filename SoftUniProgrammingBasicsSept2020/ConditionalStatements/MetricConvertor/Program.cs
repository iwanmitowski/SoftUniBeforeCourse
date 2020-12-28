using System;

namespace MetricConvertor
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            string inputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();

            if (inputUnit=="mm"&&outputUnit=="m")
            {
                Console.WriteLine($"{num/1000:F3}");
            }
            else if(inputUnit == "mm" && outputUnit == "cm")
            {
                Console.WriteLine($"{num/10:F3}");
            }
            else if (inputUnit == "cm" && outputUnit == "mm")
            {
                Console.WriteLine($"{num*10:F3}");
            }
            else if (inputUnit == "cm" && outputUnit == "m")
            {
                Console.WriteLine($"{num/100:F3}");
            }
            else if (inputUnit == "m" && outputUnit == "cm")
            {
                Console.WriteLine($"{num*100:F3}");
            }
            else if (inputUnit == "m" && outputUnit == "mm")
            {
                Console.WriteLine($"{num*1000:F3}");
            }

        }
    }
}
