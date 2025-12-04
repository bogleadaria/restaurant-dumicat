using System.ComponentModel.DataAnnotations.Schema;
namespace Restaurant_Backend.Entities;

[Table("order")]
public class Order
{
    [Column("order_id")]
    public int Id { get; set; }
    [Column("status")]
    public string? Status { get; set; }
    [Column("total_price")]
    public required float TotalPrice { get; set; }
    [Column("client_id")]
    public required int ClientId { get; set; }
    [Column("product_id")]
    public required int ProductId { get; set; }
    
    public Client Client { get; set; } = null!;
    public Product Product { get; set; } = null!;
    
}