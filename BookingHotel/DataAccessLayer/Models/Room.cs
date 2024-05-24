using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int Number { get; set; }
        public RoomType Type { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public List<Amenity> Amenities { get; set; }
        public bool IsAvailable { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
