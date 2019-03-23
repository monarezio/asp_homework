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
                .HasIndex(i => new
                {
                    i.RoomId, i.Date
                }) //TODO: Think about the adding a DateFrom and DateTo, which would all be unique and therefor save me some validations
                .IsUnique();

            Room room = new Room("Alchemist's Chamber", 9, 18,
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus ac leo pretium faucibus. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Pellentesque pretium lectus id turpis. Nullam faucibus mi quis velit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Fusce tellus. Nam quis nulla. Phasellus faucibus molestie nisl. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante.")
            {
                RoomId = 1
            };

            Room room2 = new Room("Path to Eternity", 8, 20,
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus ac leo pretium faucibus. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Pellentesque pretium lectus id turpis. Nullam faucibus mi quis velit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Fusce tellus. Nam quis nulla. Phasellus faucibus molestie nisl. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante.")
            {
                RoomId = 2
            };

            Room room3 = new Room("Legacy of Ancestors", 8, 19)
            {
                RoomId = 3
            };

            modelBuilder.Entity<Room>().HasData(room);

            Reservation res1 = new Reservation(
                "Josef",
                "Nový",
                "josef.novy@email.cz",
                "+420 724 393 339",
                new DateTime(2019, 1, 1, 10, 0, 0)
            )
            {
                ReservationId = 1,
                RoomId = room.RoomId
            };
            Reservation res2 = new Reservation(
                "Karel",
                "Starý",
                "karel.stary@email.cz",
                "+420 602 968 359",
                new DateTime(2019, 1, 1, 11, 0, 0)
            )
            {
                ReservationId = 2,
                RoomId = room.RoomId
            };

            Reservation res3 = new Reservation(
                "Jindřich",
                "Novotný",
                "jindrich.novotny@email.cz",
                "+420 724 013 313",
                new DateTime(2019, 1, 1, 9, 0, 0))
            {
                ReservationId = 3,
                RoomId = room2.RoomId
            };
            Reservation res4 =
                new Reservation(
                    "David",
                    "Čapka",
                    "david.capka@email.cz",
                    "+420 724 676 776",
                    new DateTime(2019, 1, 1, 11, 0, 0)
                )
                {
                    ReservationId = 4,
                    RoomId = room2.RoomId
                };

            modelBuilder.Entity<Reservation>().HasData(res1);
            modelBuilder.Entity<Reservation>().HasData(res2);
            modelBuilder.Entity<Reservation>().HasData(res3);
            modelBuilder.Entity<Reservation>().HasData(res4);
        }
    }
}