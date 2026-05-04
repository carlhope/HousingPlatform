using FluentValidation;

namespace Housing.Api.Features.Owner.List;

public class ListOwnerValidator : AbstractValidator<ListOwnerQuery>
{
    public ListOwnerValidator()
    {
        // No rules needed, but the validator must exist for consistency
    }
}