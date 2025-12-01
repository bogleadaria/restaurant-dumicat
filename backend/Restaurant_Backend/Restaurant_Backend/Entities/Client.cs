namespace Restaurant_Backend.Entities;

public class Client
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Phone{ get; set; }
    public string? Mail {get; set; }
    public string? Address { get; set; }
}