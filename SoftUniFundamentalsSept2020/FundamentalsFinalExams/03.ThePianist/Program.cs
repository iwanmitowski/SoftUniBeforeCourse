using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Piece> pieces = new List<Piece>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|");
                string name = input[0];
                string composer = input[1];
                string key = input[2];
                pieces.Add(new Piece(name, composer, key));
            }

            string[] commands = Console.ReadLine().Split("|");
            while (commands[0] != "Stop")
            {
                string action = commands[0];
                string name = commands[1];

                if (action == "Add")
                {
                    string composer = commands[2];
                    string key = commands[3];

                    if (IsExistingPiece(pieces, name))
                    {
                        Console.WriteLine($"{name} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(new Piece(name, composer, key));
                        Console.WriteLine($"{name} by {composer} in {key} added to the collection!");
                    }
                }
                else if (action == "Remove")
                {
                    if (IsExistingPiece(pieces, name))
                    {
                        foreach (Piece piece in pieces)
                        {
                            if (piece.Name==name)
                            {
                                pieces.Remove(piece);
                                Console.WriteLine($"Successfully removed {name}!");
                                break;
                            }
                           
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
                    }
                }
                else if (action == "ChangeKey")
                {
                    string newKey = commands[2];
                    if (IsExistingPiece(pieces, name))
                    {
                        foreach (Piece piece in pieces)
                        {
                            if (piece.Name == name)
                            {
                                piece.Key = newKey;
                                Console.WriteLine($"Changed the key of {name} to {newKey}!");
                                break;
                            }
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
                    }
                }

                commands = Console.ReadLine().Split("|");
            }
            foreach (Piece piece in pieces.OrderBy(x=>x.Name).ThenBy(x=>x.Composer))
            {
                Console.WriteLine(piece);
            }
        }

        static bool IsExistingPiece(List<Piece> pieces, string name)
        {
            foreach (Piece piece in pieces)
            {
                if (piece.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
    }

    class Piece
    {
        public Piece(string name, string composer, string key)
        {
            Name = name;
            Composer = composer;
            Key = key;
        }

        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
        public override string ToString()
        {
            return $"{Name} -> Composer: {Composer}, Key: {Key}";
        }
    }

}
