using asp_homework.Models.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_homework.Models.Data
{
    public class ReservationDbContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public ReservationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Reservation>()
                .HasIndex(i => new { i.RoomId, i.Date }) //TODO: Think about the adding a DateFrom and DateTo, which would all be unique and therefor save me some validations
                .IsUnique();
        }
    }
}