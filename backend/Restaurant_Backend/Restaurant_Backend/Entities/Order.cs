namespace Restaurant_Backend.Entities;

public class Order
{
    public int Id { get; set; }
    public string? Status { get; set; }
    public required float TotalPrice { get; set; }
    public required int ClientId { get; set; }
    public required int ProductId { get; set; }
}