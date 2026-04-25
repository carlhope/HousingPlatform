namespace Housing.Domain.Entities;

public class RentCharge
{
    public Guid Id { get; private set; }
    public Guid TenancyId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }

    private RentCharge() { }

    public RentCharge(Guid tenancyId, decimal amount, DateTime startDate)
    {
        Id = Guid.NewGuid();
        TenancyId = tenancyId;
        Amount = amount;
        StartDate = startDate;
    }

    public void End(DateTime endDate)
    {
        EndDate = endDate;
    }
}
