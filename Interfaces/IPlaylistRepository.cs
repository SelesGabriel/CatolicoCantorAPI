using CatolicoCantorAPI.Models;

namespace CatolicoCantorAPI.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<List<Playlist>> GetAllPlaylists();
        Task<Playlist> GetPlaylistById(int id);

        Task<Playlist> PostPlaylist(Playlist model);
        Task<Playlist> PutPlaylist(Playlist model);

        Task<Playlist> DeletePlaylist(int id);
    }
}
