using System;

namespace reservations_web.Models.Reservation
{
    public class ReservationPreparationViewModel
    {
        public DateTime Date { get; set; }
        public TimeSpan From { get; set; }
    }
}