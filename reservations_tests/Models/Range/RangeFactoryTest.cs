using System;
using reservations_domain.Models.Range.Exceptions;
using reservations_domain.Services.Factories.RangeFactory;
using Xunit;

namespace reservations_tests.Models.Range
{
    public class RangeFactoryTest: IClassFixture<Context>
    {

        private readonly RangeFactory _rangeFactory;
 
        public RangeFactoryTest(Context context)
        {
            _rangeFactory = context.RangeFactory;
        }

        [Fact]
        public void RangeConstructionTest()
        {
            Assert.Throws<InvalidRangeException>(() => _rangeFactory.CreateIntRange(10, 1));
            Assert.Throws<InvalidRangeException>(() => _rangeFactory.CreateDateTimeRange(DateTime.Now, DateTime.Today));
            Assert.Throws<InvalidRangeException>(() => _rangeFactory.CreateRange(10.0, 0.01));
            
            Assert.NotNull(_rangeFactory.CreateIntRange(1, 10));
        }

    }
}