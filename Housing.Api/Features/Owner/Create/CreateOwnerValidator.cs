using FluentValidation;

namespace Housing.Api.Features.Owner.Create;

public sealed class CreateOwnerValidator : AbstractValidator<CreateOwnerCommand>

{ 
    public CreateOwnerValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x=>x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Phone).NotEmpty();
 
    }
}