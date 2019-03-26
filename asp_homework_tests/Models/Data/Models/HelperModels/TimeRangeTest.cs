using asp_homework.Models.Data.Models.HelperModels;
using Xunit;

namespace asp_homework_tests.Models.Data.Models.HelperModels
{
    public class TimeRangeTest
    {
        
        private readonly TimeRange _range1 = new TimeRange(10, 20);
        private readonly TimeRange _range2 = new TimeRange(9, 18);
        private readonly TimeRange _range3 = new TimeRange(11, 18);
        private readonly TimeRange _range4 = new TimeRange(20, 21);
        
        [Fact]
        public void PassingCollisionTest()
        {
            Assert.True(_range1.CollidesWith(_range2));
            Assert.True(_range1.CollidesWith(_range1));
            Assert.True(_range1.CollidesWith(_range3));
            Assert.True(_range3.CollidesWith(_range1));
            Assert.True(_range1.CollidesWith(_range4));
        }
        
        [Fact]
        public void FailingCollisionTest()
        {
            Assert.False(_range2.CollidesWith(_range4));
            Assert.False(_range4.CollidesWith(_range2));
            Assert.False(_range3.CollidesWith(_range4));
        }

    }
}