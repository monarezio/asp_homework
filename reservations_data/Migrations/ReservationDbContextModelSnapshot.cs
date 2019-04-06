﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using reservations_data;

namespace reservations_data.Migrations
{
    [DbContext(typeof(ReservationDbContext))]
    partial class ReservationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("reservations_data.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("From");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<int>("RoomId");

                    b.Property<DateTime>("To");

                    b.HasKey("ReservationId");

                    b.HasIndex("RoomId", "From", "To")
                        .IsUnique();

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            Email = "josef.novy@email.cz",
                            FirstName = "Josef",
                            From = new DateTime(2019, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Nový",
                            PhoneNumber = "+420 724 393 339",
                            RoomId = 1,
                            To = new DateTime(2019, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ReservationId = 2,
                            Email = "karel.stary@email.cz",
                            FirstName = "Karel",
                            From = new DateTime(2019, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Satrý",
                            PhoneNumber = "+420 602 968 359",
                            RoomId = 1,
                            To = new DateTime(2019, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ReservationId = 3,
                            Email = "jindrich.novotny@email.cz",
                            FirstName = "Jindřich",
                            From = new DateTime(2019, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Novotný",
                            PhoneNumber = "+420 724 013 313",
                            RoomId = 2,
                            To = new DateTime(2019, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ReservationId = 4,
                            Email = "david.capka@email.cz",
                            FirstName = "David",
                            From = new DateTime(2019, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Čapka",
                            PhoneNumber = "+420 724 676 776",
                            RoomId = 2,
                            To = new DateTime(2019, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("reservations_data.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<TimeSpan>("From");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<TimeSpan>("To");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus ac leo pretium faucibus. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Pellentesque pretium lectus id turpis. Nullam faucibus mi quis velit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Fusce tellus. Nam quis nulla. Phasellus faucibus molestie nisl. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante.",
                            From = new TimeSpan(0, 9, 0, 0, 0),
                            Name = "Alchemist's Chamber",
                            To = new TimeSpan(0, 20, 0, 0, 0)
                        },
                        new
                        {
                            RoomId = 2,
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus ac leo pretium faucibus. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Pellentesque pretium lectus id turpis. Nullam faucibus mi quis velit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Fusce tellus. Nam quis nulla. Phasellus faucibus molestie nisl. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante.",
                            From = new TimeSpan(0, 8, 0, 0, 0),
                            Name = "Path to Eternity",
                            To = new TimeSpan(0, 20, 0, 0, 0)
                        },
                        new
                        {
                            RoomId = 3,
                            Description = "Lorem Ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus ac leo pretium faucibus. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Pellentesque pretium lectus id turpis. Nullam faucibus mi quis velit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Fusce tellus. Nam quis nulla. Phasellus faucibus molestie nisl. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante.",
                            From = new TimeSpan(0, 12, 0, 0, 0),
                            Name = "Legacy of Ancestors",
                            To = new TimeSpan(0, 18, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("reservations_data.Models.Reservation", b =>
                {
                    b.HasOne("reservations_data.Models.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
