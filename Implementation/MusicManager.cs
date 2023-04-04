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


    public async Task<List<MusicGet>> GetAllMusics() => mapper.Map<List<MusicGet>>(await repository.GetAllMusics());

    public async Task<MusicGet> GetMusicById(int id) => mapper.Map<MusicGet>(await repository.GetMusicById(id));

    public async Task<MusicGet> PostMusic(CreateMusicViewModel model)
    {
        var category = mapper.Map<Music>(model);
        var retorno = mapper.Map<MusicGet>(await repository.PostMusic(category));
        return retorno;
    }

    public async Task<MusicGet> PutMusic(CreateMusicViewModel model)
    {
        throw new NotImplementedException();
    }
    public async Task<MusicGet> DeleteMusic(int id)
    {
        throw new NotImplementedException();
    }
}
