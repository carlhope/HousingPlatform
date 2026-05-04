using Housing.Api.Contracts.Rent;
using Housing.Domain.Entities;

namespace Housing.Api.Mappers;

public static class RentPaymentMapping
{
    public static RentPaymentDto ToDto(this RentPayment payment)
        => new(
            payment.Amount,
            payment.PaidOn,
            payment.Reference
        );
}