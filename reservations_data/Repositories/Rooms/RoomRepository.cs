using System.Collections.Generic;
using System.Linq;
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

        public IList<Room> getAllRooms()
        {
            return _dbContext.Rooms.ToList();
        }
    }
}