using CompetitionEventsManager.Data.InitialData;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.HorseDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Metadata;


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
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Rider> Riders { get; set; }
        public DbSet<Staff> Staffs { get; set; }
       
      
     


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Competition>().HasKey(d => d.CompetitionID);
            modelBuilder.Entity<Entry>().HasKey(d => d.EntryID);
            modelBuilder.Entity<Event>().HasKey(d => d.EventID);

            modelBuilder.Entity<Horse>().HasKey(d => d.HorseID);
            modelBuilder.Entity<LocalUser>().HasKey(d => d.Id);
            modelBuilder.Entity<Notification>().HasKey(d => d.NotificationID);

            modelBuilder.Entity<Performance>().HasKey(d => d.PerformanceID);
            modelBuilder.Entity<Rider>().HasKey(d => d.RiderID);
            modelBuilder.Entity<Staff>().HasKey(d => d.StaffID);


            modelBuilder.Entity<Competition>().HasData(HorseInitialData.CompetitionDataSeed);
            modelBuilder.Entity<Entry>().HasData(HorseInitialData.EntryDataSeed);
            modelBuilder.Entity<Event>().HasData(HorseInitialData.EventDataSeed);


            modelBuilder.Entity<Horse>().HasData(HorseInitialData.HorseDataSeed);
           // modelBuilder.Entity<LocalUser>().HasData(HorseInitialData.LocalUserDataSeed);
            modelBuilder.Entity<Notification>().HasData(HorseInitialData.NotificationDataSeed);
           

            modelBuilder.Entity<Performance>().HasData(HorseInitialData.PerformanceDataSeed);
            modelBuilder.Entity<Rider>().HasData(HorseInitialData.RidersDataSeed);
            modelBuilder.Entity<Staff>().HasData(HorseInitialData.StaffDataSeed);



            modelBuilder.Entity<LocalUser>()
            .HasOne<Rider>(ab => ab.Rider)
            .WithMany(ab => ab.LocalUsers)
             .HasForeignKey(ab => ab.Id);

            modelBuilder.Entity<LocalUser>()
            .HasOne<Horse>(ab => ab.Horse)
            .WithMany(ab => ab.LocalUsers)
            .HasForeignKey(ab => ab.Id);

            modelBuilder.Entity<LocalUser>()
           .HasOne<Notification>(ab => ab.Notification)
           .WithMany(ab => ab.LocalUsers)
           .HasForeignKey(ab => ab.Id);

            modelBuilder.Entity<LocalUser>()
           .HasOne<Entry>(ab => ab.Entry)
           .WithMany(ab => ab.LocalUsers)
           .HasForeignKey(ab => ab.Id);

            modelBuilder.Entity<Entry>()
           .HasOne<Performance>(ab => ab.Performances)
           .WithMany(ab => ab.Entries)
           .HasForeignKey(ab => ab.EntryID);

            modelBuilder.Entity<Competition>()
            .HasOne<Performance>(ab => ab.Performance)
            .WithMany(ab => ab.Competitions)
            .HasForeignKey(ab => ab.CompetitionID);

            modelBuilder.Entity<Event>()
           .HasOne<Competition>(ab => ab.Competition)
           .WithMany(ab => ab.Events)
           .HasForeignKey(ab => ab.EventID);

            modelBuilder.Entity<Competition>()
           .HasOne<Staff>(ab => ab.Staff)
           .WithMany(ab => ab.Competitions)
           .HasForeignKey(ab => ab.CompetitionID);


            //modelBuilder.Entity<Horse>()
            //  .HasMany<Rider>(s => s.Riders)
            //  .WithMany(c => c.Horses)
            //  .Map(cs =>
            //  {
            //      cs.MapLeftKey("HorseID");
            //      cs.MapRightKey("RiderID");
            //      cs.ToTable("Performance");
            //  });





        }

    }
}




