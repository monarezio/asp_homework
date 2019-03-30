using reservations_data.Models;
using reservation_domain.Models.Range;

namespace reservations_domain.Models.Range.Extensions
{
    public static class RoomExtension
    {
        /// <summary>
        /// Int range when the room is open,
        /// I am not using the RangeFactory, since I expect, that I will receive only valid objects from the repository
        /// </summary>
        public static IntRange GetOpeningHours(this Room room)
        {
            return new IntRange(room.From, room.To);
        }
    }
}