using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Category.Set;

namespace CatolicoCantorAPI.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);

        Task<Category> PostCategory(Category model);
        Task<Category> PutCategory(Category model);

        Task<Category> DeleteCategory(int id);
    }
}
