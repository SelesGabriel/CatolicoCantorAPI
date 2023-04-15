using CatolicoCantorAPI.Data;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.CategoryViewModel.Set;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace CatolicoCantorAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseConfig databaseConfig;
        IEnumerable<Category> category;
        public CategoryRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            using var connection = new MySqlConnection(databaseConfig.Name);
            var teste = await connection.QueryAsync<Category>("select Id, Nome from Category");
            return teste;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            using var connection = new MySqlConnection(databaseConfig.Name);
            var cat= await connection.QuerySingleAsync<Category>($"select Id, Nome from Category where Id = {id}");
            if(cat == null)
                return null;
            return cat;
        }

        public async Task<string> PostCategory(CreateCategoryViewModel model)
        {
            using var connection = new MySqlConnection(databaseConfig.Name);
            category = await connection.QueryAsync<Category>($"SELECT Id, Nome FROM Category WHERE Nome = '{model.Nome}'");
            if (!category.Any())
            {
                await connection.ExecuteAsync($"INSERT INTO Category (Nome) VALUES ('{model.Nome}')");
                return $"Categoria '{model.Nome}' criada com sucesso.";
            }
            return $"Já existe a categoria '{category.First().Nome}' com o id '{category.First().Id}'";
        }



    }
}
