using CompetitionEventsManager.Data.InitialData;
using CompetitionEventsManager.Models;
using Microsoft.EntityFrameworkCore;


namespace CompetitionEventsManager.Data
{
    public class DBContext : DbContext
    {
       
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


            // 1 klausimas

            //modelBuilder.Entity<Notification>()
            //.HasOne<LocalUser>(ab => ab.LocalUser)
            //.WithMany(ab => ab.Notifications)
            //.HasForeignKey(ab => ab.NotificationID); // ar gerai ?








            //       modelBuilder.Entity<Horse>()
            //.HasMany<Rider>(s => s.Riders)
            //.WithMany(c => c.Horses)
            //.Map(cs =>
            //{
            //    cs.MapLeftKey("HorseID");
            //    cs.MapRightKey("RiderID");
            //    cs.ToTable("Performance");
            //});

            //klausimas del rysiu

            //modelBuilder.Entity<Rider>()
            //.HasOne<LocalUser>(ab => ab.LocalUsers)
            //.WithMany(ab => ab.Riders)
            //.HasForeignKey(ab => ab.RiderID);



            //modelBuilder.Entity<Entry>()
            //     .HasKey(bc => new { bc.HorseID, bc.RiderID });
            //modelBuilder.Entity<Entry>()
            //    .HasOne(bc => bc.Horse)
            //    .WithMany(b => b.Entries)
            //    .HasForeignKey(bc => bc.HorseID);
            //modelBuilder.Entity<Entry>()
            //    .HasOne(bc => bc.Rider)
            //    .WithMany(c => c.Entries)
            //    .HasForeignKey(bc => bc.RiderID);







        }

    }
}




