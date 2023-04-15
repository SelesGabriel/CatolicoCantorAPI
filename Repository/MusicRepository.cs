using CatolicoCantorAPI.Data;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Music.Set;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace CatolicoCantorAPI.Repository
{
    public class MusicRepository : IMusicRepository
    {
        private readonly DatabaseConfig databaseConfig;
        public MusicRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<Music>> GetAllMusics()
        {
            using var connection = new MySqlConnection(databaseConfig.Name);
            return await connection.QueryAsync<Music>("select * from Music");
        }

        public async Task<Music> GetMusicById(int id)
        {
            using var connection = new MySqlConnection(databaseConfig.Name);
            return await connection.QuerySingleAsync<Music>($"select * FROM Music WHEWRE id = {id}");
        }

        public async Task<string> PostMusic(CreateMusicViewModel model)
        {
            using var connection = new MySqlConnection(databaseConfig.Name);
            IEnumerable<Music> music = await connection.QueryAsync<Music>($"select * from music whehre nome = {model.Nome}");
            if (!music.Any())
            {
                await connection.ExecuteAsync($"insert into music ()");
                return "ok";
            }
            return "nok";
            
        }
    }
}
