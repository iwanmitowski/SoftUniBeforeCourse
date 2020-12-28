using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            // price cake, waffle, pancake
            // read   days, bakers, cakeNum, waffleNum, pancakeNum,
            // cakePrice, wafflePrice, pancakePrice, sumForDay=cakePrice + wafflePrice + pancakePrice
            // totalSumForDay = sumForDay * bakers
            // sumCampaign= totalSumForDay*days
            // sumFinal = sumCampaign - sumCampaign/8;



            int cake = 45;
            double waffle = 5.80;
            double pancake = 3.20;

            int days = int.Parse(Console.ReadLine());
            int bakers = int.Parse(Console.ReadLine());
            int cakeNum = int.Parse(Console.ReadLine());
            int waffleNum = int.Parse(Console.ReadLine());
            int pancakeNum = int.Parse(Console.ReadLine());

            double cakePrice = cake * cakeNum;
            double wafflePrice = waffle * waffleNum;
            double pancakePrice = pancake * pancakeNum;
            double sumForDay = (cakePrice + wafflePrice + pancakePrice)*bakers;
            double totalCampaign = sumForDay * days;
           
            double sumFinal = totalCampaign - totalCampaign / 8;
            Console.WriteLine(sumFinal) ;







        }
    }
}
