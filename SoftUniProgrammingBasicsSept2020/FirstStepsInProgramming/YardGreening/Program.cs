using System;
using System.Runtime.ConstrainedExecution;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read meters
            // greening=meters*7.61
            // discount=0.18*greening
            // finalSum=greening-discount
            double meters = double.Parse(Console.ReadLine());
            double greening = meters * 7.61;
            double discount = 0.18 * greening;
            double finalSum = greening - discount;
            Console.WriteLine($"The final price is: {finalSum} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
