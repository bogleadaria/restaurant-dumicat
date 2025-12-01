namespace Restaurant_Backend.Entities;

public class Ingredient
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required bool IsAllergen { get; set; } 
}