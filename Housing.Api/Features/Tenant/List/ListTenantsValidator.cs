using FluentValidation;

namespace Housing.Api.Features.Tenant.Get;

public sealed class ListTenantsValidator : AbstractValidator<ListTenantsQuery>
{
    public ListTenantsValidator()
    {
        // No rules needed, but the validator must exist for consistency
    }
}