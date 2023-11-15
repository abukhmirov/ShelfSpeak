namespace ShelfSpeak.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int cover_i { get; set; }

        public string cover_url { get; set; }
        public ApplicationUser User { get; set; }

    }
}
