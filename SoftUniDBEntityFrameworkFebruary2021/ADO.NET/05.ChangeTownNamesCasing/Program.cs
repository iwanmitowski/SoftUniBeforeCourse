using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ChangeTownNamesCasing
{
    class Program
    {
        const string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string country = Console.ReadLine();

         
            var updateTownsQuery = @"UPDATE Towns
   SET Name = UPPER(Name)
 WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
            using var updateTownsCommand = new SqlCommand(updateTownsQuery, connection);
            updateTownsCommand.Parameters.AddWithValue("@countryName", country);

            int rowsChanged = updateTownsCommand.ExecuteNonQuery();

            if (rowsChanged==0)
            {
                Console.WriteLine("No town names were affected.");
                Environment.Exit(0);
            }

            var getTowns = @" SELECT t.Name 
   FROM Towns as t
   JOIN Countries AS c ON c.Id = t.CountryCode
  WHERE c.Name = @countryName";
            using var getTownsCommand = new SqlCommand(getTowns, connection);
            getTownsCommand.Parameters.AddWithValue("@countryName", country);
            using var reader = getTownsCommand.ExecuteReader();

            List<string> towns = new List<string>();
            while (reader.Read())
            {
                towns.Add(reader[0].ToString());
            }
            Console.WriteLine($"{rowsChanged} town names were affected.");
            Console.WriteLine($"[{string.Join(", ",towns)}].");
        }
    }
}
