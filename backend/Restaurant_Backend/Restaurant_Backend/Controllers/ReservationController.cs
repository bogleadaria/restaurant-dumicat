using Microsoft.AspNetCore.Mvc;
using Restaurant_Backend.Repository;
using Restaurant_Backend.Entities;
using Restaurant_Backend.Repository.Product;
using Restaurant_Backend.Repository.Reservation;

namespace Restaurant_Backend.Controllers;

[ApiController]
[Route("api/reservation")]
public class ReservationController : ControllerBase
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationController(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    [HttpGet]
    public IActionResult GetReservations()
    {
        return Ok(_reservationRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetReservation(int id)
    {
        var reservation = _reservationRepository.GetById(id);
        if (reservation == null)
            return NotFound();
        return Ok(reservation);
    }

    [HttpPost]
    public IActionResult AddReservation(Reservation reservation)
    {
        var tmp_reservation = _reservationRepository.GetById(reservation.Id);
        if (tmp_reservation != null)
        {
            return BadRequest("Reservation already exists");
        }

        _reservationRepository.Add(reservation);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateReservation(Reservation reservation)
    {
        _reservationRepository.Update(reservation);
        return Ok(reservation);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteReservation(int id)
    {
        var reservation = _reservationRepository.GetById(id);
        _reservationRepository.Delete(reservation);
        return Ok();
    }

}