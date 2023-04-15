using CatolicoCantorAPI.Data;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Music.Set;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatolicoCantorAPI.Controllers;

[ApiController]
[Route("v1")]
public class MusicController : ControllerBase
{
    private readonly IMusicManager musicManager;
    public MusicController(IMusicManager musicManager)
    {
        this.musicManager = musicManager;

    }
    [HttpGet, Route("musics")]
    public async Task<IActionResult> GetMusics()
    {
        return Ok(await musicManager.GetAllMusics());
    }

    [HttpGet, Route("music")]
    public async Task<IActionResult> GetMusicById([FromHeader]int id)
    {
        return Ok(await musicManager.GetMusicById(id));
    }

    [HttpPost, Route("music")]
    public async Task<IActionResult> PostMusic([FromBody] CreateMusicViewModel model)
    {
        return Ok(await musicManager.PostMusic(model));
    }
}
