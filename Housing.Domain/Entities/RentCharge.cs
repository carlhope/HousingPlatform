namespace Housing.Domain.Entities;

public class RentCharge: BaseEntity
{
    public Guid TenancyId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public string Reason { get; private set; }

    private RentCharge() { }

 
    public RentCharge(Guid tenancyId, decimal amount, DateTime startDate, string reason)
    {
        TenancyId = tenancyId;
        Amount = amount;
        StartDate = startDate;
        Reason = reason;
    }

    public void End(DateTime endDate)
    {
        EndDate = endDate;
    }
}
