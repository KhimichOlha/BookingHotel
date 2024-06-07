using Microsoft.AspNetCore.Mvc.Rendering;

namespace PresentationLayer.Models
{
    public class CreateRoomViewModel
    {
        public RoomViewModel Room { get; set; }
        public List<int> SelectedAmenityIds { get; set; } = new List<int>();
        public IEnumerable<SelectListItem>? AllAmenities { get; set; }

    }
}
