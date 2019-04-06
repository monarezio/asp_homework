using reservations_data.Models;

namespace reservations_domain.Services.Reservations
{
    public interface IReservationsService
    {
        Reservation IncludeRoom(Reservation reservation);

        bool HasValidRange(Reservation reservation);

        void Add(Reservation reservation);
    }
}