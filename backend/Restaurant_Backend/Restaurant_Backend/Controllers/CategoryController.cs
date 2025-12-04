using Microsoft.AspNetCore.Mvc;
using Restaurant_Backend.Repository;
using Restaurant_Backend.Entities;
using Restaurant_Backend.Repository.Category;

namespace Restaurant_Backend.Controllers;


[ApiController]
[Route("api/category")]

public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        return Ok(_categoryRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetCategory(int id)
    {
        var category = _categoryRepository.GetById(id);
        if (category == null)
        {
            return NotFound();
        }
        
        return Ok(category);
    }

    [HttpPost]
    public IActionResult AddCategory(Category category)
    {
        var exists = _categoryRepository.GetById(category.Id);
        if (exists != null)
        {
            return BadRequest("Category already exists");
        }
        _categoryRepository.Add(category);
        return Ok(category);
    }

    [HttpPut]
    public IActionResult UpdateCategory(Category category)
    {
        _categoryRepository.Update(category);
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var category = _categoryRepository.GetById(id);
        _categoryRepository.Delete(category);
        return Ok();
    }
}