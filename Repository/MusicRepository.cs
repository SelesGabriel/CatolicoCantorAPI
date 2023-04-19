using CatolicoCantorAPI.Data;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.CategoryViewModel.Get;
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
            var musics = await connection.QueryAsync<Music>("select * from Music");
            var categories = await connection.QueryAsync<Category>("select * from category");
            var categoryMusic = await connection.QueryAsync<GetMusicCategory>("select * from musiccategory");

            foreach (var music in musics)
            {
                foreach (var category in categoryMusic)
                {
                    if (category.IdMusic == music.Id)
                        music.Categories.AddRange(categories.Where(x=>x.Id == category.IdCategory));
                    
                }
            }

            return musics;
        }

        public async Task<Music> GetMusicById(int id)
        {
            using var connection = new MySqlConnection(databaseConfig.Name);
            var music = await connection.QuerySingleAsync<Music>($"select * FROM Music WHERE id = {id}");
            var categories = await connection.QueryAsync<Category>("select * from category");
            var categoryMusic = await connection.QueryAsync<GetMusicCategory>("select * from musiccategory");
            foreach (var category in categoryMusic)
            {
                if(category.IdMusic == music.Id)
                    music.Categories.AddRange(categories.Where(x=>x.Id == category.IdCategory));
            }
            return music;
        }

        public async Task<string> PostMusic(CreateMusicViewModel model)
        {
            using var connection = new MySqlConnection(databaseConfig.Name);
            IEnumerable<Music> music = await connection.QueryAsync<Music>($"select * from music where nome = '{model.Nome}'");
            if (!music.Any())
            {
                int categoryMaxId = await connection.QuerySingleAsync<int>("select max(Id) from category order by id desc");
                await connection.ExecuteAsync($"insert into music (Nome,Cantor,Letra,Cifra,Youtube,Tags) VALUES ('{model.Nome}','{model.Cantor}','{model.Letra}','{model.Cifra}','{model.Youtube}','{model.Tags}')");
                int idMusic = await connection.QuerySingleAsync<int>($"SELECT Id from Music where nome = '{model.Nome}';");

                foreach (var idCategory in model.Categories)
                {
                    if (idCategory.Id > categoryMaxId)
                        return $"Categoria com o id {idCategory} não existe. Remova esse id e continue.";
                    await connection.ExecuteAsync($"insert into musicCategory (IdMusic, IdCategory) VALUES ({idMusic},{idCategory.Id})");
                }

                return $"Musica '{model.Nome}' criada com sucesso.";
            }
            return "Essa musica já existe.";

        }
    }
}
