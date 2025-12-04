using Microsoft.AspNetCore.Mvc;
using Restaurant_Backend.Repository;
using Restaurant_Backend.Entities;
using Restaurant_Backend.Repository.Client;

namespace Restaurant_Backend.Controllers;

[ApiController]
[Route("api/client")]
public class ClientController : ControllerBase
{
    private readonly IClientRepository _clientRepository;

    public ClientController(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    [HttpGet]
    public IActionResult GetClients()
    {
        return Ok(_clientRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetClient(int id)
    {
        var client = _clientRepository.GetById(id);
        if (client == null)
        {
            return NotFound();
        }
        return Ok(client);
    }

    [HttpPost]
    public IActionResult AddClient(Client client)
    {
        var clientt = _clientRepository.GetById(client.Id);
        if (clientt != null)
        {
            return BadRequest("Client already exists");
        }
        _clientRepository.Add(client);
        return Ok(client);
    }

    [HttpPut]
    public IActionResult UpdateClient(Client client)
    {
        _clientRepository.Update(client);
        return Ok(client);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteClient(int id)
    {
        var client = _clientRepository.GetById(id);
        _clientRepository.Delete(client);
        return Ok();
    }
}