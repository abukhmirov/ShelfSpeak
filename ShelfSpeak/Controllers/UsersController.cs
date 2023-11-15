using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelfSpeak.DataAccess;
using ShelfSpeak.Interfaces;
using ShelfSpeak.Models;
using ShelfSpeak.Models.APIJsonShenanigans;

namespace ShelfSpeak.Controllers
{
    public class UsersController : Controller
    {
        private readonly IOpenLibraryService _openLibraryService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ShelfSpeakContext _context;

        public UsersController(IOpenLibraryService openLibraryService, UserManager<ApplicationUser> userManager, ShelfSpeakContext context)
        {
            
            _openLibraryService = openLibraryService;
            _userManager = userManager;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShowLibrary(Docs searchedBook)
        {
            var book = new Book
            {
                Title = searchedBook.title_suggest,
                cover_i = searchedBook.cover_i,
                cover_url = searchedBook.CoverUrl
            };

            var user = await _userManager.GetUserAsync(User);

            book.User = user;

            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            // Redirect to the user's library
            return RedirectToAction("UserLibrary");
        }



        public async Task<IActionResult> UserLibrary()
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            // Query the Books table to get the user's books
            var userBooks = _context.Books.Where(b => b.User.Id == user.Id).ToList();

            // Display user's library in the view
            return View(userBooks);
        }
    }
}
