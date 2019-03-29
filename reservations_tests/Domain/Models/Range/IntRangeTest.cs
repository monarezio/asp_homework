using reservations_domain.Services.Factories.RangeFactory;
using reservation_domain.Models.Range;
using Xunit;

namespace reservations_tests.Domain.Models.Range
{
    public class IntRangeTest: IClassFixture<Context>
    {
        private readonly Range<int> _intRange1;
        private readonly Range<int> _intRange2;
        private readonly Range<int> _intRange3;
        private readonly Range<int> _intRange4;
        
        public IntRangeTest(Context context)
        {
            IRangeFactory rangeFactory = context.RangeFactory;

            _intRange1 = rangeFactory.CreateIntRange(10, 20);
            _intRange2 = rangeFactory.CreateIntRange(9, 18);
            _intRange3 = rangeFactory.CreateIntRange(11, 18);
            _intRange4 = rangeFactory.CreateIntRange(20, 21);
        }
        
        [Fact]
        public void PassingCollisionIntTests()
        {
            Assert.True(_intRange1.CollidesWith(_intRange2));
            Assert.True(_intRange1.CollidesWith(_intRange1));
            Assert.True(_intRange1.CollidesWith(_intRange3));
            Assert.True(_intRange3.CollidesWith(_intRange1));
            Assert.True(_intRange1.CollidesWith(_intRange4));
        }

        [Fact]
        public void FailingCollisionIntTests()
        {
            Assert.False(_intRange2.CollidesWith(_intRange4));
            Assert.False(_intRange4.CollidesWith(_intRange2));
            Assert.False(_intRange3.CollidesWith(_intRange4));
        }

    }
}