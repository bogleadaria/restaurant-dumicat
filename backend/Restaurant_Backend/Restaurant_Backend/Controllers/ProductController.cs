using Microsoft.AspNetCore.Mvc;
using Restaurant_Backend.Repository;
using Restaurant_Backend.Entities;
using Restaurant_Backend.Repository.Product;

namespace Restaurant_Backend.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    public  ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_productRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = _productRepository.GetById(id);
        if (product == null) 
            return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        var tmp_product = _productRepository.GetById(product.Id);
        if (tmp_product != null)
        {
            return BadRequest("Product already exist");
        }
        _productRepository.Add(product);
        return Ok(product);
    }

    [HttpPut]
    public IActionResult UpdateProduct(Product product)
    {
        _productRepository.Update(product);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _productRepository.GetById(id);
        _productRepository.Delete(product);
        return Ok();
    }
}