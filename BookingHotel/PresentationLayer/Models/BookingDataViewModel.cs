using DataAccessLayer.Models;

namespace PresentationLayer.Models
{
    public class BookingDataViewModel
    {
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
