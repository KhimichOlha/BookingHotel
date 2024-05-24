using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IBookingRepository _bookingRepository;
        public GuestService(IGuestRepository guestRepository, IBookingRepository bookingRepository)
        {
            _guestRepository = guestRepository;
            _bookingRepository = bookingRepository;
        }

        public void Add(Guest guest)
        {
            _guestRepository.Add(guest);
        }

        public IEnumerable<Guest> GetAll()
        {
           return _guestRepository.GetAll();
        }

        public IEnumerable<Booking> GetBookingsForGuest(int id)
        {
            return _bookingRepository.GetByGuestId(id);
        }

        public Guest GetById(int id)
        {
            return _guestRepository.GetById(id);
        }

        public IEnumerable<Guest> SearchGuests(string searchTerm)
        {
            return _guestRepository.GetAll().Where(g =>  g.Name.Contains(searchTerm) || g.Email.Contains(searchTerm));
        }

        public void Update(Guest guest)
        {
            _guestRepository.Update(guest);
        }
    }
}
