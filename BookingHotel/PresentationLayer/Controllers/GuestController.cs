using AutoMapper;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class GuestController : Controller
    {
        private readonly IGuestService _guestService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _map;
        public GuestController(IGuestService guestService, UserManager<IdentityUser> userManager, IMapper map)
        {
            _guestService = guestService;
            _userManager = userManager;
            _map = map;
        }
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Acount");

            }
            var guest = _guestService.GetByUserId(user.Id);
            if (guest == null)
            {
                return NotFound();

            }
            var guestModel = _map.Map<GuestViewModel>(guest);
            return View(guestModel);
        }
        [HttpPost]
        
        public async Task<IActionResult> Edit(GuestViewModel guestModel)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var guest = _guestService.GetByUserId(user.Id);
                if (guest == null)
                {
                    return NotFound();
                }
                guest.Name = guestModel.Name;
                guest.Phone = guestModel.Phone;
                _guestService.Update(guest);
                return RedirectToAction("Details", guest.Id);

            }
            return View(guestModel);

        }
        public IActionResult Details(int Id)
        {
            var guest = _guestService.GetById(Id);
            if (guest == null)
            {
                return NotFound();
            }
            return View(_map.Map<GuestViewModel>(guest));
            
        }
        public IActionResult BookingHistory(int Id)
        {
            var guest = _guestService.GetById(Id);
            if (guest == null)
            {
                return NotFound();
            }
            var bookings = _guestService.GetBookingsForGuest(guest.Id);
            if(bookings == null)
            {
                return NotFound();
            }
            var bookingModels = new List<BookingViewModel>();
            foreach (var booking in bookings)
            {
                bookingModels.Add(_map.Map<BookingViewModel>(booking));
            }
            return View(bookingModels);
        }


    }
}
