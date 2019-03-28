using System;
using reservations_domain.Models.Range;
using reservations_domain.Models.Range.Exceptions;
using reservation_domain.Models.Range;

namespace reservations_domain.Services.Factories.RangeFactory
{
    public class RangeFactory: IRangeFactory
    {
        public Range<T> CreateRange<T>(T from, T to) where T : IComparable<T>
        {
            if (from.CompareTo(to) > 0)
                throw new InvalidRangeException(from, to);
            
            return new Range<T>(from, to);
        }

        public Range<int> CreateIntRange(int from, int to)
        {
            return CreateRange(from, to);
        }
        
        public Range<DateTime> CreateDateTimeRange(DateTime from, DateTime to)
        {
            return CreateRange(from, to);
        }
    }
}