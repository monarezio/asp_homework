using System;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using reservations_data.Models;

namespace reservations_data
{
    public class ReservationDbContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public ReservationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            SetupIndexes(modelBuilder);
            FillDb(modelBuilder);
        }

        //TODO: Put the private methods into a helper class?
        private void SetupIndexes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasIndex(i => new
                {
                    i.RoomId, i.From, i.To
                })
                .IsUnique();
        }

        private void FillDb(ModelBuilder modelBuilder)
        {
            Room room = new Room
            {
                RoomId = 1,
                Name = "Alchemist's Chamber",
                From = 9,
                To = 18,
                Description =
                    "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus ac leo pretium faucibus. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Pellentesque pretium lectus id turpis. Nullam faucibus mi quis velit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Fusce tellus. Nam quis nulla. Phasellus faucibus molestie nisl. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante."
            };

            Room room2 = new Room
            {
                RoomId = 2,
                Name = "Path to Eternity",
                From = 8,
                To = 20,
                Description =
                    "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus ac leo pretium faucibus. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Pellentesque pretium lectus id turpis. Nullam faucibus mi quis velit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Fusce tellus. Nam quis nulla. Phasellus faucibus molestie nisl. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante."
            };

            Room room3 = new Room
            {
                RoomId = 3,
                Name = "Legacy of Ancestors",
                From = 8,
                To = 19,
                Description =
                    "Lorem Ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus ac leo pretium faucibus. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Pellentesque pretium lectus id turpis. Nullam faucibus mi quis velit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Fusce tellus. Nam quis nulla. Phasellus faucibus molestie nisl. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante."
            };

            modelBuilder.Entity<Room>().HasData(room);
            modelBuilder.Entity<Room>().HasData(room2);
            modelBuilder.Entity<Room>().HasData(room3);

            DateTime res1DateTime = new DateTime(2019, 1, 1, 10, 0, 0);
            Reservation res1 = new Reservation
            {
                ReservationId = 1,
                RoomId = room.RoomId,
                FristName = "Josef",
                LastName = "Nový",
                Email = "josef.novy@email.cz",
                PhoneNumber = "+420 724 393 339",
                From = res1DateTime,
                To = res1DateTime.AddHours(1)
            };

            DateTime res2DateTime = new DateTime(2019, 1, 1, 11, 0, 0);
            Reservation res2 = new Reservation
            {
                ReservationId = 2,
                RoomId = room.RoomId,
                FristName = "Karel",
                LastName = "Satrý",
                Email = "karel.stary@email.cz",
                PhoneNumber = "+420 602 968 359",
                From = res2DateTime,
                To = res2DateTime.AddHours(1)
            };

            DateTime res3DateTime = new DateTime(2019, 1, 1, 9, 0, 0);
            Reservation res3 = new Reservation
            {
                ReservationId = 3,
                RoomId = room2.RoomId,
                FristName = "Jindřich",
                LastName = "Novotný",
                Email = "jindrich.novotny@email.cz",
                PhoneNumber = "+420 724 013 313",
                From = res3DateTime,
                To = res3DateTime.AddHours(1)
            };

            DateTime res4DateTime = new DateTime(2019, 1, 1, 11, 0, 0);
            Reservation res4 =
                new Reservation
                {
                    ReservationId = 4,
                    RoomId = room2.RoomId,
                    FristName = "David",
                    LastName = "Čapka",
                    Email = "david.capka@email.cz",
                    PhoneNumber = "+420 724 676 776",
                    From = res4DateTime,
                    To = res4DateTime.AddHours(1)
                };

            modelBuilder.Entity<Reservation>().HasData(res1);
            modelBuilder.Entity<Reservation>().HasData(res2);
            modelBuilder.Entity<Reservation>().HasData(res3);
            modelBuilder.Entity<Reservation>().HasData(res4);
        }
    }
}