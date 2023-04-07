using AutoMapper;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.CategoryViewModel.Get;
using CatolicoCantorAPI.ViewModels.CategoryViewModel.Set;
using CatolicoCantorAPI.ViewModels.CategoryViewModel.Set;

namespace CatolicoCantorAPI.Mapping;

public class CategoryMap :Profile
{
    public CategoryMap() {

        CreateMap<CategoryGet, Category>();
        CreateMap<Category, CategoryGet>();
        CreateMap<Category, CreateCategoryViewModel>();
        CreateMap<CreateCategoryViewModel, Category>();
        CreateMap<IncludeCategoryMusic, Category>();
    }
}
