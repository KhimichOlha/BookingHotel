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
    public class CreateBooking : IBookingCommand
    {
        private readonly IBookingRepository _repository;
        private readonly IBookingState _state;
        private readonly IPricing _pricing;
        public CreateBooking(IBookingRepository repository, IBookingState state, IPricing pricing)
        {
            _repository = repository;
            _state = state;
            _pricing = pricing;
        }

        public void Execute(Booking  booking)
        {
            
            if (booking !=  null)
            {
                if (booking.CheckInDate >= booking.CheckOutDate)
                {
                    throw new ArgumentException("Дата заїзду повинна бути раніше дати виїзду.");
                }
                if (booking.Room == null || !booking.Room.IsAvailable)
                    throw new ArgumentException("Кімната недоступна для бронювання.");
                booking.Room.Price = _pricing.CalculatePrice(booking);
                _state.Confirm(booking);
                _repository.Add(booking);
                
            }
            else
            {
                throw new NullReferenceException("Обєкт бронювання не додано");
            }
        }
    }
}
