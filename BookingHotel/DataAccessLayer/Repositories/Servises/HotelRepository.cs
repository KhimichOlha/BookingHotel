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
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelBookingDbContext _context;
        public HotelRepository(HotelBookingDbContext context)
        {
            _context = context;
        }
        public void Add(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
        }

        public void Delete(int hotelId)
        {
            _context.Hotels.Remove(GetById(hotelId));
            _context.SaveChanges();
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _context.Hotels.ToList();

        }

        public Hotel GetById(int hotelId)
        {
            return _context.Hotels.Include(h => h.Rooms).FirstOrDefault(h => h.Id == hotelId);
        }

        public void Update(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
