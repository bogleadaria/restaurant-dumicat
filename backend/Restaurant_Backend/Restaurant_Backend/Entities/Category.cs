using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_Backend.Entities;
[Table("category")]
public class Category
{
    [Column("category_id")]
    public int Id { get; set; }
    [Column("name")]
    public required string Name { get; set; }
}