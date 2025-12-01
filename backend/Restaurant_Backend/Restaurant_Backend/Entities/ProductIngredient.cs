namespace Restaurant_Backend.Entities;

public class ProductIngredient
{
    public int Id { get; set; }
    public required int ProductId { get; set; }
    public required int IngredientId { get; set; }
}