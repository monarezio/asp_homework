using System;
using System.Collections.Generic;
using System.Linq;
using reservations_data.Common.Extensions;
using reservations_data.Models;

namespace reservations_data.Repositories.Rooms
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ReservationDbContext _dbContext;

        public RoomRepository(ReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Room> GetAllRooms()
        {
            return _dbContext.Rooms.ToList();
        }

        public Room GetRoom(int id)
        {
            return _dbContext.Rooms.First(r => r.RoomId == id);
        }

        public Room GetRoomWithReservations(int id, DateTime day)
        {
            var query = from room in _dbContext.Rooms
                join reservation in _dbContext.Reservations on room.RoomId equals reservation.RoomId
                where room.RoomId == id && reservation.To.Date.Equals(day.Date)
                select room; //TODO: Find a better way?  
            return query.First();
        }
    }
}