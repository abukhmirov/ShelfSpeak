using Microsoft.AspNetCore.Mvc;

namespace ShelfSpeak.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
