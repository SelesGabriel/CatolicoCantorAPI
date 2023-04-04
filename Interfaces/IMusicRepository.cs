using CatolicoCantorAPI.Models;

namespace CatolicoCantorAPI.Interfaces
{
    public interface IMusicRepository
    {
        Task<List<Music>> GetAllMusics();
        Task<Music> GetMusicById(int id);

        Task<Music> PostMusic(Music model);
        Task<Music> PutMusic(Music model);

        Task<Music> DeleteMusic(int id);
    }
}
