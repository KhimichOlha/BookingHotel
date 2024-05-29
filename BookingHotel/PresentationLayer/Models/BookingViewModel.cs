using DataAccessLayer.Models;

namespace PresentationLayer.Models
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public GuestViewModel Guest { get; set; }
        public Room Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public BookingStatus Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
