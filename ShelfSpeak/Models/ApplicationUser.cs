using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ShelfSpeak.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Id { get; set; }

        public ApplicationUser()
        {

        }
    }
}
