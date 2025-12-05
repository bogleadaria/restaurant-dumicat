using System.ComponentModel.DataAnnotations.Schema;
namespace Restaurant_Backend.Entities;

[Table("table")]
public class Table
{
    [Column("table_id")]
    public int Id { get; set; }
    [Column("number")]
    public required int TableNumber { get; set; }
    [Column("seats_number")]
    public int? SeatNumber { get; set; }
    
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}