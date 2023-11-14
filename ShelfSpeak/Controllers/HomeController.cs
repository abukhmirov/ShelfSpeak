using Microsoft.AspNetCore.Mvc;
using ShelfSpeak.Interfaces;
using ShelfSpeak.Models;
using ShelfSpeak.Models.APIJsonShenanigans;
using System.Diagnostics;

namespace ShelfSpeak.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOpenLibraryService _openLibraryService;

        public HomeController(ILogger<HomeController> logger, IOpenLibraryService openLibraryService)
        {
            _logger = logger;
            _openLibraryService = openLibraryService;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> SearchBooks(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return View();
            }

            Docs bookOLIDJson = _openLibraryService.SearchBooksOLIDJson(query);

            return View(bookOLIDJson);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}