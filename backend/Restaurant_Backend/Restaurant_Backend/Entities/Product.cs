using System.ComponentModel.DataAnnotations.Schema;
namespace Restaurant_Backend.Entities;

[Table("product")]
public class Product
{
    [Column("product_id")]
    public int Id { get; set; }
    [Column("category_id")]
    public required int CategoryId { get; set; }
    [Column("name")]
    public required string Name { get; set; }
    [Column("price")]
    public float? Price { get; set; }
    [Column("stock")]
    public required int Stock { get; set; }
}