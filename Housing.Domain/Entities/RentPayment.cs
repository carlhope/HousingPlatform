namespace Housing.Domain.Entities;
public class RentPayment
{
    public Guid Id { get; private set; }
    public Guid TenancyId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime PaidOn { get; private set; }
    public string? Reference { get; private set; }

    private RentPayment() { }

    public RentPayment(Guid tenancyId, decimal amount, DateTime paidOn, string? reference = null)
    {
        Id = Guid.NewGuid();
        TenancyId = tenancyId;
        Amount = amount;
        PaidOn = paidOn;
        Reference = reference;
    }
}
