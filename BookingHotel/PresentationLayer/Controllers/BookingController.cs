using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Repositories.Interfases;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IPricing _pricing;
        private readonly INotificationService _notificationService;
        private readonly UserManager<IdentityUser> _userManager;
        public BookingController(IBookingRepository bookingRepository, IRoomRepository roomRepository,
            IGuestRepository guestRepository, IPricing pricing, 
            INotificationService notificationService, UserManager<IdentityUser> userManager )
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _guestRepository = guestRepository;
            _pricing = pricing;
            _notificationService = notificationService;
            _userManager = userManager;
        }

        public async IActionResult Index()
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
                return View(bookings);
            }
            
        }
        
    }
}
