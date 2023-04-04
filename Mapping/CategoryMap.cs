using AutoMapper;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Category.Get;
using CatolicoCantorAPI.ViewModels.Category.Set;

namespace CatolicoCantorAPI.Mapping;

public class CategoryMap :Profile
{
    public CategoryMap() {

        CreateMap<CategoryGet, Category>();
        CreateMap<Category, CategoryGet>();
        CreateMap<Category, CreateCategoryViewModel>();
        CreateMap<CreateCategoryViewModel, Category>();
    }
}
