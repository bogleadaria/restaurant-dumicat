using System.ComponentModel.DataAnnotations.Schema;
namespace Restaurant_Backend.Entities;

[Table("ticket")]
public class Ticket
{
    [Column("client_id")]
    public int Id { get; set; }
    [Column("ticket_number")]
    public required int TicketNumber { get; set; }
    [Column("product_id")]
    public required int ProductId { get; set; }
    [Column("order_id")]
    public required int OrderId { get; set; }
    
    public Product Product { get; set; }
}