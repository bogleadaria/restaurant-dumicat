namespace Restaurant_Backend.Entities;

public class Order
{
    public int Id { get; set; }
    public string? Status { get; set; }
    public float? TotalPrice { get; set; }
    public int ClientId { get; set; }
    public int ProductId { get; set; }
}