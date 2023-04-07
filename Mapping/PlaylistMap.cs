using AutoMapper;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels;
using CatolicoCantorAPI.ViewModels.Music.Set;
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
            CreateMap<Playlist, CreatePlaylistViewModel>();
            CreateMap<CreatePlaylistViewModel, Playlist>();
            CreateMap<Playlist, IncludeMusicPlaylist>();
            CreateMap<Playlist, CreatePlaylistViewModel>();

        }
    }
}
