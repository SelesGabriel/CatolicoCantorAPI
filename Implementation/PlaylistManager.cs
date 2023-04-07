using AutoMapper;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Playlist.Get;
using CatolicoCantorAPI.ViewModels.Playlist.Set;

namespace CatolicoCantorAPI.Implementation;
public class PlaylistManager : IPlaylistManager
{
    readonly IPlaylistRepository repository;
    readonly IMapper mapper;
    public PlaylistManager(IPlaylistRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }


    public async Task<List<PlaylistGet>> GetAllPlaylists() => mapper.Map<List<PlaylistGet>>(await repository.GetAllPlaylists());

    public async Task<PlaylistGet> GetPlaylistById(int id) => mapper.Map<PlaylistGet>(await repository.GetPlaylistById(id));

    public async Task<PlaylistGet> PostPlaylist(CreatePlaylistViewModel model)
    {
        var category = mapper.Map<Playlist>(model);

        var retorno = mapper.Map<PlaylistGet>(await repository.PostPlaylist(category));
        return retorno;
    }

    public async Task<PlaylistGet> PutPlaylist(CreatePlaylistViewModel model)
    {
        throw new NotImplementedException();
    }
    public async Task<PlaylistGet> DeletePlaylist(int id)
    {
        throw new NotImplementedException();
    }
}
