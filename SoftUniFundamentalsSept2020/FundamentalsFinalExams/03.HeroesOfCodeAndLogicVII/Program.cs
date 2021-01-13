using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Hero> heroes = new List<Hero>();

            for (int i = 0; i < n; i++)
            {
                string[] heroInput = Console.ReadLine().Split();
                string name = heroInput[0];
                int hp = int.Parse(heroInput[1]);
                int mp = int.Parse(heroInput[2]);

                if (hp > 100)
                {
                    hp = 100;
                }

                if (mp > 200)
                {
                    mp = 200;
                }

                heroes.Add(new Hero(name, hp, mp));
            }

            string[] action = Console.ReadLine().Split(" - ");
            while (action[0] != "End")
            {
                string activity = action[0];
                string name = action[1];

                if (activity == "CastSpell")
                {
                    int mpNeeded = int.Parse(action[2]);
                    string spell = action[3];

                    foreach (Hero hero in heroes)
                    {
                        if (hero.Name == name)
                        {
                            if (mpNeeded <= hero.MP)
                            {
                                hero.MP -= mpNeeded;
                                Console.WriteLine($"{hero.Name} has successfully cast {spell} and now has {hero.MP} MP!");
                            }
                            else
                            {
                                Console.WriteLine($"{hero.Name} does not have enough MP to cast {spell}!");
                            }
                            break;
                        }
                    }
                }
                else if (activity == "TakeDamage")
                {
                    int dmg = int.Parse(action[2]);
                    string attacker = action[3];

                    foreach (Hero hero in heroes)
                    {
                        if (hero.Name == name)
                        {
                            hero.HP -= dmg;
                            if (hero.HP > 0)
                            {
                                Console.WriteLine($"{hero.Name} was hit for {dmg} HP by {attacker} and now has {hero.HP} HP left!");
                            }
                            else
                            {
                                Console.WriteLine($"{hero.Name} has been killed by {attacker}!");
                                heroes.Remove(hero);
                            }
                            break;
                        }

                    }
                }
                else if (activity == "Recharge")
                {
                    int amount = int.Parse(action[2]);
                    foreach (Hero hero in heroes)
                    {
                        if (hero.Name == name)
                        {
                            int previous = hero.MP;
                            hero.MP += amount;

                            if (hero.MP > 200)
                            {
                               
                                hero.MP = 200;
                                int mana = hero.MP - previous;
                               
                                Console.WriteLine($"{hero.Name} recharged for {mana} MP!");
                            }
                            else
                            {
                                Console.WriteLine($"{hero.Name} recharged for {amount} MP!");
                            }
                            break;
                        }


                    }
                }
                else if (activity == "Heal")
                {
                    int amount = int.Parse(action[2]);
                    foreach (Hero hero in heroes)
                    {
                        if (hero.Name == name)
                        {
                            int previous = hero.HP;
                            hero.HP += amount;
                            if (hero.HP > 100)
                            {
                                
                                hero.HP = 100;
                                int health = hero.HP - previous;
                                
                                Console.WriteLine($"{hero.Name} healed for {health} HP!");
                            }
                            else
                            {
                                Console.WriteLine($"{hero.Name} healed for {amount} HP!");
                            }
                            break;
                        }

                    }
                }

                action = Console.ReadLine().Split(" - ");
            }
            foreach (Hero hero in heroes.OrderByDescending(x => x.HP).ThenBy(x => x.Name))
            {
                Console.WriteLine(hero.Name);
                Console.WriteLine($"  HP: {hero.HP}");
                Console.WriteLine($"  MP: {hero.MP}");
            }
        }
    }
    class Hero
    {
        public Hero(string name, int hP, int mP)
        {
            Name = name;
            HP = hP;
            MP = mP;
        }

        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
    }

}
