using FluentValidation;

namespace Housing.Api.Features.Tenancy.Get;

public class GetTenancyValidator : AbstractValidator<GetTenancyQuery>
{
    public GetTenancyValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}