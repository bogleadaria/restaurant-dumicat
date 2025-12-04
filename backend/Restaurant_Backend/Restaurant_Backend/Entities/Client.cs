using System.ComponentModel.DataAnnotations.Schema;
namespace Restaurant_Backend.Entities;
[Table("client")]
public class Client
{
    [Column("client_id")]
    public int Id { get; set; }
    [Column("name")]
    public required string Name { get; set; }
    [Column("phone")]
    public required string Phone{ get; set; }
    [Column("mail")]
    public string? Mail {get; set; }
    [Column("address")]
    public string? Address { get; set; }
}