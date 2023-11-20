using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShelfSpeak.DataAccess;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ShelfSpeakContext  _context;

        public HomeController(ILogger<HomeController> logger, IOpenLibraryService openLibraryService, UserManager<ApplicationUser> userManager, ShelfSpeakContext context)
        {
            _logger = logger;
            _openLibraryService = openLibraryService;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }



        //No tag to do both GET and POST
        [Authorize]
        public async Task<IActionResult> SearchBooks(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return View();
            }

            Docs searchedBook = _openLibraryService.SearchBooksDocs(query);

            return View(searchedBook);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToLibrary(string title_suggest, int cover_i, string CoverUrl)
        {
            var book = new Book
            {
                Title = title_suggest,
                cover_i = cover_i,
                cover_url = CoverUrl
            };

            var user = await _userManager.GetUserAsync(User);

            book.User = user;

            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            // Redirect to the user's library
            return RedirectToAction("UserLibrary", "Users");
        }



        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteFromLibrary(int bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);

            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("UserLibrary", "Users");
            }

            return NotFound();
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