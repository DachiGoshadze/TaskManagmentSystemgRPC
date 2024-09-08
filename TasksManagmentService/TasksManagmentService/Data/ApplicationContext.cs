using Microsoft.EntityFrameworkCore;
using TasksManagmentService.Data.Entities;


namespace TasksManagmentService.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Space> Spaces => Set<Space>();
        public DbSet<TaskAssignment> Tasks => Set<TaskAssignment>();
        public DbSet<Status> Statuses => Set<Status>();
        public DbSet<UserSpaces> UserSpaces => Set<UserSpaces>();
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DACHI;Database=TaskManagmentSystem;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskAssignment>()
                .HasKey(t => t.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
