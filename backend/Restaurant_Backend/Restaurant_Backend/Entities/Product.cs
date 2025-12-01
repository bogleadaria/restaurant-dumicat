namespace Restaurant_Backend.Entities;

public class Product
{
    public int Id { get; set; }
    public required int CategoryId { get; set; }
    public required string Name { get; set; }
    public float? Price { get; set; }
    public required int Stock { get; set; }
}