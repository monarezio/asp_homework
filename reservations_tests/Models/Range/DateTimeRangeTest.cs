using System;
using reservations_domain.Models.Range;
using reservations_domain.Services.Factories.RangeFactory;
using reservation_domain.Models.Range;
using Xunit;

namespace reservations_tests.Models.Range
{
    public class DateTimeRangeTest: IClassFixture<Context>
    {
        private readonly Range<DateTime> _dateRange1;

        private readonly Range<DateTime> _dateRange2;

        private readonly Range<DateTime> _dateRange3;
        
        public DateTimeRangeTest(Context context)
        {
            IRangeFactory rangeFactory = context.RangeFactory;

            _dateRange1 = rangeFactory.CreateDateTimeRange(
                new DateTime(2000, 1, 1),
                new DateTime(2000, 12, 12)
            );

            _dateRange2 = rangeFactory.CreateDateTimeRange(
                new DateTime(1999, 1, 1),
                new DateTime(2001, 12, 12)
            );
            
            _dateRange3 = rangeFactory.CreateDateTimeRange(
                DateTime.Today, 
                DateTime.Now
            );
        }

        [Fact]
        public void PassingDateTests() 
        {
            Assert.True(_dateRange1.CollidesWith(_dateRange2));    
            Assert.True(_dateRange1.CollidesWith(_dateRange1));    
            Assert.True(_dateRange2.CollidesWith(_dateRange1));    
        }

        [Fact]
        public void FailingDataTests()
        {
            Assert.False(_dateRange1.CollidesWith(_dateRange3));
            Assert.False(_dateRange2.CollidesWith(_dateRange3));
            Assert.False(_dateRange3.CollidesWith(_dateRange2));
            Assert.False(_dateRange3.CollidesWith(_dateRange1));
        }
    }
}