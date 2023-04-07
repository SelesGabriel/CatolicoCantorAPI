using AutoMapper;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.CategoryViewModel.Set;
using CatolicoCantorAPI.ViewModels.Music.Get;
using CatolicoCantorAPI.ViewModels.Music.Set;

namespace CatolicoCantorAPI.Mapping;

public class MusicMap : Profile
{
    public MusicMap()
    {

        CreateMap<MusicGet, Music>().ReverseMap();
        CreateMap<Music, CreateMusicViewModel>().ReverseMap();
        CreateMap<Music, IncludeCategoryMusic>().ReverseMap();
    }
}
