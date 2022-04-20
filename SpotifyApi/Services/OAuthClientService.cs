using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using SpotifyApi.Interfaces;
using SpotifyApi.Models;

namespace SpotifyApi.Services
{
    public class OAuthClientService : IOAuthClientService
    {
        private IConfiguration _configuration;

        private readonly HttpClient _httpClient;
        public OAuthClientService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<TokenModel> GetToken()
        {
            var CLIENT_ID = _configuration["client_id"];
            var CLIENT_SECRET = _configuration["client_secret"];

            // convert secrets to base64
            var byteAuthorizationString = Encoding.UTF8.GetBytes(CLIENT_ID + ":" + CLIENT_SECRET);
            var base64Authorization = Convert.ToBase64String(byteAuthorizationString);

            // set Authorization header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Authorization);

            // body of the request
            var requestBody = new Dictionary<string, string>();
            requestBody.Add("grant_type", "client_credentials");

            // set request parameters with body
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_httpClient.BaseAddress + "api/token"),
                // body
                Content = new FormUrlEncodedContent(requestBody) 
            };
            // get response
            var response = await _httpClient.SendAsync(request);

            // ensure there is no error accured
            response.EnsureSuccessStatusCode();

            // get response body as string
            var responseBody = await response.Content.ReadAsStringAsync();

            // deserialize response body to TokenModel
            var token = JsonSerializer.Deserialize<TokenModel>(responseBody);

            return token;
        }
    }
}
