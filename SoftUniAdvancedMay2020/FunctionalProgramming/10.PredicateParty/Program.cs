using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();

            Func<string, string, bool> startsWith = (n, c) => n.StartsWith(c);
            Func<string, string, bool> endsWith = (n, c) => n.EndsWith(c);
            Func<string, int, bool> checkLength = (n, c) => n.Length == c;

            Func<List<string>, List<string>, List<string>> doubleing = (l1, l2) =>
              {
                  foreach (var doubled in l2)
                  {
                      for (int i = 0; i < l1.Count ; i++)
                      {
                          if (l1[i] == doubled)
                          {
                              l1.Insert(i, doubled);
                              i++;
                              break;
                          }
                      }
                  }
                  return l1;
              };
            List<string> filtered = new List<string>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "Party!")
            {
                string action = input[0];
                string command = input[1];
                string criteria = input[2];

                switch (command)
                {
                    case "StartsWith":
                        filtered = guests.Where(x => startsWith(x, criteria))
                            .ToList();
                        break;
                    case "EndsWith":
                        filtered = guests.Where(x => endsWith(x, criteria))
                            .ToList();
                        break;
                    case "Length":
                        filtered = guests.Where(x => checkLength(x, int.Parse(criteria)))
                            .ToList();
                        break;
                    default:
                        break;
                }

                switch (action)
                {
                    case "Remove":
                        guests = guests.Where(x => !filtered.Contains(x)).ToList();
                        break;
                    case "Double":
                        guests = doubleing(guests, filtered);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine().Split();
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
