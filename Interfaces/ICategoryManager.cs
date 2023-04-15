using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.CategoryViewModel.Set;

namespace CatolicoCantorAPI.Interfaces
{
    public interface ICategoryManager
    {

        Task<IEnumerable<Category>> GetAllCategories();
        Task<string> PostCategory(CreateCategoryViewModel category);
        Task<Category> GetCategoryById(int id);
    }
}
