using Microsoft.AspNetCore.Mvc;
using Restaurant_Backend.Repository;
using Restaurant_Backend.Entities;
using Restaurant_Backend.Repository.Menu_Item;

namespace Restaurant_Backend.Controllers;

[ApiController]
[Route("api/menu_item")]
public class MenuItemController : ControllerBase
{
    private readonly IMenuItemRepository _menuItemRepository;
    public MenuItemController(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }

    [HttpGet]
    public IActionResult GetMenuItems()
    {
        var menuItems = _menuItemRepository.GetAll();
        return Ok(menuItems);
    }

    [HttpGet("{id}")]
    public IActionResult GetMenuItem(int id)
    {
        var menuItem = _menuItemRepository.GetById(id);
        if (menuItem == null)
            return NotFound();
        return Ok(menuItem);
    }

    [HttpPost]
    public IActionResult AddMenuItem(MenuItem menuItem)
    {
        var tmp_menuItem = _menuItemRepository.GetById(menuItem.Id);
        if (tmp_menuItem != null)
        {
            return BadRequest("Menu item already exists");
        }
        _menuItemRepository.Add(menuItem);
        return Ok(menuItem);
    }

    [HttpPut]
    public IActionResult UpdateMenuItem(MenuItem menuItem)
    {
        _menuItemRepository.Update(menuItem);
        return Ok(menuItem);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMenuItem(int id)
    {
        var menuItem = _menuItemRepository.GetById(id);
        _menuItemRepository.Delete(menuItem);
        return Ok();
    }
}