using FluentValidation;

namespace Housing.Api.Features.Properties.Create;

public class CreatePropertyValidator : AbstractValidator<CreatePropertyCommand>
{
    public CreatePropertyValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.Bedrooms).GreaterThan(0);
    }
}