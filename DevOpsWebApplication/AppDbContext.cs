using DevOpsWebApplication.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevOpsWebApplication
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                .Property(x => x.Name).HasMaxLength(100);


            modelBuilder.Entity<User>().HasData(new List<User>
            {
                new()
                {
                    Id = 1,
                    Name = "Irakli Kapanadze",
                    Age = 25,
                },
                new()
                {
                    Id = 2,
                    Name = "Test User",
                    Age = 99,
                }
            });

        }

        DbSet<User> Users { get; set; }
    }
}
