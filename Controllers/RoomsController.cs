using Microsoft.AspNetCore.Mvc;

namespace asp_homework.Controllers
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