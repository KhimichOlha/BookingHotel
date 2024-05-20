using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class LoyaltyPrice : IPricing
    {
        public decimal CalculatePrice(Booking booking)
        {
            decimal discount = booking.Guest.LoyaltyPoints / 1000m;
            return (1-discount)*booking.Room.Price*(booking.CheckOutDate - booking.CheckInDate).Days;
        }
    }
}
