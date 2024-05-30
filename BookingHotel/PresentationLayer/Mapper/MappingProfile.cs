using AutoMapper;
using DataAccessLayer.Models;
using PresentationLayer.Models;

namespace PresentationLayer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Booking, BookingViewModel>();
            CreateMap<Room, RoomViewModel>();
            CreateMap<Amenity, AmentyViewModel>();
            CreateMap<Guest, GuestViewModel>();
        }
    }
}
