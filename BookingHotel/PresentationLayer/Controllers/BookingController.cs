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
        private readonly MapModelToViewModel _map;
       
        public BookingController(IBookingRepository bookingRepository, IGuestService guestService,
            IRoomService roomService, IPricing pricing, 
            INotificationService notificationService, UserManager<IdentityUser> userManager, MapModelToViewModel map )
        {
            _bookingRepository = bookingRepository;
            _roomService = roomService;
            _guestService = guestService;
            _pricing = pricing;
            _notificationService = notificationService;
            _userManager = userManager;
            _map = map;
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
                    viewBookings.Add(_map.BookingToViewModel(booking));

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
            var bookingViewModel = _map.BookingToViewModel(booking);
            return View(booking);
          
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
                var command = new CreateBooking (_bookingRepository, _ )
            }
        }
        
    }

}
