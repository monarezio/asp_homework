using System;
using reservations_data.Models;
using reservation_domain.Models.Range;

namespace reservations_domain.Models.Range.Extensions
{
    public static class ReservationExtension
    {
        /// <summary>
        /// DateTime range when the reservation is active,
        /// I am not using the RangeFactory, since I expect, that I will receive only valid objects from the repository
        /// </summary>
        public static Range<DateTime> GetBookedTimeRange(this Reservation reservation)
        {
            return new DateTimeRange(reservation.From, reservation.To);
        }
    }
}