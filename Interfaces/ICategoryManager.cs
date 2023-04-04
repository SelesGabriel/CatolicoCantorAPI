using CatolicoCantorAPI.ViewModels.Category.Get;
using CatolicoCantorAPI.ViewModels.Category.Set;

namespace CatolicoCantorAPI.Interfaces
{
    public interface ICategoryManager
    {

        Task<List<CategoryGet>> GetAllCategories();
        Task<CategoryGet> GetCategoryById(int id);

        Task<CategoryGet> PostCategory(CreateCategoryViewModel model);
        Task<CategoryGet> PutCategory(CreateCategoryViewModel model);

        Task<CategoryGet> DeleteCategory(int id);
    }
}
