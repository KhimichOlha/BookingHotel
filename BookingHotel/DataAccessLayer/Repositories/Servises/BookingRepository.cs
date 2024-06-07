using DataAccessLayer.Context;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Servises
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelBookingDbContext _context;
        public BookingRepository(HotelBookingDbContext context)
        {
            _context = context;
        }
        public void Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public IEnumerable<Booking> GetByGuestId(int guestId)
        {
            return _context.Bookings.Include(r=> r.Room).Where( b => b.Guest.Id == guestId).ToList();
        }

        

        public Booking GetById(int id)
        {
            return _context.Bookings.FirstOrDefault(b => b.Id == id);
        }

        public void Update(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
