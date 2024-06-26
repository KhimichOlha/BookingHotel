﻿using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfases;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Mapper;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomService _roomService;
        private readonly IGuestService _guestService;
        private readonly IPricing _pricing;
        private readonly INotificationService _notificationService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _map;
        private readonly IBookingState _state;
       
        public BookingController(IBookingRepository bookingRepository, IGuestService guestService,
            IRoomService roomService, IPricing pricing, IBookingState state,
            INotificationService notificationService, UserManager<IdentityUser> userManager, IMapper map )
        {
            _bookingRepository = bookingRepository;
            _roomService = roomService;
            _guestService = guestService;
            _pricing = pricing;
            _notificationService = notificationService;
            _userManager = userManager;
            _map = map;
            _state = state;
        }

        public async Task< IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            
            var guest = _guestService.GetByUserId(user.Id);
            if(guest == null)
            {
                return NotFound();
            }
            var bookings = _bookingRepository.GetByGuestId(guest.Id);

            if(bookings == null)
            {
                return NotFound();
            }
            else
            {
                var viewBookings = new List<BookingViewModel>();
                foreach(var booking in bookings)
                {
                    viewBookings.Add(_map.Map<BookingViewModel>(booking));

                }
                return View(viewBookings);
            }
            
        }
     
        public IActionResult Details(int id)
        {
            var booking = _bookingRepository.GetById(id);
            if (booking == null)
            {
                return NotFound();
            }
            var bookingViewModel = _map.Map<BookingViewModel>(booking);
            return View(bookingViewModel);
          
        }
        public IActionResult Search()
        {
            var viewModel = new SearchViewModel
            {
                CheckInDate = DateTime.Today,
                CheckOutDate = DateTime.Today.AddDays(1),
                GuestCount = 1
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Search(SearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                var availableRooms = _roomService.GetAvailableRoomss(search.CheckInDate, search.CheckOutDate, search.GuestCount);
                var viewRooms = new List<RoomViewModel>();
                foreach(var room in availableRooms)
                {
					viewRooms.Add(_map.Map<RoomViewModel>(room));

				}
                return View("SearchResults", viewRooms);
            }
            return View(search);
        }
        public async Task<IActionResult> Create(int roomId)
        {
            var room = _roomService.GetRoomById(roomId);
            if(room == null||! room.IsAvailable)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var guest = _guestService.GetByUserId(user.Id);
            if (guest == null)
            {
                return NotFound();
            }
            var booking = new BookingViewModel();
            booking.Guest = _map.Map<GuestViewModel>(guest);
            booking.Room = _map.Map<RoomViewModel>(room);
            return View(booking);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookingViewModel viewModel)
        {
            //if (true)
            //{
				var user = await _userManager.GetUserAsync(User);
				if (user == null)
				{
					return RedirectToAction("Login", "Account");
				}
				var guest = _guestService.GetByUserId(user.Id);
				if (guest == null)
				{
					return NotFound();
				}
				//var guest = _guestService.GetById(viewModel.Guest.Id);
                var room = _roomService.GetRoomById(viewModel.Room.Id);
                room.IsAvailable = true;
                var command = new CreateBooking(_bookingRepository, _state, _pricing);
                var booking = _map.Map<Booking>(viewModel);
				booking.Room = room ;
				booking.Guest = guest;
				command.Execute(booking);
				return RedirectToAction("Details", viewModel.Id);
            //}
            //return View(viewModel);

        }
        [HttpPost]
        public IActionResult Confirm(int id)
        {
            var booking = _bookingRepository.GetById(id);
            if (booking == null)
            {
                return NotFound();

            }
            var command = new ConfirmBooking(_bookingRepository, _state);
            command.Execute(booking);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Cancel(int id)
        {
            var booking = _bookingRepository.GetById(id);
            if (booking == null)
            {
                return NotFound();

            }
            var command = new CancelBooking(_bookingRepository, _state);
            command.Execute(booking);
            return RedirectToAction("Index");

        }

    }

}
