using FluentValidation;

namespace Housing.Api.Features.Landlord.List;

public class ListLandlordValidator : AbstractValidator<ListLandlordQuery>
{
    public ListLandlordValidator()
    {
        // No rules needed, but the validator must exist for consistency
    }
}