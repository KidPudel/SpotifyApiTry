using SpotifyApi.Models;

namespace SpotifyApi.Interfaces
{
    public interface ISpotifyPlaylistService
    {
        /// <summary>
        /// Method that returns an information abot requested playlist
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="playlistId"></param>
        /// <returns></returns>
        Task<PlaylistModel> GetPlaylist(string accessToken, string playlistId);
    }
}
