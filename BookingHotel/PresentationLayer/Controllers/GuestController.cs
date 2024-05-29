using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
