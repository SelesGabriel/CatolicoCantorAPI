using AutoMapper;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels;
using CatolicoCantorAPI.ViewModels.Playlist.Get;
using CatolicoCantorAPI.ViewModels.Playlist.Set;

namespace CatolicoCantorAPI.Mapping
{
    public class PlaylistMap : Profile
    {
        public PlaylistMap()
        {
            CreateMap<PlaylistGet, Playlist>();
            CreateMap<Playlist, PlaylistGet>();
            CreateMap<Playlist, CreatePlaylistViewModel>().ForMember(x=>x.idMusics, map=>map.MapFrom(x=>x.Musics.Select(x=>x.Id)));
            CreateMap<CreatePlaylistViewModel, Playlist>();
        }
    }
}
