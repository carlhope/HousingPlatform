using FluentValidation;

namespace Housing.Api.Features.Owner.Update;

public class UpdateOwnerValidator : AbstractValidator<UpdateOwnerCommand>
{
    public UpdateOwnerValidator()
    {
        RuleFor(x=>x.Id).NotNull();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.ContactEmail).NotEmpty().EmailAddress();
        RuleFor(x => x.ContactPhone).NotEmpty();
    }

    
}