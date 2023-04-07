using AutoMapper;
using CatolicoCantorAPI.Data;
using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.CategoryViewModel.Get;
using CatolicoCantorAPI.ViewModels.CategoryViewModel.Set;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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


    public async Task<IEnumerable<Category>> GetAllCategories() { 
       var teste  =  await repository.GetAllCategories();
        return teste;
    }

    public async Task<Category> GetCategoryById(int id)
    {
        return await repository.GetCategoryById(id);
    }

    public async Task<string> PostCategory(Category category)
    {
        return await repository.PostCategory(category);
    }
}
