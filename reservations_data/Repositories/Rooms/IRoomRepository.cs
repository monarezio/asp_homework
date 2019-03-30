using System;
using System.Collections.Generic;
using reservations_data.Models;

namespace reservations_data.Repositories.Rooms
{
    public interface IRoomRepository
    {
        IList<Room> GetAllRooms();

        Room GetRoom(int id);

        Room GetRoomWithReservations(int id, DateTime day);
    }
}