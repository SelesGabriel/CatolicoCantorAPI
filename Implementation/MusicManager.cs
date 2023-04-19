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
    public MusicManager(IMusicRepository repository)
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
        model.Youtube = YoutubeValidate(model.Youtube);
        model.Letra = LetrasValidate(model.Letra);
        model.Cifra = CifrasValidate(model.Cifra);
        return await repository.PostMusic(model);
    }

    public string YoutubeValidate(string link)
    {
        var v = link.Split("v=");
        if (v[1].Contains("&"))
            return  v[1].Split("&")[0].ToString();
        return v[1].ToString();
    }

    public string LetrasValidate(string link)
    {
        return link.Split(".br/")[1].ToString();
    }

    public string CifrasValidate(string link)
    {
        return link.Split(".br/")[1].ToString();
    }
}
