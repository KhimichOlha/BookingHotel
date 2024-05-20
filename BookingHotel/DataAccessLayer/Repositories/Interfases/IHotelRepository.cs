using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfases
{
    public interface IHotelRepository
    {
        Hotel GetById(int hotelId);
        IEnumerable<Hotel> GetAll();
        void Add(Hotel hotel);
        void Update(Hotel hotel);
        void Delete(int hotelId);

    }
}
