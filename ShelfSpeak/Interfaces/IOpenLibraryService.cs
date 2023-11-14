using ShelfSpeak.Models.APIJsonShenanigans;

namespace ShelfSpeak.Interfaces
{
    public interface IOpenLibraryService
    {
        Docs SearchBooksOLIDJson(string query);
    }
}
