using Microsoft.AspNetCore.Mvc;
using Restaurant_Backend.Repository;
using Restaurant_Backend.Entities;
using Restaurant_Backend.Repository.Reservation;
using Restaurant_Backend.Repository.Table;

namespace Restaurant_Backend.Controllers;

[ApiController]
[Route("api/table")]
public class TableController : ControllerBase
{
    private readonly ITableRepository _tableRepository;
    public  TableController(ITableRepository tableRepository)
    {
        _tableRepository = tableRepository;
    }

    [HttpGet]
    public IActionResult GetTables()
    {
        return Ok(_tableRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetTable(int id)
    {
        var table = _tableRepository.GetById(id);
        if (table == null)
            return NotFound();
        return Ok(table);
    }

    [HttpPost]
    public IActionResult AddTable(Table table)
    {
        var tmp_table = _tableRepository.GetById(table.Id);
        if (table != null)
        {
            return BadRequest("Table already exists");
        }
        _tableRepository.Add(table);
        return Ok(table);
    }

    [HttpPut]
    public IActionResult UpdateTable(Table table)
    {
        _tableRepository.Update(table);
        return Ok(table);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTable(int id)
    {
        var table = _tableRepository.GetById(id);
        _tableRepository.Delete(table);
        return Ok();
    }
}