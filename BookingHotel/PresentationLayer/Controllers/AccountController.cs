using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
