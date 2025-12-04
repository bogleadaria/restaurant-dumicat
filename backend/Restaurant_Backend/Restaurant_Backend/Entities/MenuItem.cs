using System.ComponentModel.DataAnnotations.Schema;
namespace Restaurant_Backend.Entities;

[Table("menu_item")]
public class MenuItem
{
    [Column("menu_item_id")]
    public int Id { get; set; }
    [Column("menu_id")]
    public required int MenuId { get; set; }
    [Column("product_id")]
    public required int ProductId { get; set; }
    [Column("category_id")]
    public required int CategoryId { get; set; }
    [Column("ingredient_id")]
    public required int IngredientId { get; set; }
}