using System;
using System.Collections.Generic;
using reservations_data.Models;

namespace reservations_data.Repositories.Reservations
{
    public interface IReservationRepository
    {

        IList<Reservation> GetReservationsForDay(int roomId, DateTime day);

        IList<Reservation> GetAllReservations(int roomId);

        Reservation GetReservation(int reservationId);

        void Add(Reservation reservation);

    }
}