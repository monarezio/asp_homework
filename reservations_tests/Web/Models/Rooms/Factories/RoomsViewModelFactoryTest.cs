using System.Collections.Generic;
using reservations_data.Models;
using reservations_web.Models.Rooms;
using reservations_web.Models.Rooms.Factories;
using Xunit;

namespace reservations_tests.Web.Models.Rooms.Factories
{
    public class RoomsViewModelFactoryTest
    {
        private readonly RoomsViewModelFactory _factory = new RoomsViewModelFactory();

        private readonly Room _roomViewModel1 = new Room
        {
            RoomId = 1,
            Name = "Test 1",
            Description = "Lorem Ipsum",
            From = 10,
            To = 12,
        };

        private readonly Room _roomViewModel2 = new Room
        {
            RoomId = 2,
            Name = "Test 2",
            Description = "You are a wizard harry.",
            From = 8,
            To = 20,
        };

        [Fact]
        public void CreateMiniatureRoomViewModelTest()
        {
            Assert.Equal(
                new MiniatureRoomViewModel(1, "Test 1", "Lorem Ipsum"),
                _factory.CreateMiniatureRoomViewModel(_roomViewModel1)
            );

            Assert.Equal(
                new MiniatureRoomViewModel(2, "Test 2", "You are a wizard harry."),
                _factory.CreateMiniatureRoomViewModel(_roomViewModel2)
            );

            Assert.NotEqual(
                new MiniatureRoomViewModel(99, "Test 2", "You are a wizard harry."),
                _factory.CreateMiniatureRoomViewModel(_roomViewModel2)
            );
        }

        [Fact]
        public void CreateMiniatureRoomsListViewModelTest()
        {
            IList<Room> rooms = new List<Room> {_roomViewModel1, _roomViewModel2};
            MiniatureRoomsListViewModel miniatureRoomsListViewModel = _factory.CreateMiniatureRoomsListViewModel(rooms);

            Assert.Contains(
                new MiniatureRoomViewModel(1, "Test 1", "Lorem Ipsum"),
                miniatureRoomsListViewModel.Rooms
            );
            
            Assert.Contains(
                new MiniatureRoomViewModel(2, "Test 2", "You are a wizard harry."),
                miniatureRoomsListViewModel.Rooms
            );
            
            Assert.DoesNotContain(
                new MiniatureRoomViewModel(99, "Test 2", "You are a wizard harry."),
                miniatureRoomsListViewModel.Rooms
            );
        }
    }
}