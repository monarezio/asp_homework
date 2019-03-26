using System.Collections.Generic;
using asp_homework.Models.Data.Models;

namespace asp_homework.Models.Data.Repositories.Rooms
{
    public interface IRoomsRepository
    {
        IList<Room> GetRooms();
    }
}