using asp_homework.Models.Data.Models;
using asp_homework.Models.Data.Models.HelperModels;
using Xunit;

namespace asp_homework_tests.Models.Data.Models
{
    public class RoomTest
    {
        private readonly Room _room1 = new Room
        {
            RoomId = 1,
            Name = "Room 1",
            From = 10,
            To = 20
        };
        
        private readonly Room _room2 = new Room
        {
            RoomId = 2,
            Name = "Room 2",
            From = 6,
            To = 10
        };
        
        [Fact]
        public void TimeRangeTest()
        {
            Assert.Equal(new TimeRange(10, 20), _room1.TimeRange);
            Assert.Equal(new TimeRange(6, 10), _room2.TimeRange);
            Assert.NotEqual(new TimeRange(0, 10), _room2.TimeRange);
        }

    }
}