using SpotifyApi.Interfaces;
using SpotifyApi.Models;
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

        public async Task<PlaylistModel> GetPlaylist(string accessToken, string playlistId)
        {
            // set authorization header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // get response
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + playlistId);

            // ensure there is no error accured
            response.EnsureSuccessStatusCode();

            // get response body as string
            var responseBody = await response.Content.ReadAsStringAsync();

            var playlistInfo = System.Text.Json.JsonSerializer.Deserialize<PlaylistModel>(responseBody);

            return playlistInfo;
        }
    }
}
