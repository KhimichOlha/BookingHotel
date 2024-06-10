using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IRoomService
    {
        Room GetRoomById(int roomId);
        IEnumerable<Room> GetAvailableRoomss(DateTime checkInDate, DateTime checkOutDate, int guestCount);
        void UpdateRoom(Room room);
        IEnumerable<Room> GetAll();
        void Add(Room room);
        double CalculateOccupancyRate(DateTime? date = null);
    }
}
