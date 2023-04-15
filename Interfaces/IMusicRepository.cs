using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Music.Set;

namespace CatolicoCantorAPI.Interfaces
{
    public interface IMusicRepository
    {
        Task<IEnumerable<Music>> GetAllMusics();
        Task<Music> GetMusicById(int id);
        Task<string> PostMusic(CreateMusicViewModel model);
    }
}
