namespace Housing.Domain.Entities;

public class Tenant: BaseEntity
{

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    private Tenant() { } // EF Core

    public Tenant(string firstName, string lastName, string email, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }
    public void UpdateDetails(string firstName, string lastName, string email, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }

    public void UpdateContactDetails(string email, string phone)
    {
        Email = email;
        Phone = phone;
    }
}