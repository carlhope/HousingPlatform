using FluentValidation;

namespace Housing.Api.Features.Owner.Get;

public class GetOwnerValidator : AbstractValidator<GetOwnerQuery>
{
    public GetOwnerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}