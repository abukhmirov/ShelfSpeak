using System.Text.Json.Serialization;


namespace ShelfSpeak.Models.APIJsonShenanigans
{
    public class OpenLibraryAPIResponse
    {
        public int numFound { get; set; }
        public int start { get; set; }
        public bool numFoundExact { get; set; }
        public List<Docs> Docs { get; set; }
    }
}
