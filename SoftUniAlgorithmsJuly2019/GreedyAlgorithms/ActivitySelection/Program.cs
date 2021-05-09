using System;
using System.Collections.Generic;
using System.Linq;

namespace ActivitySelection
{
    class Activity
    {
        public Activity(int start, int finish)
        {
            Start = start;
            Finish = finish;
        }

        public int Start { get; }
        public int Finish { get; }

        public override string ToString()
        {
            return $"{this.Start} - {this.Finish}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            List<Activity> activities = new List<Activity>();

            int[] startTimes = new int[] { 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12 };
            int[] finishTimes = new int[] { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            for (int i = 0; i < startTimes.Length; i++)
            {
                activities.Add(new Activity(startTimes[i], finishTimes[i]));
            }

            var last = activities
                .OrderBy(x => x.Finish)
                .First();

            Console.WriteLine(last);

            foreach (var a in activities)
            {
                if (a.Start>=last.Finish)
                {
                    last = a;
                    Console.WriteLine(a);
                }
            }
        }
    }
}
