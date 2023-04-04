using AutoMapper;
using CatolicoCantorAPI.Data;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.Category.Get;
using CatolicoCantorAPI.ViewModels.Category.Set;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatolicoCantorAPI.Implementation;

public class CategoryManager : ICategoryManager
{
    readonly ICategoryRepository repository;
    readonly IMapper mapper;
    public CategoryManager(ICategoryRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }


    public async Task<List<CategoryGet>> GetAllCategories() => mapper.Map<List<CategoryGet>>(await repository.GetAllCategories());

    public async Task<CategoryGet> GetCategoryById(int id) => mapper.Map<CategoryGet>(await repository.GetCategoryById(id));

    public async Task<CategoryGet> PostCategory(CreateCategoryViewModel model)
    {
        var category = mapper.Map<Category>(model);
        var retorno = mapper.Map<CategoryGet>(await repository.PostCategory(category));
        return retorno;
    }

    public async Task<CategoryGet> PutCategory(CreateCategoryViewModel model)
    {
        throw new NotImplementedException();
    }
    public async Task<CategoryGet> DeleteCategory(int id)
    {
        throw new NotImplementedException();
    }
}
