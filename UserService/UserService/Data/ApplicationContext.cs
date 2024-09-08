using Microsoft.EntityFrameworkCore;
using UserService.Data.Entities;

namespace UserService.Data
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>(); 
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DACHI;Database=TaskManagmentUserSystem;Trusted_Connection=True;");
            }
        }
    }
}
