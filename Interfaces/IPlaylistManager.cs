using CatolicoCantorAPI.ViewModels.Playlist.Set;
using CatolicoCantorAPI.ViewModels.Playlist.Get;

namespace CatolicoCantorAPI.Interfaces
{
    public interface IPlaylistManager
    {
        Task<List<PlaylistGet>> GetAllPlaylists();
        Task<PlaylistGet> GetPlaylistById(int id);

        Task<PlaylistGet> PostPlaylist(CreatePlaylistViewModel model);
        Task<PlaylistGet> PutPlaylist(CreatePlaylistViewModel model);

        Task<PlaylistGet> DeletePlaylist(int id);
    }
}
