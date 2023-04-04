using CatolicoCantorAPI.Data;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Category.Set;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CatolicoCantorAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly AppDbContext db;
        public CategoryRepository(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<List<Category>> GetAllCategories() => await db.Categories.ToListAsync();
        public async Task<Category?> GetCategoryById(int id) => await db.Categories.FindAsync(id);


        public async Task<Category> PostCategory(Category model)
        {
            await db.AddAsync(model);
            await db.SaveChangesAsync();
            return model;
        }

        public async Task<Category> PutCategory(Category model)
        {
            throw new NotImplementedException();
        }
        public async Task<Category> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

    }
}
