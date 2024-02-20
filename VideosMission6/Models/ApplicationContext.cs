using Microsoft.EntityFrameworkCore;

namespace VideosMission6.Models
{
    public class ApplicationContext : DbContext // Liaison from the app to the database
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options) 
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Major> Majors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Seed Data
        {
            modelBuilder.Entity<Major>().HasData(

                new Major { MajorId = 1, MajorName = "Information Systems" },
                new Major { MajorId = 2, MajorName = "Computer Science" },
                new Major { MajorId = 3, MajorName = "Magic" },
                new Major { MajorId = 4, MajorName = "Business" },
                new Major { MajorId = 5, MajorName = "Banana" }
                );
        }
    }
}
