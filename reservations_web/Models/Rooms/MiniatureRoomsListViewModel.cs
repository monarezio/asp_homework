using System.Collections.Generic;
using reservations_web.Models.Room;

namespace reservations_web.Models.Rooms
{
    /// <summary>
    /// Better to pass this object then IList to the view
    /// </summary>
    public class MiniatureRoomsListViewModel
    {
        public IList<MiniatureRoomViewModel> Rooms { get; set; }

        public MiniatureRoomsListViewModel(IList<MiniatureRoomViewModel> rooms)
        {
            Rooms = rooms;
        }
    }
}