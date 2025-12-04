using System.ComponentModel.DataAnnotations.Schema;
namespace Restaurant_Backend.Entities;

[Table("menu")]
public class Menu
{
    [Column("menu_id")]
    public int Id { get; set; }
    [Column("name")]
    public required string Name { get; set; }
}