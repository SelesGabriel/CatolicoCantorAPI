using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.Models;
using CatolicoCantorAPI.ViewModels.CategoryViewModel.Set;
using Microsoft.AspNetCore.Mvc;

namespace CatolicoCantorAPI.Controllers;

[ApiController]
[Route("v1")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryManager categoryManager;
    public CategoryController(ICategoryManager categoryManager)
    {
        this.categoryManager = categoryManager;
    }

    [HttpGet, Route("categories")]
    public async Task<IActionResult> GetCategory()
    {
        return Ok(await categoryManager.GetAllCategories());
    }

    [HttpGet,Route("category")]
    public async Task<IActionResult> GetCategoryById([FromHeader]int id)
    {
        return Ok(await categoryManager.GetCategoryById(id));
    }

    [HttpPost,Route("category")]
    public async Task<IActionResult> PostCategory([FromBody]CreateCategoryViewModel category)
    {
        return Ok(await categoryManager.PostCategory(category));
    }

}