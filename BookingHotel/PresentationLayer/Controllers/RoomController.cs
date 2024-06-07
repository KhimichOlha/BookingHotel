using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _map;
        private readonly IAmenitieRepository _amenitie;
        public RoomController(IRoomService roomService, IMapper map, IAmenitieRepository amenitie)
        {
            _roomService = roomService;
            _map = map;
            _amenitie = amenitie;
        }

        public IActionResult Index()
        {
            var rooms = _roomService.GetAll();
            var roomsview = new List<RoomViewModel>();
            foreach (var room in rooms)
            {
                var roomview = _map.Map<RoomViewModel>(room);

                var amenities = new List<AmentyViewModel>();
                foreach (var ameniti in room.Amenities)
                {
                    amenities.Add(_map.Map<AmentyViewModel>(ameniti));
                }
                roomview.AmentyViewModels = amenities;
                roomsview.Add(roomview);
            }
            return View(roomsview);
        }
        public IActionResult Create()
        {
            var viewModel = new CreateRoomViewModel
            {
                AllAmenities = _amenitie.GetAll().Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name
                })
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateRoomViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var room = _map.Map<Room>(viewModel.Room);

                room.Amenities = _amenitie.GetAll().Where(a => viewModel.SelectedAmenityIds.Contains(a.Id)).ToList();

                _roomService.Add(room);
                return RedirectToAction(nameof(Index));
            }
            // Якщо модель не валідна, повертаємо представлення з помилками
            viewModel.AllAmenities = _amenitie.GetAll().Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            });
            return View(viewModel);

        }
        public IActionResult Details(int id)
        {
            var room = _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound(); // Кімната не знайдена
            }
            var roomview = _map.Map<RoomViewModel>(room);
            var amenities = new List<AmentyViewModel>();
            foreach (var ameniti in room.Amenities)
            {
                amenities.Add(_map.Map<AmentyViewModel>(ameniti));
            }
            roomview.AmentyViewModels = amenities;
            return View(roomview);
        }
        public IActionResult Edit(int id)
        {
            var room = _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }

            var viewModel = new RoomViewModel
            {
                Id = room.Id,
                Number = room.Number,
                RoomType = room.Type,
                Capacity = room.Capacity,
                Price = room.Price,
                SelectedAmenityIds = room.Amenities.Select(a => a.Id).ToList(),
                AllAmenities = _dbContext.Amenities.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name,
                    Selected = room.Amenities.Any(ra => ra.Id == a.Id) // Mark amenities as selected if they belong to the room
                })
            };

            return View(viewModel)
        }
    }
}
