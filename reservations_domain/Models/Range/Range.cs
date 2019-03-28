using System;

namespace reservation_domain.Models.Range
{
    public class Range<T> where T : IComparable<T>
    {
        public T From { get; set; }
        public T To { get; set; }
        
        internal Range(T from, T to)
        {
            From = from;
            To = to;
        }
        
        /// <summary>
        /// Checks if the two objects don't collide
        /// </summary>
        /// <param name="other">The other object</param>
        /// <returns>true if the two objects collide otherwise false</returns>
        public bool CollidesWith(Range<T> other)
        {
            return (From.CompareTo(other.From) >= 0 && From.CompareTo(other.To) <= 0) ||
                   (To.CompareTo(other.From) >= 0 && To.CompareTo(other.To) <= 0) ||
                   (From.CompareTo(other.From) <= 0 && To.CompareTo(other.To) >= 0);
        }
    }
}