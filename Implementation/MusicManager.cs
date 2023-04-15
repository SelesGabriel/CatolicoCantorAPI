using AutoMapper;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Music.Get;
using CatolicoCantorAPI.ViewModels.Music.Set;

namespace CatolicoCantorAPI.Implementation;
public class MusicManager : IMusicManager
{
    readonly IMusicRepository repository;
    readonly IMapper mapper;
    public MusicManager(IMusicRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<Music>> GetAllMusics()
    {
        return await repository.GetAllMusics();
    }

    public async Task<Music> GetMusicById(int id)
    {
        return await repository.GetMusicById(id);
    }

    public async Task<string> PostMusic(CreateMusicViewModel model)
    {
        return await repository.PostMusic(model);
    }
}
