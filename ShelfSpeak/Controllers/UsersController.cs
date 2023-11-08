using Microsoft.AspNetCore.Mvc;

namespace ShelfSpeak.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
