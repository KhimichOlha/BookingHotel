using DataAccessLayer.Context;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Servises
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelBookingDbContext _context;
        public RoomRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Room> GetAvailableRooms(DateTime checkInDate, DateTime checkOutDate, int guestCount)
        {
            return _context.Rooms
            .Include(r => r.Bookings)
            .Where(r =>
                r.Capacity >= guestCount &&
                !r.Bookings.Any(b =>
                    (b.CheckInDate <= checkOutDate && b.CheckOutDate >= checkInDate) ||
                    (b.Status == BookingStatus.Confirmed) // Перевірка на підтверджені бронювання
                )
            );
        }

        public Room GetById(int id)
        {
            return  _context.Rooms.Include(r => r.Amenities).FirstOrDefault(r => r.Id == id);
            
        }

        public void Update(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}
