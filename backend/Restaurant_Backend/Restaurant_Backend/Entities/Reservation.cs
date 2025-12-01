namespace Restaurant_Backend.Entities;

public class Reservation
{
    public int Id { get; set; }
    public required int ClientId { get; set; }
    public required int TableId { get; set; }
    public required DateOnly Date { get; set; }
    public required TimeOnly Time { get; set; }
    public required int PeopleCount { get; set; }
    public string? Status { get; set; }
}