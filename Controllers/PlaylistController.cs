using CatolicoCantorAPI.Data;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Music.Set;
using CatolicoCantorAPI.ViewModels.Playlist.Set;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mysqlx;

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
    public async Task<IActionResult> GetPlaylists()
    {
        var playlist = await playlistManager.GetAllPlaylists();
        return Ok(playlist);
    }

    [HttpPost, Route("playlist")]
    public async Task<string> PostPlaylist([FromBody] CreatePlaylistViewModel model)
    {
        var playlist = await playlistManager.PostPlaylist(model);
        return playlist;
    }

    [HttpPost,Route("includemusic")]
    public async Task<IActionResult> IncludeMusicToPlaylist([FromBody] IncludeMusicPlaylist model)
    {
        return Ok(await playlistManager.IncludeMusicToPlaylist(model.MusicId, model.PlaylistId));
    }
}