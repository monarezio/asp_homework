using Microsoft.AspNetCore.Mvc;
using reservations_data.Repositories.Rooms;
using reservations_web.Models.Rooms;
using reservations_web.Models.Rooms.Factories;

namespace reservations_web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomsViewModelFactory _roomsViewModelFactory;

        public RoomController(IRoomRepository roomRepository, IRoomsViewModelFactory roomsViewModelFactory)
        {
            _roomRepository = roomRepository;
            _roomsViewModelFactory = roomsViewModelFactory;
        }

        public IActionResult Index()
        {
            MiniatureRoomsListViewModel rooms = _roomsViewModelFactory.CreateMiniatureRoomsListViewModel(
                _roomRepository.GetAllRooms()
            );
            return View(rooms);
        }
    }
}