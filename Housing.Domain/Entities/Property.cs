namespace Housing.Domain.Entities;

public class Property
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public int Bedrooms { get; private set; }

    public Guid OwnerId { get; private set; }
    public Guid LandlordId { get; private set; }

    public Owner Owner { get; private set; }
    public Landlord Landlord { get; private set; }
    private readonly List<Tenancy> _tenancies = new();
    public IReadOnlyCollection<Tenancy> Tenancies => _tenancies.AsReadOnly();

    public Tenancy? CurrentTenancy =>
        _tenancies.FirstOrDefault(t => t.EndDate == null);


    private Property() { }

    public Property(
        string name,
        string address,
        int bedrooms,
        Guid ownerId,
        Guid landlordId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Address = address;
        Bedrooms = bedrooms;
        OwnerId = ownerId;
        LandlordId = landlordId;
    }

    public void UpdateDetails(
        string name,
        string address,
        int bedrooms 
        )
    {
        Name = name;
        Address = address;
        Bedrooms = bedrooms;
    }
}

