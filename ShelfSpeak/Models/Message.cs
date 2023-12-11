namespace ShelfSpeak.Models
{
    public class Message
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string Content { get; set; }
    }
}
