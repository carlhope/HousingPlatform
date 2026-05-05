using FluentValidation;

namespace Housing.Api.Features.Tenancy.List;

public class ListTenanciesValidator : AbstractValidator<ListTenanciesQuery>
{
    public ListTenanciesValidator()
    {
        // No rules needed, but the validator must exist for consistency
    }
}