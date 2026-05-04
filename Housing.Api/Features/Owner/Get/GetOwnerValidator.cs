using FluentValidation;

namespace Housing.Api.Features.Owner.Get;

public class GetOwnerValidator : AbstractValidator<GetOwnerQuery>
{
    GetOwnerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}