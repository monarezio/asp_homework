using System;
using System.Collections.Generic;
using reservations_domain.Models.Common.Extensions;
using reservations_domain.Models.Range;

namespace reservations_web.Models.Rooms
{
    public class RoomViewModel
    {
        public int RoomId { get; }
        public string Name { get; }
        public string Description { get; }
        public IList<TimeRange> Hours { get; } = new List<TimeRange>();

        public RoomViewModel(int roomId, string name, string description, TimeRange openingHours)
        {
            RoomId = roomId;
            Name = name;
            Description = description;

            int count = openingHours.To.Hours - openingHours.From.Hours;
            for (int i = 0; i < count; i++)
            {
                Hours.Add(new TimeRange(openingHours.From.AddHours(i), openingHours.From.AddHours(i + 1)));
            }
        }
    }
}