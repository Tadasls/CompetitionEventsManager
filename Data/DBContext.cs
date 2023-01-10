using CompetitionEventsManager.Data.InitialData;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.HorseDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace CompetitionEventsManager.Data
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Horse> Horses { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Rider> Riders { get; set; }
        public DbSet<Staff> Staffs { get; set; }
       
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Competition>().HasKey(d => d.CompetitionID);
            modelBuilder.Entity<Event>().HasKey(d => d.EventID);
            modelBuilder.Entity<Horse>().HasKey(d => d.HorseID);
            modelBuilder.Entity<LocalUser>().HasKey(d => d.Id);
            modelBuilder.Entity<Notification>().HasKey(d => d.NotificationID);
            modelBuilder.Entity<Rider>().HasKey(d => d.RiderID);
            modelBuilder.Entity<Staff>().HasKey(d => d.StaffID);
            modelBuilder.Entity<Entry>().HasKey(x => new { x.HorseID, x.RiderID });

            modelBuilder.Entity<Competition>().HasData(HorseInitialData.CompetitionDataSeed);
            modelBuilder.Entity<Entry>().HasData(HorseInitialData.EntryDataSeed);
            modelBuilder.Entity<Event>().HasData(HorseInitialData.EventDataSeed);
            modelBuilder.Entity<Horse>().HasData(HorseInitialData.HorseDataSeed);
            modelBuilder.Entity<Notification>().HasData(HorseInitialData.NotificationDataSeed);
            modelBuilder.Entity<Rider>().HasData(HorseInitialData.RidersDataSeed);
            modelBuilder.Entity<Staff>().HasData(HorseInitialData.StaffDataSeed);
            // modelBuilder.Entity<LocalUser>().HasData(HorseInitialData.LocalUserDataSeed);



            //       modelBuilder.Entity<Horse>()
            //.HasMany<Rider>(s => s.Riders)
            //.WithMany(c => c.Horses)
            //.Map(cs =>
            //{
            //    cs.MapLeftKey("HorseID");
            //    cs.MapRightKey("RiderID");
            //    cs.ToTable("Performance");
            //});



            //modelBuilder.Entity<Rider>()
            //.HasOne<LocalUser>(ab => ab.LocalUsers)
            //.WithMany(ab => ab.Riders)
            //.HasForeignKey(ab => ab.RiderID);









        }

    }
}




