using AutoMapper;
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
            
            var guestId = int.Parse( user.Id);
            var bookings = _bookingRepository.GetByGuestId(guestId);
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
                return View("SearchResults", availableRooms);
            }
            return View(search);
        }
        public IActionResult Create(SearchViewModel search)
        {
            var availableRooms = _roomService.GetAvailableRoomss(search.CheckInDate, search.CheckOutDate, search.GuestCount);
            if(availableRooms == null) 
            {
                return NotFound();
            }
            return View(availableRooms);
        }
        [HttpPost]
        public IActionResult Create(BookingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var guest = _guestService.GetById(viewModel.Guest.Id);
                var room = _roomService.GetRoomById(viewModel.Room.Id);
                var command = new CreateBooking(_bookingRepository, _state, _pricing);
                command.Execute(_map.Map<Booking>(viewModel));
                return RedirectToAction("Details", viewModel.Id);
            }
            return View(viewModel);

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
