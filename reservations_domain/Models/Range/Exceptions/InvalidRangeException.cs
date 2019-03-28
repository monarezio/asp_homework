using System;

namespace reservations_domain.Models.Range.Exceptions
{
    public class InvalidRangeException: Exception
    {
        public InvalidRangeException(object from, object to) : base($"{from} cannot be bigger to {to}.")
        {
        }
    }
}