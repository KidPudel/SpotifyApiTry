using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using SpotifyApi.Models;
using System.Net.Http.Headers;

namespace SpotifyApi.Pages
{
    public class MainModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MainModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostChoosePlaylist()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            // that we can accept
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Content_Type", "application/json");
            // request body
            var requestBody = new Dictionary<string, string>();
            requestBody.Add("playlistId", PlaylistId);

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://localhost:7236/playlist_info"),
                Method = HttpMethod.Post,
                // form
                Content = new FormUrlEncodedContent(requestBody)
            };

            // http => https
            HttpResponseMessage response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            PlaylistInfo = await response.Content.ReadFromJsonAsync<PlaylistModel>();

            return Page();
        }

        [BindProperty] public string PlaylistId { get; set; }

        public PlaylistModel PlaylistInfo { get; set; }
    }
}
