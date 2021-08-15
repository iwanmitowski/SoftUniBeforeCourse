using Microsoft.Data.SqlClient;
using System;

namespace _09.IncreaseAgeStoredProcedure
{
    class Program
    {
        const string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            int id = int.Parse(Console.ReadLine());

            var updateQuery = @"EXEC usp_GetOlder @Id";
            var updateCommand = new SqlCommand(updateQuery, connection);
            updateCommand.Parameters.AddWithValue("@Id", id);
            updateCommand.ExecuteNonQuery();

            var selectQuery = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
            var selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@Id", id);
            using var reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} - {reader[1]} years old");
            }

        }
    }
}
