using FluentValidation;

namespace Housing.Api.Features.Properties.Update;

    

public class UpdatePropertyValidator : AbstractValidator<UpdatePropertyCommand>
{
    public UpdatePropertyValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.Bedrooms).GreaterThan(0);
    }

    
}