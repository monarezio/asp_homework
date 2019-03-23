namespace asp_homework.Models.Data.Models.HelperModels
{
    /// <summary>
    /// Represents the range in hours, for example: 10:00 - 13:00.
    /// The point if this class is, that more rooms can have same opening hours.
    /// It's not a database entity!
    /// </summary>
    public class TimeRange
    {
        public int From { get; }
        public int To { get; }
        
        public TimeRange(int from, int to)
        {
            From = from;
            To = to;
        }

        /// <summary>
        /// Checks if the two time intervals overlap each other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool CollidesWith(TimeRange other) {
            return (From >= other.From && From <= other.To) || (To >= other.From && To <= other.To);
        }
    }
}