using Microsoft.AspNetCore.Mvc;
using Restaurant_Backend.Repository;
using Restaurant_Backend.Entities;
using Restaurant_Backend.Repository.Order;

namespace Restaurant_Backend.Controllers;

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    public  OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = _orderRepository.GetAll();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public IActionResult GetOrder(int id)
    {
        var menu = _orderRepository.GetById(id);
        if (menu == null)
        {
            return NotFound();
        }
        return Ok(menu);
    }

    [HttpPost]
    public IActionResult AddOrder(Order order)
    {
        var tmp_order = _orderRepository.GetById(order.Id);
        if (tmp_order!= null)
        {
            return BadRequest("Order already exists");
        }
        _orderRepository.Add(order);
        return Ok(order);
    }

    [HttpPut]
    public IActionResult UpdateOrder(Order order)
    {
        _orderRepository.Update(order);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(int id)
    {
        var order = _orderRepository.GetById(id);
        _orderRepository.Delete(order);
        return Ok();
    }
    
}