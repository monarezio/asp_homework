using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;
using reservations_data;
using reservations_data.Models;

namespace reservations_tests.IntegrationTests.Model
{
    public class TestDbInitializer
    {
        private static IList<Room> _rooms = new List<Room>(); 
        
        public static void Initialize(IList<Room> rooms)
        {
            _rooms = rooms;
        }
        
        public static IList<Room> GetTestRooms()
        {
            return _rooms;
        }
    }
}