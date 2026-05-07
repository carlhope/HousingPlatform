using FluentValidation;

namespace Housing.Api.Features.Tenancy.Rent.RentCharge.ListRentCharges;

public class ListRentChargesValidator: AbstractValidator<ListRentChargesQuery>
{
    public ListRentChargesValidator()
    {
        // No rules needed, but the validator must exist for consistency
    }
}