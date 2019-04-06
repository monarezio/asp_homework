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
            return _dbContext.Rooms //TODO: Optimization
                .Include("Reservations")
                .Where(i => i.RoomId == id)
                .Select(i =>
                    new
                    {
                        Room = i,
                        Reservations = i.Reservations.Where(r => r.From.Date == day.Date)
                    }
                ).Select(i =>
                    new Room
                    {
                        RoomId = i.Room.RoomId,
                        Description = i.Room.Description,
                        From = i.Room.From,
                        To = i.Room.To,
                        Name = i.Room.Name,
                        Reservations = i.Reservations.ToList()
                    }
                ).FirstOrDefault();
        }

        public IList<Room> GetAllRoomsWithReservation(DateTime day)
        {
            return _dbContext.Rooms //TODO: Optimization
                .Include("Reservations")
                .Select(i =>
                    new
                    {
                        Room = i,
                        Reservations = i.Reservations.Where(r => r.From.Date == day.Date)
                    }
                ).Select(i =>
                    new Room
                    {
                        RoomId = i.Room.RoomId,
                        Description = i.Room.Description,
                        From = i.Room.From,
                        To = i.Room.To,
                        Name = i.Room.Name,
                        Reservations = i.Reservations.ToList()
                    }
                ).ToList();
        }
    }
}