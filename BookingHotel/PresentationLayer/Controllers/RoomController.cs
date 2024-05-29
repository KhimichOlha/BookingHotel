using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
