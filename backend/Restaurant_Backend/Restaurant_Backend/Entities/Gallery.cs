using System.ComponentModel.DataAnnotations.Schema;
namespace Restaurant_Backend.Entities;

public class Gallery
{
    [Column("photo_id")]
    public int Id { get; set; }
    [Column("product_id")]
    public int? ProductId { get; set; }
    [Column("file_name")]
    public required string FileName { get; set; }
    [Column("content_type")]
    public required string ContentType { get; set; }
    [Column("data")]
    public required byte[] Data { get; set; }
}