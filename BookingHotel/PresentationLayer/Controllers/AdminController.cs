using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfases;
using DataAccessLayer.Repositories.Servises;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomService _roomService;
        private readonly IGuestService _guestService;
        private readonly IMapper _map;
        private readonly INotificationService _notificationService;
        public AdminController(IBookingRepository bookingRepository, IRoomService roomService, IGuestService guestService, IMapper map, INotificationService notificationService)
        {
            _bookingRepository = bookingRepository;
            _roomService = roomService;
            _guestService = guestService;
            _map = map;
            _notificationService = notificationService;

        }

        public IActionResult Index()
        {
            var dashboardData = new AdminDashboardViewModel
            {
                TotalBookings = _bookingRepository.GetAll().Count(),
                TotalRevenue = _bookingRepository.GetAll().Sum(b => b.Room.Price),
                OccupancyRate = _roomService.CalculateOccupancyRate(),
                PendingBookings = _bookingRepository.GetAll().Count(b => b.Status == BookingStatus.Pending),
                ConfirmedBookings = _bookingRepository.GetAll().Count(b => b.Status == BookingStatus.Confirmed),
                CancelledBookings = _bookingRepository.GetAll().Count(b => b.Status == BookingStatus.Cancelled),
                TotalRooms = _roomService.GetAll().Count(),
                AvailableRooms = _roomService.GetAvailableRoomss(DateTime.Now, DateTime.Now.AddDays(1), 1).Count(), // Example calculation
                TotalGuests = _guestService.GetAll().Count()
            };
            return View(dashboardData);
        }
    }
}
