using CatolicoCantorAPI.Data;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Music.Set;
using CatolicoCantorAPI.ViewModels.Playlist.Set;
using CatolicoCantorAPI.ViewModels.PlaylistViewModel.Get;
using Dapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace CatolicoCantorAPI.Repository
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly DatabaseConfig databaseConfig;
        public PlaylistRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }
        public async Task<IEnumerable<Playlist>> GetAllPlaylists()
        {
            using var connection = new MySqlConnection(databaseConfig.Name);
            var musics = await connection.QueryAsync<Music>("select * from Music");
            var playlists = await connection.QueryAsync<Playlist>("select * from Playlist");
            var musicPlaylist = await connection.QueryAsync<MusicPlaylist>("select * from musicPlaylist");

            foreach (var playlist in playlists)
            {
                foreach (var music in musicPlaylist)
                {
                    if (music.IdPLaylist == playlist.Id)
                        playlist.Musics.AddRange(musics.Where(x => x.Id == music.IdMusic));
                }
            }
            return playlists;
        }

        public async Task<Playlist> GetPlaylistById(int id)
        {
            using var connection = new MySqlConnection(databaseConfig.Name);
            var playlist = await connection.QuerySingleAsync<Playlist>("select * from playlist");
            return playlist;
        }

        public async Task<string> PostPlaylist(CreatePlaylistViewModel model)
        {
            using var connection = new MySqlConnection(databaseConfig.Name);
            var playlist = await connection.QueryAsync<Playlist>($"select * from playlist where nome = '{model.Nome}'");
            if (playlist.Any())
                return "Nome da playlist já existe.";
            await connection.ExecuteAsync($"insert into playlist (Nome,IdUsuario,Publica) values ('{model.Nome}',{model.IdUsuario},{model.Publica})");
            int idPlaylist = await connection.QuerySingleAsync<int>($"SELECT Id from playlist where nome = '{model.Nome}';");
            if (model.IdMusics != null)
            {
                foreach (var idMusic in model.IdMusics)
                {
                    if (idMusic == 0) break;
                    await connection.ExecuteAsync($"insert into musicPlaylist (IdMusic,IdPlaylist) values ({idPlaylist},{idMusic})");
                }
            }
            //string idNewPlaylist = await connection.QuerySingleAsync<int>("select max(id) from playlist");
            return idPlaylist.ToString();
        }
            
        public async Task<string> IncludeMusicToPlaylist(int idMusic, int idPlaylist)
        {
            using var connection = new MySqlConnection(databaseConfig.Name);
            var musicPlaylist = await connection.QueryAsync<List<IncludeMusicPlaylist>>($"select idMusic, idPlaylist from musicPlaylist where idMusic = {idMusic} and idPlaylist = {idPlaylist}");
            if(musicPlaylist.Any())
            {
                return "já existe.";
            }
            await connection.ExecuteAsync($"insert into musicplaylist (idMusic,idPlaylist) values ({idMusic},{idPlaylist})");

            return "Incluido com sucesso.";
        }
    }
}
