using ShelfSpeak.Interfaces;
using ShelfSpeak.Models.APIJsonShenanigans;
using System.Text.Json;

namespace ShelfSpeak.Services
{
    public class OpenLibraryService : IOpenLibraryService
    {
        private static readonly HttpClient client;

        static OpenLibraryService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://openlibrary.org")
            };
        }

        public Docs SearchBooksDocs(string query)
        {
            query = query.ToLower().Replace(" ", "+");
            var url = $"/search.json?q={query}";
            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = response.Content.ReadAsStringAsync().Result;

                var apiResponse = JsonSerializer.Deserialize<OpenLibraryAPIResponse>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                // Assuming you want the first document in the list
               var book = apiResponse.Docs?.FirstOrDefault();

                if (book != null && book.cover_i != null)
                {
                    var coverUrl = $"https://covers.openlibrary.org/b/id/{book.cover_i}-M.jpg";
                    book.CoverUrl = coverUrl;
                }
                return book;
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

    }
}
