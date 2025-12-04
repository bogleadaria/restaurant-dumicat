using System.ComponentModel.DataAnnotations.Schema;
namespace Restaurant_Backend.Entities;

[Table("reservation")]
public class Reservation
{
    [Column("reservation_id")]
    public int Id { get; set; }
    [Column("client_id")]
    public required int ClientId { get; set; }
    [Column("table_id")]
    public required int TableId { get; set; }
    [Column("date")]
    public required DateOnly Date { get; set; }
    [Column("time")]
    public required TimeOnly Time { get; set; }
    [Column("people_count")]
    public required int PeopleCount { get; set; }
    [Column("status")]
    public string? Status { get; set; }
    
    public Client Client { get; set; }
    public Table Table { get; set; }
    
    
    public ICollection<Product> Products { get; set; } = new List<Product>();
}