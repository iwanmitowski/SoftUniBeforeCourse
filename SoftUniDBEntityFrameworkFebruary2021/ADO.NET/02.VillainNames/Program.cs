using Microsoft.Data.SqlClient;
using System;

namespace _02.VillainNames
{
    class Program
    {
        const string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var query = @"
  SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
    FROM Villains AS v 
    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
GROUP BY v.Id, v.Name 
  HAVING COUNT(mv.VillainId) > 3 
ORDER BY COUNT(mv.VillainId) DESC";

            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} - {reader[1]}");
            }
        }
    }
}
