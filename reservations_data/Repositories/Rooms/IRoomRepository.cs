using System.Collections.Generic;
using reservations_data.Models;

namespace reservations_data.Repositories.Rooms
{
    public interface IRoomRepository
    {
        IList<Room> getAllRooms();
    }
}