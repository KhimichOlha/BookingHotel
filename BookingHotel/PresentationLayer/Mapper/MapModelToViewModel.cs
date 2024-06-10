using DataAccessLayer.Models;
using PresentationLayer.Models;

namespace PresentationLayer.Mapper
{
    public class MapModelToViewModel
    {
        public RoomViewModel RoomToViewModel(Room room)
        {
            RoomViewModel roomViewModel = new RoomViewModel()
            {
                Id = room.Id,
                Number = room.Number,
                RoomType = room.Type,
                Capacity = room.Capacity,
                Price = room.Price,
                AmentyViewModels = null
                
            };
            var amenities = new List<AmentyViewModel>(); 
            foreach (var amenity in room.Amenities)
            {
                amenities.Add(AmentyToViewModel(amenity));

            }
            roomViewModel.AmentyViewModels = amenities;
            return roomViewModel;

        }
        public AmentyViewModel AmentyToViewModel (Amenity amenity)
        {
            AmentyViewModel amentyViewModel = new AmentyViewModel()
            {
                Id = amenity.Id,
                Name = amenity.Name
            };
            return amentyViewModel;
        }
        public GuestViewModel GuestToViewModel(Guest guest)
        {
            GuestViewModel guestViewModel = new GuestViewModel()
            {
                Id = guest.Id,
                Name = guest.Name,
                Email = guest.Email,
                Phone = guest.Phone
            };
            return guestViewModel;
        }
        public BookingViewModel BookingToViewModel(Booking booking)
        {
            BookingViewModel bookingViewModel = new BookingViewModel()
            {
                Id = booking.Id,
                Guest = GuestToViewModel(booking.Guest),
                Room = RoomToViewModel(booking.Room),
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                Status = booking.Status,
                PaymentMethod = booking.PaymentMethod
            };
            return bookingViewModel;

        }
    }
}
