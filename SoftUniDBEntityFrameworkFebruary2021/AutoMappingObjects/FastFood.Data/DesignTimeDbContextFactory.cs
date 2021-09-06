using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FastFood.Data
{
    class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FastFoodContext>
    {
        public FastFoodContext CreateDbContext(string[] args)
        {
            //requires Microsoft.Extensions.Configuration.Json 
            //and appsettings.json with DefaultConnection in it

            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory()) 
               .AddJsonFile("appsettings.json")
               .Build();

            var builder = new DbContextOptionsBuilder<FastFoodContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new FastFoodContext(builder.Options);
        }
    }
}
