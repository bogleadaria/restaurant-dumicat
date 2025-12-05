using System.ComponentModel.DataAnnotations.Schema;
namespace Restaurant_Backend.Entities;

[Table("product_ingredient")]
public class ProductIngredient
{
    [Column("product_ingredient_id")]
    public int Id { get; set; }
    [Column("product_id")]
    public required int ProductId { get; set; }
    [Column("ingredient_id")]
    public required int IngredientId { get; set; }
    
    public Product Product { get; set; }
    public Ingredient Ingredient { get; set; }
}