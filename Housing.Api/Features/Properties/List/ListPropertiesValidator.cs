using FluentValidation;

namespace Housing.Api.Features.Properties.List;

public sealed class ListPropertiesValidator : AbstractValidator<ListPropertiesQuery>
{
    public ListPropertiesValidator()
    {
        // No rules needed, but the validator must exist for consistency
    }
}

