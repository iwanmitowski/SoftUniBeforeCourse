using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> playlist = new Queue<string>(songs);

            string commands = Console.ReadLine();

            while (playlist.Count > 0)
            {
                if (commands.Contains("Play"))
                {
                    playlist.Dequeue();
                    if (playlist.Count == 0)
                    {
                        break;
                    }
                }
                else if (commands.Contains("Add"))
                {
                    string song = commands.Substring(4);
                    if (playlist.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        playlist.Enqueue(song);
                    }
                    
                }
                else if (commands.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", playlist));
                }
                commands = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}
