using System;
using System.Collections.Generic;

namespace Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numSongs; i++)
            {
                string[] currSong = Console.ReadLine().Split("_");

                string type = currSong[0];
                string name = currSong[1];

                Song song = new Song();
                song.TypeList = type;
                song.Name = name;

                songs.Add(song);
            }

            string typeList = Console.ReadLine();

            if (typeList=="all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }

            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
}
