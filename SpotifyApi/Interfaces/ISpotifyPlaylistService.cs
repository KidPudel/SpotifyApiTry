namespace SpotifyApi.Interfaces
{
    public interface ISpotifyPlaylistService
    {
        /// <summary>
        /// Method that returns an information abot requested playlist
        /// </summary>
        /// <param name="playlistId"></param>
        /// <returns></returns>
        Task GetPlaylist(string playlistId);
    }
}
