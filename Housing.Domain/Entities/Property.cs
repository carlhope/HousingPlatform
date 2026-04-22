namespace Housing.Domain.Entities;

public class Property
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public int Bedrooms { get; private set; }
    public decimal Rent { get; private set; }

    private Property() { } // Required for EF Core

    public Property(string name, string address, int bedrooms, decimal rent)
    {
        Id = Guid.NewGuid();
        Name = name;
        Address = address;
        Bedrooms = bedrooms;
        Rent = rent;
    }
    public void UpdateDetails(string name, string address, int bedrooms, decimal rent)
    {
        Name = name;
        Address = address;
        Bedrooms = bedrooms;
        Rent = rent;
    }

}
