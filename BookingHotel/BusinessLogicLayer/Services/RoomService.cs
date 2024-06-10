using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfases;
using DataAccessLayer.Repositories.Servises;
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
        private readonly IBookingRepository _bookingRepository;
       public RoomService(IRoomRepository roomRepository, IBookingRepository bookingRepository)
        {
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
        }

        public void Add(Room room)
        {
            _roomRepository.Add(room);
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
        public double CalculateOccupancyRate(DateTime? date = null)
        {
            date ??= DateTime.Today;
            var totalRooms = _roomRepository.GetAll().Count();
            var occupiedRooms = _bookingRepository.GetAll()
                .Count(b =>
                    b.CheckInDate <= date &&
                    b.CheckOutDate > date &&
                    b.Status == BookingStatus.Confirmed
                );

            if (totalRooms == 0)
                return 0;

            return (double)occupiedRooms / totalRooms * 100;
        }
    }
}
