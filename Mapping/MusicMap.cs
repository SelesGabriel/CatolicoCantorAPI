using AutoMapper;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Music.Get;
using CatolicoCantorAPI.ViewModels.Music.Set;

namespace CatolicoCantorAPI.Mapping;

public class MusicMap : Profile
{
    public MusicMap()
    {

        CreateMap<MusicGet, Music>();
        CreateMap<Music, MusicGet>();
        CreateMap<Music, CreateMusicViewModel>();
        CreateMap<CreateMusicViewModel, Music>();
    }
}
