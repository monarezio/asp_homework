using System.Collections.Generic;
using reservations_data.Models;
using reservations_domain.Models.Common.Extensions;
using reservation_domain.Models.Range;

namespace reservations_domain.Models.Range.Extensions
{
    public static class RoomExtension
    {
        /// <summary>
        /// Int range when the room is open,
        /// I am not using the RangeFactory, since I expect, that I will receive only valid objects from the repository
        /// </summary>
        public static TimeRange GetOpeningHours(this Room room)
        {
            return new TimeRange(room.From, room.To);
        }

        /// <summary>
        /// Returns the opening hours as list, where the range between each time is an hour.  
        /// </summary>
        /// <param name="room"></param>
        /// <returns>a list of opening hours with the time range of and hour</returns>
        public static IList<TimeRange> GetOpeningHoursAsList(this Room room)
        {
            IList<TimeRange> hours = new List<TimeRange>();
            TimeRange openingHours = room.GetOpeningHours();
            int count = openingHours.To.Hours - openingHours.From.Hours;
            for (int i = 0; i < count; i++)
            {
                hours.Add(new TimeRange(openingHours.From.AddHours(i), openingHours.From.AddHours(i + 1)));
            }

            return hours;
        }
    }
}