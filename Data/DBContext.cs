using CompetitionEventsManager.Data.InitialData;
using CompetitionEventsManager.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;


namespace CompetitionEventsManager.Data
{
    /// <summary>
    /// main duombaze
    /// </summary>
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


            modelBuilder.Entity<Event>().HasKey(d => d.EventID);
            modelBuilder.Entity<Event>().HasData(HorseInitialData.EventDataSeed);

            modelBuilder.Entity<Event>()
             .HasMany(ab => ab.Competitions)
             .WithOne(ab => ab.Event)
             .HasForeignKey(ab => ab.EId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Competition>().HasKey(d => d.CompetitionID);
            modelBuilder.Entity<Competition>().HasData(HorseInitialData.CompetitionDataSeed);


            modelBuilder.Entity<Competition>()
                 .HasMany(med => med.Staffs)
                 .WithMany(rev => rev.Competitions)
                 .UsingEntity(ent => ent.ToTable("CompetionStaff")); // many to many

  
            modelBuilder.Entity<Staff>().HasKey(d => d.StaffID);
            modelBuilder.Entity<Staff>().HasData(HorseInitialData.StaffDataSeed);

            modelBuilder.Entity<Competition>()
                .HasMany(ab => ab.Entries)
                .WithOne(ab => ab.Competition)
                .HasForeignKey(ab => ab.CId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LocalUser>().HasKey(d => d.Id);
            modelBuilder.Entity<LocalUser>().HasMany(ab => ab.Entries)
                .WithOne(ab => ab.LocalUser)
                .HasForeignKey(ab => ab.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Entry>().HasKey(d => d.EntryID);
            modelBuilder.Entity<Entry>().HasData(HorseInitialData.EntryDataSeed);

                   
          modelBuilder.Entity<LocalUser>()
                .HasMany(ab => ab.Notifications)
                .WithOne(ab => ab.LocalUser)
                .HasForeignKey(ab => ab.UserId)
                .OnDelete(DeleteBehavior.NoAction);

         modelBuilder.Entity<LocalUser>()
                .HasMany(ab => ab.Riders)
                .WithOne(ab => ab.LocalUser)
                .HasForeignKey(ab => ab.UserId)
                .OnDelete(DeleteBehavior.NoAction);

         modelBuilder.Entity<LocalUser>().HasMany(ab => ab.Horses)
                .WithOne(ab => ab.LocalUser)
                .HasForeignKey(ab => ab.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Notification>().HasKey(d => d.NotificationID);
            modelBuilder.Entity<Notification>().HasData(HorseInitialData.NotificationDataSeed);

            modelBuilder.Entity<Horse>().HasKey(d => d.HorseID);
            modelBuilder.Entity<Horse>().HasData(HorseInitialData.HorseDataSeed);

            modelBuilder.Entity<Rider>().HasKey(d => d.RiderID);
            modelBuilder.Entity<Rider>().HasData(HorseInitialData.RidersDataSeed);



            // modelBuilder.Entity<LocalUser>().HasData(HorseInitialData.LocalUserDataSeed);


            modelBuilder.Entity<Entry>()
              .HasOne(ab => ab.Horse)
             .WithMany(ab => ab.Entries);

            modelBuilder.Entity<Entry>()
             .HasOne(ab => ab.Rider)
             .WithMany(ab => ab.Entries);






        }

    }
}




