using Microsoft.AspNetCore.Mvc;

namespace reservations_web.Controllers
{
    public class RoomsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}