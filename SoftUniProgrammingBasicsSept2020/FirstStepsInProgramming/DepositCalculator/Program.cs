using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reading Deposit, Time, Percent
            //FinalSum=Deposit + Time(Deposit*Percent)
            double Deposit = double.Parse(Console.ReadLine());
            int DepositTime = int.Parse(Console.ReadLine());
            double Percent = double.Parse(Console.ReadLine());
            double Lihva = (Deposit * Percent*0.01); // или да разделим на 100
            double LihvaMonth = Lihva / 12;
            double sum = Deposit + (DepositTime * LihvaMonth);
            
            Console.WriteLine(sum);
            
            
        }
    }
}
