using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BestLecturesShcedule
{
    class Program
    {
        static void Main(string[] args)
        {
            int lecturesCount = int.Parse(Console.ReadLine().Split().ToArray()[1]);

            List<Lecture> allLectures = new List<Lecture>();

            for (int i = 0; i < lecturesCount; i++)
            {
                string[] lectureTokens = Console.ReadLine().Split().ToArray();

                string name = lectureTokens[0];
                
                int s = int.Parse(lectureTokens[1]);
                int f = int.Parse(lectureTokens[3]);
                

                Lecture lecture = new Lecture(name, s, f);

                allLectures.Add(lecture);
            }

            var last = allLectures.OrderBy(x => x.Finish).FirstOrDefault();

            List<Lecture> visited = new List<Lecture>();
            visited.Add(last);

            foreach (var l in allLectures)
            {
                if (l.Start>last.Finish)
                {
                    last = l;
                    visited.Add(last);
                }
            }

            Console.WriteLine($"Lectures {visited.Count}");

            foreach (var v in visited)
            {
                Console.WriteLine(v);
            }
        }
    }
    class Lecture
    {
        public Lecture(string name, int start, int finish)
        {
            Name = name;
            Start = start;
            Finish = finish;
        }

        public string Name { get; }
        public int Start { get;}
        public int Finish { get;}

        public override string ToString()
        {
            return $"{this.Start}-{this.Finish} -> {this.Name}";
        }
    }
}
