using CatolicoCantorAPI.Interfaces;
using CatolicoCantorAPI.ViewModels.Category.Set;
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

    [HttpPost, Route("category")]
    public async Task<IActionResult> PostMusic([FromBody]CreateCategoryViewModel model)
    {
        return Ok(await categoryManager.PostCategory(model));
    }

}