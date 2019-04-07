using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using reservations_data.Models;
using reservations_domain.Services.Reservations;
using reservations_web.Controllers;
using reservations_web.Models.Messages;
using Xunit;

namespace reservations_tests.Web.Controller
{
    public class ReservationControllerTest
    {
        [Fact]
        public void PrepareTest()
        {
            Room room = new Room
            {
               RoomId = 1,
               Name = "Test room 1",
               Description = "Testing description...",
               From = new TimeSpan(10, 0, 0),
               To = new TimeSpan(18, 0, 0),
            };
            
            Reservation res = new Reservation
            {
                From = DateTime.Today.AddHours(10),
                To = DateTime.Today.AddDays(11),
                RoomId = room.RoomId,
                Room = room
            };

            var mock = new Mock<IReservationsService>();
            var mockMessages = new Mock<IMessagesService>();

            mock.Setup(i => i.IncludeRoom(new Reservation{ RoomId = 1})).Returns(res);

            ReservationController controller = new ReservationController(mockMessages.Object, mock.Object);
            
            Reservation res2 = new Reservation();

            var result = controller.Prepare(null, null);
            Assert.True(result is RedirectToActionResult);

            var result2 = controller.Prepare(1, null);
            Assert.True(result2 is ViewResult);
            Assert.True(((ViewResult) result2).Model is Reservation);
            Assert.True(((Reservation) ((ViewResult) result2).Model).Room.RoomId == res.RoomId);
        }
    }
}