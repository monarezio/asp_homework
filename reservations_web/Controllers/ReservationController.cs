using System;
using Microsoft.AspNetCore.Mvc;
using reservations_data.Models;
using reservations_data.Repositories.Rooms;
using reservations_web.Models.Rooms;
using reservations_web.Models.Rooms.Factories;

namespace reservations_web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomsViewModelFactory _roomsViewModelFactory;
        
        // GET
        public ReservationController(IRoomRepository roomRepository, IRoomsViewModelFactory roomsViewModelFactory)
        {
            _roomRepository = roomRepository;
            _roomsViewModelFactory = roomsViewModelFactory;
        }

        public IActionResult Create(int id)
        {
            RoomViewModel room = _roomsViewModelFactory.CreateRoomViewModel(_roomRepository.GetRoom(id));
            return View(room);
        }
    }
}