using Microsoft.AspNetCore.Mvc;
using reservations_data.Models;
using reservations_data.Repositories.Reservations;
using reservations_data.Repositories.Rooms;
using reservations_domain.Services.Reservations;
using reservations_web.Models.Messages;

namespace reservations_web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;
        private IMessagesService _messageService;
        private IReservationsService _reservationService;

        // GET
        public ReservationController(IRoomRepository roomRepository, IReservationRepository reservationRepository,
            IMessagesService messagesService, IReservationsService reservationsService)
        {
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;
            _messageService = messagesService;
            _reservationService = reservationsService;
        }

        public IActionResult Prepare(int? id, [FromForm] Reservation reservation)
        {
            if (!id.HasValue)
                return RedirectToAction("Index", "Room");

            reservation = _reservationService.IncludeRoom(new Reservation {RoomId = id.Value});

            return View(reservation);
        }

        [HttpGet]
        public IActionResult Create(int id, [FromQuery] Reservation reservation)
        { 
            //Since the default (of timespan) values are the same, they can never be different
            if (!_reservationService.HasValidRange(reservation))
            {
                _messageService.AddMessage(new Message("Invalid time range."));
                return RedirectToAction("Prepare", reservation);
            }

            reservation.RoomId = id;
            reservation = _reservationService.IncludeRoom(reservation);
            if (reservation.Room == null)
            {
                _messageService.AddMessage(new Message("The room was not found."));
                return RedirectToAction("Index", "Room");
            }

            return View(reservation);
        }

        [HttpPost]
        public IActionResult Create([FromForm] Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                reservation = _reservationService.IncludeRoom(reservation);
                if (reservation.Room == null)
                {
                    _messageService.AddMessage(new Message("The room was not found."));
                    return RedirectToAction("Index", "Room");
                }

                return View(reservation);
            }

            try
            {
                _reservationService.Add(reservation);
                _messageService.AddMessage(new Message("A reservation has been made!", MessageType.Success));
                return RedirectToAction("Index", "Room");
            }
            catch
            {
                _messageService.AddMessage(new Message("A reservation with that time range has already been taken."));
                return RedirectToAction("Prepare", "Reservation", new {id = reservation.RoomId});
            }
        }
    }
}