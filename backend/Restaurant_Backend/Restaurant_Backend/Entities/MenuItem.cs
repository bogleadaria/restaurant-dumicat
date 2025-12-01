namespace Restaurant_Backend.Entities;

public class MenuItem
{
    public int Id { get; set; }
    public required int MenuId { get; set; }
    public required int ProductId { get; set; }
    public required int IngredientId { get; set; }
}