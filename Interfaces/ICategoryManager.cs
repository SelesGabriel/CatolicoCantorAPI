using CatolicoCantorAPI.Models;

namespace CatolicoCantorAPI.Interfaces
{
    public interface ICategoryManager
    {

        Task<IEnumerable<Category>> GetAllCategories();
        Task<string> PostCategory(Category category);
        Task<Category> GetCategoryById(int id);
    }
}
