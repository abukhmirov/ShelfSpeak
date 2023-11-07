using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ShelfSpeak.Models;

namespace ShelfSpeak.DataAccess
{
    public class ShelfSpeakContext : DbContext
    {
        public DbSet<Message> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        public ShelfSpeakContext(DbContextOptions<ShelfSpeakContext> options)
            : base(options) { }
    }
}