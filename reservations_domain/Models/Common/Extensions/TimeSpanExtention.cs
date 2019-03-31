using System;

namespace reservations_domain.Models.Common.Extensions
{
    public static class TimeSpanExtention
    {
        public static TimeSpan AddHours(this TimeSpan timeSpan, int hours)
        {
            return timeSpan.Add(new TimeSpan(hours, 0, 0));
        }
    }
}