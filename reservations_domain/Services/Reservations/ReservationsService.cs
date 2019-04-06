using reservations_data.Models;
using reservations_data.Repositories.Reservations;
using reservations_data.Repositories.Rooms;

namespace reservations_domain.Services.Reservations
{
    public class ReservationsService : IReservationsService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;

        public ReservationsService(IRoomRepository roomRepository, IReservationRepository reservationsService)
        {
            _roomRepository = roomRepository;
            _reservationRepository = reservationsService;
        }

        public Reservation IncludeRoom(Reservation reservation)
        {
            reservation.Room = _roomRepository.GetRoom(reservation.RoomId);
            return reservation;
        }

        public bool HasValidRange(Reservation reservation)
        {
            return !(
                reservation == null ||
                reservation.From >= reservation.To ||
                reservation.From.AddHours(1) != reservation.To
            ); //Last line is here since I am saving the range in timespan, and therefor have to have the range exactly 1 hour.
        }

        public void Add(Reservation reservation)
        {
            _reservationRepository.Add(reservation);
        }
    }
}