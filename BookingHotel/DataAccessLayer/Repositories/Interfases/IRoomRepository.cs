using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfases
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAvailableRooms(DateTime checkInDate, DateTime checkOutDate, int guestCount);
        Room GetById(int id);
        void Update(Room room);

    }
}
