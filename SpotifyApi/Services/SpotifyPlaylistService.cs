using SpotifyApi.Interfaces;

namespace SpotifyApi.Services
{
    public class SpotifyPlaylistService : ISpotifyPlaylistService
    {
        private readonly HttpClient _httpClient;

        public SpotifyPlaylistService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task GetPlaylist(string playlistId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "");
            var respone = _httpClient.GetAsync(playlistId);
        }
    }
}
