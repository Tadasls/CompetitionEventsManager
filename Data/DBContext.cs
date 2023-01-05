using CompetitionEventsManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;


namespace CompetitionEventsManager.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Horse> Horses { get; set; }
        public DbSet<User> Users { get; set; }
      
     


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Horse>()
         .HasKey(d => d.Id);

     

            modelBuilder.Entity<Horse>()
            .HasData(
                new Horse(1, "The King", "Stasys"),
                new Horse(2, "Perkunas", "Stasys"),
                new Horse(3, "Nabagute", "Linas")

                );








        }

    }
}




