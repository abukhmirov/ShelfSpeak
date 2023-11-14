using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ShelfSpeak.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Id { get; set; }

        public string Email { get; set; }


        public string Password { get; set; }
        public List<Message> Posts { get; set; } = new List<Message>();

        public ApplicationUser()
        {

        }
    }
}
