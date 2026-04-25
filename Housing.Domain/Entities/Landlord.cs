namespace Housing.Domain.Entities;

public class Landlord
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string ContactEmail { get; private set; }
    public string ContactPhone { get; private set; }
    public LandlordType Type { get; private set; }

    private Landlord() { }

    public Landlord(string name, string email, string phone, LandlordType type)
    {
        Id = Guid.NewGuid();
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
