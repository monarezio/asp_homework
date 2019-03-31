using Microsoft.AspNetCore.Mvc;
using reservations_api.Models;
using reservations_data.Repositories.Rooms;

namespace reservations_api.Controllers
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
        public JsonResult Get(DateViewModel date)
        {
            return Json(_roomRepository.GetRoomWithReservations(1, date.Date));
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id, DateViewModel date)
        {
            return Json(_roomRepository.GetRoomWithReservations(id, date.Date));
        }
    }
}