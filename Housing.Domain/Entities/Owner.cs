namespace Housing.Domain.Entities;

public class Owner
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string ContactEmail { get; private set; }
    public string ContactPhone { get; private set; }

    private Owner() { }

    public Owner(string name, string email, string phone)
    {
        Id = Guid.NewGuid();
        Name = name;
        ContactEmail = email;
        ContactPhone = phone;
    }
}
