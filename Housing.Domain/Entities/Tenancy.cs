namespace Housing.Domain.Entities;
public class Tenancy:BaseEntity
{

    public Guid PropertyId { get; private set; }
    public Property Property { get; private set; }

    private readonly List<Tenant> _tenants = new();
    public IReadOnlyCollection<Tenant> Tenants => _tenants.AsReadOnly();

    public Guid LandlordId { get; private set; }
    public Landlord Landlord { get; private set; }

    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    
    private readonly List<RentCharge> _rentHistory = new();
    public IReadOnlyList<RentCharge> RentHistory => _rentHistory.AsReadOnly();
    
    private readonly List<RentPayment> _payments = new();
    public IReadOnlyList<RentPayment> Payments => _payments.AsReadOnly();


    private Tenancy() { }

    public Tenancy(Guid propertyId, Guid landlordId, DateTime startDate, IEnumerable<Tenant> tenants)
    {
        Id = Guid.NewGuid();
        PropertyId = propertyId;
        LandlordId = landlordId;
        StartDate = startDate;

        foreach (var tenant in tenants)
        {
            _tenants.Add(tenant); // or attach existing tenants via EF
        }
    }

    public void End(DateTime endDate)
    {
        if (EndDate is not null)
            throw new Exception("Tenancy already ended");

        if (endDate < StartDate) throw new ArgumentException("Tenancy end date cannot be before start date");
        EndDate = endDate;
    }
    public void AddRentCharge(decimal amount, DateTime startDate, string reason)
    {
        // End the previous rent charge if it exists
        var current = _rentHistory.LastOrDefault(r => r.EndDate == null);
        if (current != null)
            current.End(startDate.AddDays(-1));

        _rentHistory.Add(new RentCharge(Id, amount, startDate, reason));
    }
    public void AddPayment(decimal amount, DateTime paidOn, string? reference = null)
    {
        _payments.Add(new RentPayment(Id, amount, paidOn, reference));
    }
    public decimal GetBalance()
    {
        var totalCharges = _rentHistory.Sum(r => r.Amount);
        var totalPayments = _payments.Sum(p => p.Amount);
        return totalPayments - totalCharges;
    }
    
    public decimal GetArrears() => Math.Max(0, GetBalance() * -1);


}




