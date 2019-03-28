using System;
using reservation_domain.Models.Range;

namespace reservations_domain.Models.Range
{
    /// <summary>
    /// Type alias for Range<DateTime>
    /// </summary>
    public class DateTimeRange: Range<DateTime>
    {
        public DateTimeRange(DateTime from, DateTime to) : base(from, to)
        {
        }
    }
}