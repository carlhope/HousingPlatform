using FluentValidation;

namespace Housing.Api.Features.Tenancy.Rent.RentPayment.ListRentPayment;

public class ListRentPaymentsValidator: AbstractValidator<ListRentPaymentsQuery>
{
    public ListRentPaymentsValidator()
    {
        // No rules needed, but the validator must exist for consistency
    }
}