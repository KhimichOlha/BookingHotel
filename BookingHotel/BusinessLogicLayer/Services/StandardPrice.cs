using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class StandardPrice : IPricing
    {
        public decimal CalculatePrice(Booking booking)
        {
            return booking.Room.Price * (booking.CheckInDate - booking.CheckOutDate).Days;

        }
    }
}
