using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;
using reservations_data;
using reservations_data.Models;

namespace reservations_tests.IntegrationTests.Model
{
    public class TestDbInitializer
    {
        public static void Initialize(ReservationDbContext context)
        {
            if (context.Rooms.Any())
            {
                return;
            }
            context.Rooms.AddRange(GetTestRooms());
            context.SaveChanges();
        }
  
        public static List<Room> GetTestRooms()
        {
            return new List<Room>
            {
                new Room
                {
                    RoomId = 1,
                    Description = "",
                    From = new TimeSpan(10, 0, 0),
                    To = new TimeSpan(18, 0, 0),
                    Reservations = new List<Reservation>
                    {
                        new Reservation
                        {
                            Description = "Testing",
                            Email = "a@a.cz",
                            FirstName = "Sam",
                            LastName = "",
                            From = DateTime.Today.AddHours(11),
                            To = DateTime.Today.AddHours(12),
                            PhoneNumber = "+420 788 900",
                            ReservationId = 1,
                            RoomId = 1
                        }
                    }
                },
                new Room
                {
                    RoomId = 2,
                    Description = "",
                    From = new TimeSpan(12, 0, 0),
                    To = new TimeSpan(20, 0, 0),
                    Reservations = new List<Reservation>
                    {
                        new Reservation
                        {
                            Description = "Testing 2",
                            Email = "b@b.cz",
                            FirstName = "David",
                            LastName = "",
                            From = DateTime.Today.AddHours(18),
                            To = DateTime.Today.AddHours(19),
                            PhoneNumber = "+420 788 910",
                            ReservationId = 2,
                            RoomId = 2
                        },
                        new Reservation
                        {
                            Description = "Testing 3",
                            Email = "c@c.cz",
                            FirstName = "Tom",
                            LastName = "",
                            From = DateTime.Today.AddHours(17),
                            To = DateTime.Today.AddHours(18),
                            PhoneNumber = "+420 788 920",
                            ReservationId = 2,
                            RoomId = 2
                        }
                    }
                }
            };
        }
    }
}