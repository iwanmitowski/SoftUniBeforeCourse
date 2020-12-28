using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            // дава грешка ?!
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermans = int.Parse(Console.ReadLine());

            double rent = 0;
            if (season == "Spring")
            {
                rent = 3000;
                if (fishermans<=6)
                {
                    rent -= rent * 0.10;
                }
                else if (fishermans>=7 && fishermans<=11)
                {
                    rent -= rent * 0.15;
                }
                else if (fishermans>=12)
                {
                    rent -= rent * 0.25;
                }
            }
            else if (season == "Summer" || season == "Autumn")
            {
                rent = 4200;
                if (fishermans <= 6)
                {
                    rent -= rent * 0.10;
                }
                else if (fishermans >= 7 && fishermans <= 11)
                {
                    rent -= rent * 0.15;
                }
                else if (fishermans >= 12)
                {
                    rent -= rent * 0.25;
                }

            }
            else if (season == "Winter")
            {
                rent = 2600;
                if (fishermans <= 6)
                {
                    rent -= rent * 0.10;
                }
                else if (fishermans >= 7 && fishermans <= 11)
                {
                    rent -= rent * 0.15;
                }
                else if (fishermans >= 12)
                {
                    rent -= rent * 0.25;
                }

            }
            if (fishermans % 2 == 0 && season != "Autumn")
            {
                rent -= rent* 0.5;
            }

            if (rent<=budget)
            {
                Console.WriteLine($"Yes! You have {budget-rent:f2} leva left.");
            }
            else if (budget<rent)
            {
                Console.WriteLine($"Not enough money! You need {rent-budget:f2} leva.");
            }
            

        }
    }
}
