namespace Restaurant_Backend.Entities;

public class Ticket
{
    public int Id { get; set; }
    public required int TicketNumber { get; set; }
    public required int ProductId { get; set; }
    public required int OrderId { get; set; }
}