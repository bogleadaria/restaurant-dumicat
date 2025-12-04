using Microsoft.AspNetCore.Mvc;
using Restaurant_Backend.Repository;
using Restaurant_Backend.Entities;
using Restaurant_Backend.Repository.Ticket;

namespace Restaurant_Backend.Controllers;

[ApiController]
[Route("api/ticket")]
public class TicketController : ControllerBase
{
    private readonly ITicketRepository _ticketRepository;
    public  TicketController(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    [HttpGet]
    public IActionResult GetTickets()
    {
        return Ok(_ticketRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetTicket(int id)
    {
        var ticket = _ticketRepository.GetById(id);
        if (ticket == null)
        {
            return NotFound();
        }
        return Ok(ticket);
    }

    [HttpPost]
    public IActionResult AddTicket(Ticket ticket)
    {
        var tmp_ticket = _ticketRepository.GetById(ticket.Id);
        if (tmp_ticket != null)
        {
            return BadRequest("Ticket already exists");
        }
        _ticketRepository.Add(ticket);
        return Ok(ticket);
    }

    [HttpPut]
    public IActionResult UpdateTicket(Ticket ticket)
    {
        _ticketRepository.Update(ticket);
        return Ok(ticket);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTicket(int id)
    {
        var ticket = _ticketRepository.GetById(id);
        _ticketRepository.Delete(ticket);
        return Ok();
    }
}