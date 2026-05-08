using FluentValidation;

namespace Housing.Api.Features.Tenancy.Rent.GetBalance;

public class GetBalanceValidator : AbstractValidator<GetBalanceQuery>
{
    GetBalanceValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}