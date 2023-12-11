using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ShelfSpeak.Models
{
    public class ApplicationUser : IdentityUser
    {

        public List<Book> Books { get; set; }  = new List<Book>();
        public List<Message> Messages { get; set; }
        public ApplicationUser()
        {

        }
    }
}
