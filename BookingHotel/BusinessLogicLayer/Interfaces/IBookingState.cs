using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBookingState
    {
        void Confirm(Booking booking);
        void Cancel(Booking booking);
        

    }
}
