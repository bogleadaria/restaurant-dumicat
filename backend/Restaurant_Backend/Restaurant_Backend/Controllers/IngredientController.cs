using Microsoft.AspNetCore.Mvc;
using Restaurant_Backend.Repository;
using Restaurant_Backend.Entities;
using Restaurant_Backend.Repository.Ingredient;
using Restaurant_Backend.Repository.Menu;

namespace Restaurant_Backend.Controllers;
[ApiController]
[Route("api/ingredient")]
public class IngredientController : ControllerBase
{
    private readonly IIngredientRepository _ingredientRepository;

    public IngredientController(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    [HttpGet]
    public IActionResult GetIngredients()
    {
        return Ok(_ingredientRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetIngredient(int id)
    {
        var ingredient = _ingredientRepository.GetById(id);
        if (ingredient == null) return NotFound();
        return Ok(ingredient);
    }

    [HttpPost]
    public IActionResult AddIngredient(Ingredient ingredient)
    {
        var tmp_ingredient = _ingredientRepository.GetById(ingredient.Id);
        if (tmp_ingredient == null)
        {
            return BadRequest("Ingredient already exists");
        }
        _ingredientRepository.Add(ingredient);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateIngredient(Ingredient ingredient)
    {
        _ingredientRepository.Update(ingredient);
        return Ok(ingredient);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteIngredient(int id)
    {
        var ingredient = _ingredientRepository.GetById(id);
        _ingredientRepository.Delete(ingredient);
        return Ok();
    }
    
}