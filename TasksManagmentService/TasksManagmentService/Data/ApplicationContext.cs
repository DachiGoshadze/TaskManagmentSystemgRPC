using Microsoft.EntityFrameworkCore;
using UserService.Data.Entities;

namespace UserService.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>(); 
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UGPA4P6\\SQLEXPRESS;Database=TaskManagmentSystem;Trusted_Connection=True;");
        }
    }
}
