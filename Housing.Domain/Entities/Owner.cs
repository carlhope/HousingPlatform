namespace Housing.Domain.Entities;

public class Owner: BaseEntity
{
    public string Name { get; private set; }
    public string ContactEmail { get; private set; }
    public string ContactPhone { get; private set; }
    private readonly List<Property> _properties = new();
    public IReadOnlyCollection<Property> Properties => _properties.AsReadOnly();



    private Owner() { }

    public Owner(string name, string email, string phone)
    {
        Name = name;
        ContactEmail = email;
        ContactPhone = phone;
    }
    public void UpdateDetails(
        string name,
        string email,
        string phone
    )
    {
        Name = name;
        ContactEmail = email;
        ContactPhone = phone;
    }
}
