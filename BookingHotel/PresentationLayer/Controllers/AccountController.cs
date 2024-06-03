using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IGuestService _guestService;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IGuestService guestService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _guestService = guestService;
        }

        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async IActionResult Register(RegisterViewModel userview)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    Email = userview.Email,
                    UserName = userview.Email
                };
                var result = await _userManager.CreateAsync(user, userview.Password);
            }
        }
    }
}
