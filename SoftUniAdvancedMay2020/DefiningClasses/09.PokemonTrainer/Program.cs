using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] trainerInput = Console.ReadLine().Split();
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while (trainerInput[0] != "Tournament")
            {
                string trainerName = trainerInput[0];
                string pokemonName = trainerInput[1];
                string pokemonElement = trainerInput[2];
                int pokemonHealth = int.Parse(trainerInput[3]);

                if (trainers.ContainsKey(trainerName) == false)
                {
                    trainers.Add(trainerName, new Trainer(trainerName, new List<Pokemon>()));
                }
                trainers[trainerName].Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));

                trainerInput = Console.ReadLine().Split();
            }

            string element = Console.ReadLine();
            while (element != "End")
            {
                foreach ((string name, Trainer trainer) in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == element))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            Pokemon currPokemon = trainer.Pokemons[i];
                            currPokemon.Health -= 10;
                            if (currPokemon.Health <= 0)
                            {
                                trainer.Pokemons.Remove(currPokemon);
                                i--;
                            }
                        }
                        
                    }


                }


                element = Console.ReadLine();
            }

            foreach ((string name, Trainer t) in trainers.OrderByDescending(t => t.Value.NumberOfBadges))
            {
                Console.WriteLine($"{t.Name} {t.NumberOfBadges} {t.Pokemons.Count}");
            }
        }
    }
}
