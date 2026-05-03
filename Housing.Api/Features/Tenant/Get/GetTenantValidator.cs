using FluentValidation;

namespace Housing.Api.Features.Tenant.Get;

public sealed class GetTenantValidator : AbstractValidator<GetTenantQuery>
{
    public GetTenantValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}