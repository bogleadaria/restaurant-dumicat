using Microsoft.AspNetCore.Mvc;
using Restaurant_Backend.Repository;
using Restaurant_Backend.Entities;
using Restaurant_Backend.Repository.Menu;

namespace Restaurant_Backend.Controllers;

[ApiController]
[Route("api/menu")]
public class MenuController : ControllerBase
{
    private readonly IMenuRepository _menuRepository;
    public MenuController(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    [HttpGet]
    public IActionResult GetMenus()
    {
        return Ok(_menuRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetMenu(int id)
    {
        var menu = _menuRepository.GetById(id);
        if (menu == null)
        {
            return NotFound();
        }
        return Ok(menu);
    }

    [HttpPost]
    public IActionResult AddMenu(Menu menu)
    {
       var tmp_menu = _menuRepository.GetById(menu.Id);
       if (tmp_menu != null)
       {
           return BadRequest("Menu already exists");
       }
        return Ok(menu);
    }

    [HttpPut]
    public IActionResult UpdateMenu(Menu menu)
    {
        _menuRepository.Update(menu);
        return Ok(menu);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMenu(int id)
    {
        var menu = _menuRepository.GetById(id);
        _menuRepository.Delete(menu);
        return Ok();
    }
}