using Microsoft.Data.SqlClient;
using System;

namespace _03.MinionNames
{
    class Program
    {
        const string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string[] minionData = Console.ReadLine().Split();

            string minionName = minionData[1];
            int age = int.Parse(minionData[2]);
            string town = minionData[3];


        }
    }
}
