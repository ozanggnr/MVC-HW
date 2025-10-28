using Microsoft.AspNetCore.Mvc;

namespace MVC_HW.Controllers
{
    public class FootballersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
