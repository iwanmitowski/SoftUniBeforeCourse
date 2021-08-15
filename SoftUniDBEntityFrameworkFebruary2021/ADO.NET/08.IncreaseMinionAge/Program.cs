using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _08.IncreaseMinionAge
{
    class Program
    {
        const string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();

            

            foreach (var id in ids)
            {
                var updateAgeQuery = @"UPDATE Minions
   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
 WHERE Id = @Id";
                var updateAgeCommand = new SqlCommand(updateAgeQuery, connection);
                updateAgeCommand.Parameters.AddWithValue("@Id", id);
                updateAgeCommand.ExecuteNonQuery();
            }
            foreach (var id in ids)
            {

                var query = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} {reader[1]}");
                }
            }


        }
    }
}
