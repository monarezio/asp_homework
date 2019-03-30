using System;
using System.Collections.Generic;
using reservations_domain.Models.Range;

namespace reservations_web.Models.Rooms
{
    public class RoomViewModel
    {
        public int RoomId { get; }
        public string Name { get; }
        public string Description { get; }
        public IList<IntRange> Hours { get; } = new List<IntRange>();

        public RoomViewModel(int roomId, string name, string description, IntRange openingHours)
        {
            RoomId = roomId;
            Name = name;
            Description = description;

            int count = openingHours.To - openingHours.From;
            for (int i = 0; i < count; i++)
            {
                Hours.Add(new IntRange(openingHours.From + i, openingHours.From + i + 1));
            }
        }
    }
}