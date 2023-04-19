using CatolicoCantorAPI.ViewModels.Playlist.Set;
using CatolicoCantorAPI.ViewModels.Playlist.Get;
using CatolicoCantorAPI.Models;

namespace CatolicoCantorAPI.Interfaces
{
    public interface IPlaylistManager
    {
        Task<IEnumerable<Playlist>> GetAllPlaylists();
        Task<Playlist> GetPlaylistById(int id);

        Task<string> PostPlaylist(CreatePlaylistViewModel model);
        Task<string> IncludeMusicToPlaylist(int idMusic, int idPlaylist);
    }
}
