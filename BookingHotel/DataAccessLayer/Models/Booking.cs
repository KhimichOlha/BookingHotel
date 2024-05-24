using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public Guest Guest { get; set; }
        public Room Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set;}
        public BookingStatus Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        
        

    }
}
