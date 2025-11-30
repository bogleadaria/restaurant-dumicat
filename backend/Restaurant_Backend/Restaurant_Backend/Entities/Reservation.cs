namespace Restaurant_Backend.Entities;

public class Reservation
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int TableId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public int PeopleCount { get; set; }
    public string? Status { get; set; }
}