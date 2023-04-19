using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Playlist.Set;

namespace CatolicoCantorAPI.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<Playlist>> GetAllPlaylists();
        Task<Playlist> GetPlaylistById(int id);
        Task<string> PostPlaylist(CreatePlaylistViewModel model);
        Task<string> IncludeMusicToPlaylist(int idMusic, int idPlaylist);
    }
}
