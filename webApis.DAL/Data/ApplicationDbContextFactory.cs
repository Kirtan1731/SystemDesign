using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace webApis.DAL.Data
{

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
       public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Manually locate the API project folder (adjust if necessary)
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "webApis.API");

            var config = new ConfigurationBuilder()
                .SetBasePath(basePath) // Set the base path correctly
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
