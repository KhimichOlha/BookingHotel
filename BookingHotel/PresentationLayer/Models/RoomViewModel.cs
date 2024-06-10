using DataAccessLayer.Models;

namespace PresentationLayer.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public int Number {  get; set; }
        public RoomType RoomType { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public List<AmentyViewModel>? AmentyViewModels { get; set; }
    }
}
