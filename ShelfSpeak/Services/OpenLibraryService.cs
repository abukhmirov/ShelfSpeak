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

        public Docs SearchBooksOLIDJson(string query)
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
                return apiResponse.Docs?.FirstOrDefault();
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }




        //public async Task<Docs> SearchBooksOLIDJson(string query)
        //{
        //    query = query.ToLower().Replace(" ", "+");
        //    var url = $"/search.json?q={query}";
        //    var result = new OpenLibraryAPIResponse();
        //    var response = await client.GetAsync(url);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var stringResponse = await response.Content.ReadAsStringAsync();

        //        result = JsonSerializer.Deserialize<OpenLibraryAPIResponse>(stringResponse,
        //            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        //        return result.Docs.FirstOrDefault();
        //        ;
        //    }
        //    else
        //    {
        //        throw new HttpRequestException(response.ReasonPhrase);
        //    }


        //}
    }
}
