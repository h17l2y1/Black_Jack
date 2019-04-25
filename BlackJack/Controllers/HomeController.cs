using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
