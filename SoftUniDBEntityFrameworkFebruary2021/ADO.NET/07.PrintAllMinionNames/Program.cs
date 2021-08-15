using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _07.PrintAllMinionNames
{
    class Program
    {
        const string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var query = @"SELECT Name FROM Minions";

            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            var minions = new List<string>();
            while (reader.Read())
            {
                minions.Add(reader[0].ToString());
            }

            for (int i = 0; i < minions.Count / 2; i++)
            {
                Console.WriteLine(minions[i]);
                Console.WriteLine(minions[minions.Count - 1 - i]);
            }

            if (minions.Count % 2 != 0)
            {
                Console.WriteLine(minions[minions.Count/2]);
            }
        }
    }
}
