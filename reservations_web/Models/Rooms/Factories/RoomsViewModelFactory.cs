using System.Collections.Generic;
using System.Linq;
using reservations_data.Models;
using reservations_domain.Models.Range.Extensions;

namespace reservations_web.Models.Rooms.Factories
{
    /// <summary>
    /// Factory for the room miniatures view models.
    /// Converts the data models to view models.
    /// </summary>
    public class RoomsViewModelFactory : IRoomsViewModelFactory
    {
        public MiniatureRoomViewModel CreateMiniatureRoomViewModel(Room room)
        {
            return new MiniatureRoomViewModel(room.RoomId, room.Name, room.Description);
        }

        public MiniatureRoomsListViewModel CreateMiniatureRoomsListViewModel(IList<Room> room)
        {
            return new MiniatureRoomsListViewModel(
                room.Select(r => CreateMiniatureRoomViewModel(r)).ToList()
            );
        }

        public RoomViewModel CreateRoomViewModel(Room room)
        {
            return new RoomViewModel(room.RoomId, room.Name, room.Description, room.GetOpeningHours());
        }
    }
}