using System;
using reservations_data.Models;
using reservations_domain.Models.Range.Extensions;
using reservations_domain.Services.Factories.RangeFactory;
using Xunit;

namespace reservations_tests.Domain.Models.Extensions
{
    public class ReservationExtensionTest: IClassFixture<Context>
    {
        private readonly DateTime _res1From = new DateTime(2018, 1, 1, 10, 0, 0);
        private readonly DateTime _res1To = new DateTime(2018, 1, 1, 11, 0, 0);
        private readonly Reservation _res1;
        
        private readonly DateTime _res2From = new DateTime(2018, 1, 1, 15, 0, 0);
        private readonly DateTime _res2To = new DateTime(2018, 1, 1, 15, 30, 0);
        private readonly Reservation _res2;

        private readonly IRangeFactory _rangeFactory;

        public ReservationExtensionTest(Context context)
        {
            _rangeFactory = context.RangeFactory;
            
            _res1 = new Reservation
            {
                From = _res1From,
                To = _res1To
            };
            
            _res2 = new Reservation
            {
                From = _res2From,
                To = _res2To
            };
        }

        [Fact]
        public void GetBookedTimeTest()
        {
            Assert.Equal(_rangeFactory.CreateDateTimeRange(_res1From, _res1To), _res1.GetBookedTimeRange());
            Assert.Equal(_rangeFactory.CreateDateTimeRange(_res2From, _res2To), _res2.GetBookedTimeRange());
            
            Assert.NotEqual(_rangeFactory.CreateDateTimeRange(_res2From, _res2To), _res1.GetBookedTimeRange());
        }
    }
}