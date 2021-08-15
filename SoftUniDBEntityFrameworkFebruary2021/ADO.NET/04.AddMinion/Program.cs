using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;

namespace _04.AddMinion
{
    class Program
    {
        const string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string[] input = Console.ReadLine().Split();
            string name = input[1];
            int age = int.Parse(input[2]);
            string townName = input[3];

            var getTownIdQuery = @"SELECT Id FROM Towns WHERE Name = @townName";

            using var getTownIdCommand = new SqlCommand(getTownIdQuery, connection);
            getTownIdCommand.Parameters.AddWithValue("@townName", townName);
            var townId = (int?)getTownIdCommand.ExecuteScalar();

            if (townId==null)
            {
                var insertTownQuery = @"INSERT INTO Towns (Name) VALUES (@townName)";
                using var insertTownCommand = new SqlCommand(insertTownQuery, connection);
                insertTownCommand.Parameters.AddWithValue("@townName", townName);
                insertTownCommand.ExecuteNonQuery();
                townId = (int?)getTownIdCommand.ExecuteScalar();

                Console.WriteLine($"Town {townName} was added to the database.");
            }

            string villainName = Console.ReadLine().Split()[1];

            var getVillainIdQuery = @"SELECT Id FROM Villains WHERE Name = @Name";

            using var getVillainIdCommand = new SqlCommand(getVillainIdQuery, connection);
            getVillainIdCommand.Parameters.AddWithValue("@Name", villainName);
            var villainId = (int?)getVillainIdCommand.ExecuteScalar();

            if (villainId == null)
            {
                var insertVillainQuery = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
                var insertVillainCommand = new SqlCommand(insertVillainQuery, connection);
                insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);
                insertVillainCommand.ExecuteNonQuery();
                villainId = (int?)getVillainIdCommand.ExecuteScalar();

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            var insertMinionQuery = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)";
            using var insertMinionCommand = new SqlCommand(insertMinionQuery, connection);
            insertMinionCommand.Parameters.AddWithValue(@"nam", name);
            insertMinionCommand.Parameters.AddWithValue(@"age", age);
            insertMinionCommand.Parameters.AddWithValue(@"townId", townId);
            insertMinionCommand.ExecuteNonQuery();

            var getMinionIdQuery = @"SELECT Id FROM Minions WHERE Name = @Name";
            using var getMinionIdCommand = new SqlCommand(getMinionIdQuery, connection);
            getMinionIdCommand.Parameters.AddWithValue("@Name", name);
            var minionId = getMinionIdCommand.ExecuteScalar();

            var insertMinionsVillains = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            using var insertMinionsVillainsCommand = new SqlCommand(insertMinionsVillains, connection);
            insertMinionsVillainsCommand.Parameters.AddWithValue("@villainId", villainId);
            insertMinionsVillainsCommand.Parameters.AddWithValue("@minionId", minionId);
            insertMinionsVillainsCommand.ExecuteNonQuery();
            Console.WriteLine($"Successfully added {name} to be minion of {villainName}.");
        }
    }
}
