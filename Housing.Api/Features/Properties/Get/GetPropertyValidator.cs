using FluentValidation;

namespace Housing.Api.Features.Properties.Get;

public sealed class GetPropertyValidator : AbstractValidator<GetPropertyQuery>
{
    public GetPropertyValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}

