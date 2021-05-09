namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetCover
    {
        public static void Main(string[] args)
        {
            var universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
            var sets = new[]
            {
                new[] { 20 },
                new[] { 1, 5, 20, 30 },
                new[] { 3, 7, 20, 30, 40 },
                new[] { 9, 30 },
                new[] { 11, 20, 30, 40 },
                new[] { 3, 7, 40 }
            };

            var selectedSets = ChooseSets(sets.ToList(), universe.ToList());
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (var set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            var result = new List<int[]>();

            var universeSet = new HashSet<int>(universe);
            var setsSet = new HashSet<int[]>(sets);

            while (universeSet.Count>0)
            {

                // Take me the first which contains the most elements from the other set/collection

                var currentSet = setsSet
                    .OrderByDescending(set=>set.Count(item=>universeSet.Contains(item)))
                    .First();

                foreach (var item in currentSet)
                {
                    universeSet.Remove(item);
                }

                sets.Remove(currentSet);

                result.Add(currentSet);
            }

            return result;
        }
    }
}
