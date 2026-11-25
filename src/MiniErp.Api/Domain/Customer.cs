namespace MiniErp.Api.Domain;

public class Customer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Document { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
