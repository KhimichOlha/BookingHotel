using AutoMapper;
using DataAccessLayer.Models;
using PresentationLayer.Models;

namespace PresentationLayer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Booking, BookingViewModel>().ReverseMap();
            CreateMap<Room, RoomViewModel>().ReverseMap();
            CreateMap<Amenity, AmentyViewModel>().ReverseMap();
            CreateMap<Guest, GuestViewModel>().ReverseMap();
            
        }
    }
}
