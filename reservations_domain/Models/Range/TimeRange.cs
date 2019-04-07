using System;
using reservation_domain.Models.Range;

namespace reservations_domain.Models.Range
{
    /// <summary>
    /// Type alias for Range<int>
    /// </summary>
    public class TimeRange: Range<TimeSpan>
    {
        public TimeRange(TimeSpan from, TimeSpan to) : base(from, to) 
        {
        }

        public TimeRange(Range<DateTime> range) : base(range.From.TimeOfDay, range.To.TimeOfDay)
        {
        }
    }
}