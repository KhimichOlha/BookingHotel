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
    public class GuestRepository : IGuestRepository

    {
        private readonly HotelBookingDbContext _context;
        public GuestRepository(HotelBookingDbContext context)
        {
            _context = context;
        }
        public void Add(Guest guest)
        {
            _context.Guests.Add(guest);
            _context.SaveChanges();
        }

        public Guest GetById(int id)
        {
            return _context.Guests.FirstOrDefault(h => h.Id == id);
        }

        public void Update(Guest guest)
        {
            _context.Entry(guest).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
