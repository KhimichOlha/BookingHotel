using AutoMapper;
using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    [Authorize]
    public class  RoomController : Controller
    {
        private readonly RoomService _roomService;
        private readonly IMapper _map;

        public RoomController(RoomService roomService, IMapper map)
        {
            _roomService = roomService;
            _map = map;
        }

        public IActionResult Index()
        {
            var rooms = _roomService.GetAll();
            var roomsview = new List<RoomViewModel>();
            foreach (var room in rooms)
            {
                roomsview.Add(_map.Map<RoomViewModel>(room));

            }
            return View(roomsview);
        }

    }
}
