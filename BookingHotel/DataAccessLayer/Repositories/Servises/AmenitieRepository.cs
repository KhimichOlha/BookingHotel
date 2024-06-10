using DataAccessLayer.Context;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Servises
{
   public class AmenitieRepository : IAmenitieRepository
    {
        private readonly HotelBookingDbContext _context;
        public AmenitieRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Amenity> GetAll()
        {
            return _context.Amenities.ToList();
        }
    }
}
