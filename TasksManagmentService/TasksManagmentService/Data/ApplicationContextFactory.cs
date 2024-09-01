using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using UserService.Data;

namespace ShopApp.DB
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            optionsBuilder.UseSqlServer("Server=DESKTOP-UGPA4P6\\SQLEXPRESS;Database=TaskManagmentSystem;Trusted_Connection=True;");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}