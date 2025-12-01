namespace Restaurant_Backend.Entities;

public class Gallery
{
    public int Id { get; set; }
    public required string FileName { get; set; }
    public required string ContentType { get; set; }
    public required byte[] Data { get; set; }
    public int? ProductId { get; set; }
}