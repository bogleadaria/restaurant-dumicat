namespace Restaurant_Backend.Entities;

public class Product
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public float? Price { get; set; }
    public int? Stock { get; set; }
}