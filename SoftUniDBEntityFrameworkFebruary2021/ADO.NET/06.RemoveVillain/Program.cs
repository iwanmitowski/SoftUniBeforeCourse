using Microsoft.Data.SqlClient;
using System;

namespace _06.RemoveVillain
{
    class Program
    {
        const string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var villainId = int.Parse(Console.ReadLine());

            var getVillainNameQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";

            using var getVillainNameCommand = new SqlCommand(getVillainNameQuery, connection);
            getVillainNameCommand.Parameters.AddWithValue("@villainId", villainId);
            var villainName = getVillainNameCommand.ExecuteScalar();

            if (villainName==null)
            {
                Console.WriteLine("No such villain was found.");
                Environment.Exit(0);
            }

            var deleteMinionsVillainsQuery = @"DELETE FROM MinionsVillains 
      WHERE VillainId = @villainId";
            using var deleteMinionsVillainsCommand = new SqlCommand(deleteMinionsVillainsQuery, connection);
            deleteMinionsVillainsCommand.Parameters.AddWithValue("@villainId", villainId);

            int affectedRows = deleteMinionsVillainsCommand.ExecuteNonQuery();

            var deleteVillain = @"DELETE FROM Villains
      WHERE Id = @villainId";
            using var deleteVillainCommand = new SqlCommand(deleteVillain, connection);
            deleteVillainCommand.Parameters.AddWithValue("@villainId", villainId);
            deleteVillainCommand.ExecuteNonQuery();

            Console.WriteLine($"{villainName} was deleted.");
            Console.WriteLine($"{affectedRows} minions were released.");

        }
    }
}
