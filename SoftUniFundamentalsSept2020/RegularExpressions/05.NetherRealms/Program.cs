using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Demon> allDemons = new List<Demon>();
            string patternForHealth = @"[A-z]";
            string patternForDmg = @"[+-]?[0-9]+\.?[0-9]*";
            ;
            Regex regexDamage = new Regex(patternForDmg);
            string[] demons = Console.ReadLine().Split(new[] {',',' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var d in demons)
            {
                string exceptions = "0123456789+-/*.";
                int health = d.Where(x=>!exceptions.Contains(x)).Sum(c =>c);
                

                double damage = CalculateDamage(regexDamage, d);

                Demon demon = new Demon();
                allDemons.Add(new Demon { Name = d, Damage = damage, Health = health });
            }

            foreach (var demon in allDemons.OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{demon.Name} - { demon.Health} health, { demon.Damage:f2} damage");
            }
        }

        static double CalculateDamage(Regex regexDamage, string demon)
        {
            double damage = 0;
            MatchCollection nums = regexDamage.Matches(demon);

            foreach (Match match in nums)
            {
                damage += double.Parse(match.Value);
            }

            foreach (var ch in demon)
            {
                if (ch == '*')
                {
                    damage *= 2.0;
                }
                if (ch == '/')
                {
                    damage /= 2.0;
                }
            }

            return damage;
        }
    }
}
