using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ShelfSpeak.Models
{
    public class Message
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Empty message!")]
        [StringLength(1000, ErrorMessage = "Message cannot exceed 1000 characters")]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        [ValidateNever]
        public User User { get; set; }
        public List<int> Upvotes { get; set; } = new List<int>();




        public void Upvote(User user)
        {
            if (!Upvotes.Contains(user.Id))
            {
                Upvotes.Add(user.Id);
            }
        }
    }
}