using CatolicoCantorAPI.Data;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

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

        public async Task Create(Category product)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            await connection.ExecuteAsync("INSERT INTO Product (Name, Description)" +
                "VALUES (@Name, @Description);", product);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);
            var teste = await connection.QueryAsync<Category>("select * from Category");
            return teste;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);
            var cat= await connection.QuerySingleAsync<Category>($"select id, name from Category where id = {id}");
            if(cat == null)
                return null;
            return cat;
        }

        public async Task<string> PostCategory(Category model)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);
            category = await connection.QueryAsync<Category>($"SELECT Id, Name FROM Category WHERE Name = '{model.Name}'");
            if (!category.Any())
            {
                await connection.ExecuteAsync($"INSERT INTO Category (Name) VALUES ('{model.Name}')");
                return $"Categoria {model.Name} criada com sucesso.";
            }
            return $"Já existe a categoria '{category.First().Name}' com o id '{category.First().Id}'";
        }



    }
}
