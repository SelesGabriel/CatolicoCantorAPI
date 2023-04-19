using AutoMapper;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Playlist.Get;
using CatolicoCantorAPI.ViewModels.Playlist.Set;

namespace CatolicoCantorAPI.Implementation;
public class PlaylistManager : IPlaylistManager
{
    readonly IPlaylistRepository repository;
    public PlaylistManager(IPlaylistRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IEnumerable<Playlist>> GetAllPlaylists()
    {
        return await repository.GetAllPlaylists();
    }

    public async Task<Playlist> GetPlaylistById(int id)
    {
        return await repository.GetPlaylistById(id);
    }

    public async Task<string> PostPlaylist(CreatePlaylistViewModel model)
    {
        return await repository.PostPlaylist(model);
    }

    public async Task<string> IncludeMusicToPlaylist(int idMusic, int idPlaylist)
    {
        return await repository.IncludeMusicToPlaylist(idMusic,idPlaylist);
    }
}
