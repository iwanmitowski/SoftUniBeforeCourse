using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> keyCountSameASInputCount = new List<int>();
            string decreased = string.Empty;

            string input = Console.ReadLine();
            int counter = 0;

            while (input != "find")
            {
                if (keys.Length < input.Length)
                {
                    for (int i = 0; i < keys.Length; i++)
                    {
                        if (input.Length > keyCountSameASInputCount.Count())
                        {
                            keyCountSameASInputCount.Add(keys[i]);
                            counter++;
                        }
                        else if (input.Length == keyCountSameASInputCount.Count())
                        {
                            break;
                        }
                        if (counter == keys.Length)
                        {
                            counter = 0;
                            i = -1;
                        }

                    }

                    for (int i = 0; i < keyCountSameASInputCount.Count; i++)
                    {
                        int currKey = keyCountSameASInputCount[i];
                        int currChar = (int)input[i];

                        decreased += ((char)(currChar - currKey));
                    }

                    int oreStartIndex = decreased.IndexOf('&') + 1;
                    int oreEndIndex = decreased.LastIndexOf('&');

                    string ore = decreased.Substring(oreStartIndex, oreEndIndex - oreStartIndex);

                    int locationStartIndex = decreased.IndexOf('<') + 1;
                    int locationEndIndex = decreased.IndexOf('>');

                    string location = decreased.Substring(locationStartIndex, locationEndIndex - locationStartIndex);

                    Console.WriteLine($"Found {ore} at {location}");
                }
                

                
                input = Console.ReadLine();
                decreased = string.Empty;
            }


        }
    }
}
