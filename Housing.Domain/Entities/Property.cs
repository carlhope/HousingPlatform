namespace Housing.Domain.Entities;

public class Property
{
    public Guid Id { get; set; }
    public string Address { get; set; } = default!;
    public int Bedrooms { get; set; }
    public decimal Rent { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}