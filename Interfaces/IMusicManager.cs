using CatolicoCantorAPI.ViewModels.CategoryViewModel.Get;
using CatolicoCantorAPI.ViewModels.CategoryViewModel.Set;
using CatolicoCantorAPI.ViewModels.Music.Get;
using CatolicoCantorAPI.ViewModels.Music.Set;

namespace CatolicoCantorAPI.Interfaces
{
    public interface IMusicManager
    {
        Task<List<MusicGet>> GetAllMusics();
        Task<MusicGet> GetMusicById(int id);

        Task<MusicGet> PostMusic(CreateMusicViewModel model);
        Task<MusicGet> PutMusic(CreateMusicViewModel model);

        Task<MusicGet> DeleteMusic(int id);
    }
}
