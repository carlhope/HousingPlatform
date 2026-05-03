using FluentValidation;

namespace Housing.Api.Features.Tenant.Create;

public class CreateTenantValidator : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantValidator()
    {
        //RuleFor(x => x.Name).NotEmpty();
        //RuleFor(x => x.Address).NotEmpty();
        //RuleFor(x => x.Bedrooms).GreaterThan(0);
    }
}