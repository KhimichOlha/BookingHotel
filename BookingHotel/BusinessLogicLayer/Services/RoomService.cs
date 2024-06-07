using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public IEnumerable<Room> GetAvailableRoomss(DateTime checkInDate, DateTime checkOutDate, int guestCount)
        {

           return _roomRepository.GetAvailableRooms(checkInDate, checkOutDate, guestCount);
        }

        public Room GetRoomById(int roomId)
        {
            return _roomRepository.GetById(roomId);
        }

        public void UpdateRoom(Room room)
        {
            _roomRepository.Update(room);
        }
    }
}
