using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ConfirmedBookingState : IBookingState
    {
        public void Cancel(Booking booking)
        {
            throw new NotImplementedException();
        }

        public void Confirm(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
