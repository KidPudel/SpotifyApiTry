using System.Text.Json.Serialization;

namespace SpotifyApi.Models
{
    /// <summary>
    /// Details that we need to get authenticated
    /// </summary>
    public class OAuthClientModel
    {
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }
    }
}
