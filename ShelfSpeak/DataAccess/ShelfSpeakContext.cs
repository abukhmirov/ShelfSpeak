using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ShelfSpeak.Models;

namespace ShelfSpeak.DataAccess
{
    public class ShelfSpeakContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Librarians { get; set; }
        public DbSet<Book> Books { get; set; }


        public ShelfSpeakContext(DbContextOptions<ShelfSpeakContext> options)
            : base(options) { }
    }
}