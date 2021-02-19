using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IHero> heroes = new List<IHero>();

            int n = int.Parse(Console.ReadLine());
            ConcreteCreator heroCreator = new ConcreteCreator();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    heroes.Add(heroCreator.FactoryMethod(type,name));
                }
                catch (InvalidHeroException ex)
                {
                    i--;
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            int bossHealth = int.Parse(Console.ReadLine());

            foreach (IHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                bossHealth-=hero.Power;
            }

            if (bossHealth>0)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }
    }
}
