using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.CategoryViewModel.Get;
using CatolicoCantorAPI.ViewModels.CategoryViewModel.Set;
using CatolicoCantorAPI.ViewModels.Music.Get;
using CatolicoCantorAPI.ViewModels.Music.Set;

namespace CatolicoCantorAPI.Interfaces
{
    public interface IMusicManager
    {
        Task<IEnumerable<Music>> GetAllMusics();
        Task<Music> GetMusicById(int id);
        Task<string> PostMusic(CreateMusicViewModel model);
    }
}
