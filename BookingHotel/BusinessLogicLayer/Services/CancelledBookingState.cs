using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CancelledBookingState : IBookingState
    {
       
        public void Confirm(Booking booking)
        {
            throw new InvalidOperationException("Не можна підтвердити скасоване бронювання.");
        }

        public void Cancel(Booking booking)
        {
            throw new InvalidOperationException("Бронювання вже скасовано.");
        }
    }
}
