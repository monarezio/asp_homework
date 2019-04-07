using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using reservations_data.Models;
using reservations_data.Repositories.Rooms;
using reservations_web.Controllers.Api;
using Remotion.Linq.Clauses.ResultOperators;
using Xunit;

namespace reservations_tests.Web.Controller.Api
{
    public class RoomsControllerTest
    {

        [Fact]
        public void GetForDateTest()
        {
            IList<Room> rooms = new List<Room>
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
                }
            };
            
            var mock = new Mock<IRoomRepository>();
            mock.Setup(i => i.GetRoomWithReservations(1, DateTime.Today)).Returns(rooms.First());
            mock.Setup(i => i.GetAllRoomsWithReservation(DateTime.Today)).Returns(rooms);

            var controller = new RoomsController(mock.Object);

            IActionResult result = controller.Get(1, DateTime.Today);
            Assert.NotNull(result as JsonResult);
            Assert.True(((JsonResult)result).Value == rooms.First());
        }

    }
}