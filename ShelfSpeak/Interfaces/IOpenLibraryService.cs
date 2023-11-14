using ShelfSpeak.Models.APIJsonShenanigans;

namespace ShelfSpeak.Interfaces
{
    public interface IOpenLibraryService
    {
        Docs SearchBooksDocs(string query);
    }
}
