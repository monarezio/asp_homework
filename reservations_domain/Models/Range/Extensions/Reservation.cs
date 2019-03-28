using reservations_data.Models;

namespace reservations_domain.Models.Range.Extensions
{
    public static class ReservationExtension
    {
        /// <summary>
        /// DateTime range when the reservation is active,
        /// I am not using the RangeFactory, since I expect, that I will receive only valid objects from the repository
        /// </summary>
        public static DateTimeRange GetBookedTimeRange(this Reservation reservation)
        {
            return new DateTimeRange(reservation.From, reservation.To);
        }
    }
}