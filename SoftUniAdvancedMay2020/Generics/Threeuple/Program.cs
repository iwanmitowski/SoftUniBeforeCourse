using System;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split();
            string name = $"{firstInput[0]} {firstInput[1]}";
            string town = $"{firstInput[3]}";

            if (firstInput.Length>4)
            {
               town = $"{firstInput[3]} {firstInput[4]}";

            }
            Threeuple<string,string,string> threeuple1 = new Threeuple<string, string, string>(name,firstInput[2],town);
            Console.WriteLine(threeuple1);

            string[] secondInput = Console.ReadLine().Split();

            bool isDrunk = false;
            if (secondInput[2]== "drunk")
            {
                isDrunk = true;
            }
            Threeuple<string, int, bool> threeuple2 = new Threeuple<string, int, bool>(secondInput[0], int.Parse(secondInput[1]), isDrunk);
            Console.WriteLine(threeuple2);

            string[] thirdInput = Console.ReadLine().Split();

            string number = $"{double.Parse(thirdInput[1]):f2}";
            Threeuple<string, double, string> threeuple3 = new Threeuple<string, double, string>(thirdInput[0], double.Parse(number), thirdInput[2]) ;
            Console.WriteLine(threeuple3);
        }
    }
}
