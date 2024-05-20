using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class SeasonPrice : IPricing
    {
        public decimal CalculatePrice(Booking booking)
        {
            var monthNow = DateTime.Now.Month;
            if(monthNow >= 3 && monthNow < 6)
            {
                return (booking.Room.Price * (booking.CheckOutDate - booking.CheckInDate).Days)*1.05m;
            }
            else if(monthNow>= 6 && monthNow < 9)
            {
                return (booking.Room.Price * (booking.CheckOutDate - booking.CheckInDate).Days) * 1.5m;
            }
            else if(monthNow >=9 && monthNow < 12)
            {
                return (booking.Room.Price * (booking.CheckOutDate - booking.CheckInDate).Days) * 0.9m;
            }
            else
            {
                return (booking.Room.Price * (booking.CheckOutDate - booking.CheckInDate).Days);
            }
        }
    }
}
