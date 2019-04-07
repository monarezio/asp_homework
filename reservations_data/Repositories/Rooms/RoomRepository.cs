using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            return _dbContext.Rooms.FirstOrDefault(r => r.RoomId == id);
        }

        public Room GetRoomWithReservations(int id, DateTime day)
        {
            var room = _dbContext.Rooms.FirstOrDefault(i => i.RoomId == id);

            if (room == null)
                return null;

            var reservations = _dbContext.Reservations.Where(i => i.From.Day == day.Day && i.RoomId == room.RoomId).ToList();
            reservations.ForEach(i => i.Room = null);
            
            room.Reservations = reservations;

            return room;
        }

        public IList<Room> GetAllRoomsWithReservation(DateTime day)
        {
            var rooms = _dbContext.Rooms.ToList();

            var roomsIds = rooms.Select(i => i.RoomId);

            var reservations = _dbContext.Reservations.Where(i => i.From.Date == day.Date && roomsIds.Contains(i.RoomId)).ToList();
            reservations.ForEach(i => i.Room = null);

            rooms = rooms.Select(i => new Room
            {
                RoomId = i.RoomId,
                Description = i.Description,
                From = i.From,
                Name = i.Name,
                To = i.To,
                Reservations = reservations.Where(j => j.RoomId == i.RoomId).ToList()
            }).ToList();

            return rooms;
        }
    }
}