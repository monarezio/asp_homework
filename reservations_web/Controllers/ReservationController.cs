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
        private IMessagesService _messageService;
        private IReservationsService _reservationService;

        // GET
        public ReservationController(IMessagesService messagesService, IReservationsService reservationsService)
        {
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
            reservation.RoomId = id;
            reservation = _reservationService.IncludeRoom(reservation);
            if (reservation.Room == null)
            {
                _messageService.AddMessage(new Message("The room was not found."));
                return RedirectToAction("Index", "Room");
            }
            
            //Since the default (of timespan) values are the same, they can never be different
            if (!_reservationService.HasValidRange(reservation))
            {
                _messageService.AddMessage(new Message("Invalid time range."));
                return RedirectToAction("Prepare", reservation);
            }

            return View(reservation);
        }

        [HttpPost]
        public IActionResult Create([FromForm] Reservation reservation)
        {
            reservation = _reservationService.IncludeRoom(reservation);
            if (!ModelState.IsValid)
            {
                if (reservation.Room == null)
                {
                    _messageService.AddMessage(new Message("The room was not found."));
                    return RedirectToAction("Index", "Room");
                }

                return View(reservation);
            }

            if (!_reservationService.HasValidRange(reservation))
            {
                _messageService.AddMessage(new Message("Invalid time range."));
                return RedirectToAction("Index", "Room"); //user is trying to break the app, does not really matter where I redirect him...
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