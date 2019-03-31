using System;
using Microsoft.AspNetCore.Mvc;
using reservations_data.Repositories.Rooms;

namespace reservations_web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        
        [HttpGet]
        public JsonResult Get([FromQuery(Name = "date")] DateTime date)
        {
            return Json(_roomRepository.GetAllRoomsWithReservation(date));
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id, [FromQuery(Name = "date")] DateTime date)
        {
            return Json(_roomRepository.GetRoomWithReservations(id, date.Date));
        }
    }
}