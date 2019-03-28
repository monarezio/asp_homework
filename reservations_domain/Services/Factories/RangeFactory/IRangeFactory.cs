using System;
using reservations_domain.Models.Range;
using reservation_domain.Models.Range;

namespace reservations_domain.Services.Factories.RangeFactory
{
    public interface IRangeFactory
    {
        Range<T> CreateRange<T>(T from, T to) where T : IComparable<T>;

        Range<int> CreateIntRange(int form, int to);

        Range<DateTime> CreateDateTimeRange(DateTime from, DateTime to);
    }
}