using Microsoft.AspNetCore.Mvc;
using Restaurant_Backend.Repository;
using Restaurant_Backend.Entities;
using Restaurant_Backend.Repository.Product_Ingredient;

namespace Restaurant_Backend.Controllers;

[ApiController]
[Route("api/product_ingredient")]
public class ProductIngredientController : ControllerBase
{
    private readonly IProductIngredientRepository _productIngredientRepository;
    public ProductIngredientController(IProductIngredientRepository productIngredientRepository)
    {
        _productIngredientRepository = productIngredientRepository;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_productIngredientRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = _productIngredientRepository.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public IActionResult AddProduct(ProductIngredient productIngredient)
    {
        var tmp_productIngredient = _productIngredientRepository.GetById(productIngredient.Id);
        if (tmp_productIngredient != null)
        {
            return BadRequest("Product_Ingredient already exists");
        }
        _productIngredientRepository.Add(productIngredient);
        return Ok();
        
    }

    [HttpPut]
    public IActionResult UpdateProduct(ProductIngredient productIngredient)
    {
        _productIngredientRepository.Update(productIngredient);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var productIngredient = _productIngredientRepository.GetById(id);
        _productIngredientRepository.Delete(productIngredient);
        return Ok();
    }
}