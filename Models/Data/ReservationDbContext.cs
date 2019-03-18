using System;
using System.Collections.Generic;
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

            Room room = new Room("Alchemist's Chamber", 10, 12, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus ac leo pretium faucibus. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Pellentesque pretium lectus id turpis. Nullam faucibus mi quis velit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Fusce tellus. Nam quis nulla. Phasellus faucibus molestie nisl. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante.")
            {
                RoomId = 1
            };
    
            modelBuilder.Entity<Room>().HasData(room);
        
            Reservation res1 = new Reservation("Josef", "Nový", "josef.novy@email.cz", "+420 724 393 339", DateTime.Now)
            {
                ReservationId = 1,
                RoomId = room.RoomId
            };
            Reservation res2 = new Reservation("Karel", "Starý", "karel.stary@email.cz", "+420 602 968 359", DateTime.Now)
            {
                ReservationId = 2,
                RoomId = room.RoomId
            };
            
            modelBuilder.Entity<Reservation>().HasData(res1);
            modelBuilder.Entity<Reservation>().HasData(res2);
        }
    }
}