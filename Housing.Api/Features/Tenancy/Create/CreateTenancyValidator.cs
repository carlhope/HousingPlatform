using FluentValidation;

namespace Housing.Api.Features.Tenancy.Create;

public sealed class CreateTenancyValidator : AbstractValidator<CreateTenancyCommand>

{ 
    public CreateTenancyValidator()
    {
        RuleFor(x => x.LandlordId).NotEmpty();
        RuleFor(x=>x.PropertyId).NotEmpty();
        RuleFor(x => x.TenantIds).NotEmpty();
        RuleFor(x=>x.StartDate).NotEmpty();
    }
}