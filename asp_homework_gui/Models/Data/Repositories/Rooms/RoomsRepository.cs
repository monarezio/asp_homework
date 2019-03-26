using System.Collections.Generic;
using System.Linq;
using asp_homework.Models.Data.Models;

namespace asp_homework.Models.Data.Repositories.Rooms
{
    public class RoomsRepository : IRoomsRepository
    {
        private readonly ReservationDbContext _dbContext;

        public RoomsRepository(ReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get all rooms
        /// </summary>
        /// <returns>All rooms</returns>
        public IList<Room> GetRooms()
        {
            return _dbContext.Rooms.ToList();
        }
    }
}