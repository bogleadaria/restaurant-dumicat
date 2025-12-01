namespace Restaurant_Backend.Entities;

public class Table
{
    public int Id { get; set; }
    public required int TableNumber { get; set; }
    public int? SeatNumber { get; set; }
}