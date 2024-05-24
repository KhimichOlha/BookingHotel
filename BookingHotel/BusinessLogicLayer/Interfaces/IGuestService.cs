using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IGuestService
    {
        Guest GetById(int id);
        void Add(Guest guest);
        void Update(Guest guest);
        IEnumerable<Guest> GetAll();
        IEnumerable<Booking> GetBookingsForGuest(int id);
        IEnumerable<Guest> SearchGuests(string searchTerm);
    }
}
