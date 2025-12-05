using System.ComponentModel.DataAnnotations.Schema;
namespace Restaurant_Backend.Entities;

[Table("ingredient")]
public class Ingredient
{
    [Column("ingredient_id")]
    public int Id { get; set; }
    [Column("name")]
    public required string Name { get; set; }
    [Column("is_allergen")]
    public required bool IsAllergen { get; set; } 
    
    
    
    public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    public ICollection<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();
}