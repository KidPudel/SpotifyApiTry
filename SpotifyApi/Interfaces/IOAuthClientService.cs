using SpotifyApi.Models;

namespace SpotifyApi.Interfaces
{
    public interface IOAuthClientService
    {
        /// <summary>
        /// Method that gets access token to make requests to spotify api
        /// </summary>
        /// <returns></returns>
        Task<TokenModel> GetToken();
    }
}
