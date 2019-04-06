using System.Collections.Generic;
using reservations_data.Models;

namespace reservations_web.Models.Rooms.Factories
{
    public interface IRoomsViewModelFactory
    {
        MiniatureRoomViewModel CreateMiniatureRoomViewModel(Room room);

        MiniatureRoomsListViewModel CreateMiniatureRoomsListViewModel(IList<Room> room);
    }
}