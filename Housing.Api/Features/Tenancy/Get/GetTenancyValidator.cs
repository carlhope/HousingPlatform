using FluentValidation;

namespace Housing.Api.Features.Tenancy.Get;

public class GetTenancyValidator : AbstractValidator<GetTenancyQuery>
{
    GetTenancyValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}