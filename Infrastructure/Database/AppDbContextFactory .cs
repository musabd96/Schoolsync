using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace Infrastructure.Database
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Build configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Path.Combine(AppContext.BaseDirectory, "../../../../ReactApp/ReactApp.Server"))
                .AddJsonFile("appsettings.json")
                .Build();

            // Create options
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 34)));

            return new AppDbContext(optionsBuilder.Options);
        }

    }
}
