using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfases
{
    public interface IBookingRepository
    {
        void Add(Booking booking);
        void Update(Booking booking);
        Booking GetById(int id);
        IEnumerable<Booking> GetByGuestId(int guestId);
        IEnumerable<Booking> GetByHotelId(int hotelId);
    }
}
