using System;
using System.Collections.Generic;
using System.Linq;
using reservations_data.Models;

namespace reservations_data.Repositories.Reservations
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationDbContext _context;

        public ReservationRepository(ReservationDbContext context)
        {
            _context = context;
        }

        public IList<Reservation> GetReservationsForDay(int roomId, DateTime day)
        {
            return _context.Reservations
                .Where(i => i.RoomId == roomId && i.From.Date == day.Date)
                .ToList();
        }

        public IList<Reservation> GetAllReservations(int roomId)
        {
            return _context.Reservations
                .Where(i => i.RoomId == roomId)
                .ToList();
        }

        public Reservation GetReservation(int reservationId)
        {
            return _context.Reservations.First(i => i.ReservationId == reservationId);
        }
    }
}