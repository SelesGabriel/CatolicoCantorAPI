using CatolicoCantorAPI.Data;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Playlist.Set;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatolicoCantorAPI.Controllers;

[ApiController]
[Route("v1")]
public class PlaylistController : ControllerBase
{
    private readonly IPlaylistManager playlistManager;
    public PlaylistController(IPlaylistManager playlistManager)
    {
        this.playlistManager = playlistManager;
    }
    [HttpGet, Route("playlists")]
    public async Task<IActionResult> GetMusics()
    {
        var playlist = await playlistManager.GetAllPlaylists();
        return Ok(playlist);
    }

    [HttpPost, Route("playlist")]
    public async Task<IActionResult> PostMusic([FromBody] CreatePlaylistViewModel model)
    {
        var playlist = await playlistManager.PostPlaylist(model);
        return Ok(playlist);
    }
}