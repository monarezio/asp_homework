using reservation_domain.Models.Range;

namespace reservations_domain.Models.Range
{
    /// <summary>
    /// Type alias for Range<int>
    /// </summary>
    public class IntRange: Range<int>
    {
        public IntRange(int from, int to) : base(from, to) 
        {
        }
    }
}