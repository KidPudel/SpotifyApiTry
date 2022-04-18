using SpotifyApi.Interfaces;
using System.Net.Http.Headers;

namespace SpotifyApi.Services
{
    public class SpotifyPlaylistService : ISpotifyPlaylistService
    {
        private readonly HttpClient _httpClient;

        public SpotifyPlaylistService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetPlaylist(string accessToken, string playlistId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + playlistId);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}
