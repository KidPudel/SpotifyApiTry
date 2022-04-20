using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SpotifyApi.Interfaces;
using SpotifyApi.Services;
using SpotifyApi.Models;

namespace SpotifyApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpotifyController : ControllerBase
    {
        private readonly IOAuthClientService _authClientService;
        private readonly ISpotifyPlaylistService _playlistService;
        
        public SpotifyController(IOAuthClientService authClientService, ISpotifyPlaylistService playlistService)
        {
            _authClientService = authClientService;
            _playlistService = playlistService;
        }


        [HttpPost("/playlist_info")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> PlaylistInfo([FromForm] string playlistId)
        {
            TokenModel tokenModel = await _authClientService.GetToken();
            var playlistInfo = await _playlistService.GetPlaylist(tokenModel.AccessToken, playlistId);

            return Ok(playlistInfo);
        }
    }
}
