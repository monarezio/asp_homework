using System;
using reservations_domain.Services.Factories.RangeFactory;

namespace reservations_tests
{
    public class Context: IDisposable
    {
        public readonly RangeFactory RangeFactory = new RangeFactory();

        public void Dispose()
        {
            //Cleanup the code, which I don't have to cleanup
        }
    }
}