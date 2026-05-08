namespace Housing.Domain.Entities;

public class Landlord:BaseEntity
{
    public string Name { get; private set; }
    public string ContactEmail { get; private set; }
    public string ContactPhone { get; private set; }
    public LandlordType Type { get; private set; }
    private readonly List<Property> _properties = new();
    public IReadOnlyCollection<Property> Properties => _properties.AsReadOnly();



    private Landlord() { }

    public Landlord(string name, string email, string phone, LandlordType type)
    {
        Name = name;
        ContactEmail = email;
        ContactPhone = phone;
        Type = type;
    }
    public void UpdateDetails(
        string name,
        string email,
        string phone,
        LandlordType type
    )
    {
        Name = name;
        ContactEmail = email;
        ContactPhone = phone;
        Type = type;
    }
}

public enum LandlordType
{
    HousingAssociation,
    PrivateLandlord,
    ManagementCompany
}
